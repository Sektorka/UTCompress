using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace UTCompress
{
    public partial class MainForm : Form
    {
        private RegistryKey RK;
        public const int COL_STATUS = 0;
        public const int COL_FILE = 1;
        public const int COL_CTYPE = 2;

        public const string ST_COMPRESS = "Compress";
        public const string ST_DECOMPRESS = "Decompress";

        private Thread thread;
        private DateTime startTime;
        private ProcessForm processForm;

        private delegate void FinishedThreadDelegate(bool aborted);
        private delegate void AppendResultDelegate(string result);
        private delegate void UpdateRowDelegate(int counter,Status.types type);
        private delegate void UpdateProgressDelegate(int val);

        struct Status {
            public enum types { ST_NEW, ST_COMPLETTED, ST_FAILED };
            public static Image getStateIcon(types state)
            {
                switch (state) {
                    case types.ST_COMPLETTED:
                        return global::UTCompress.Properties.Resources.agt_action_success;
                    case types.ST_FAILED:
                        return global::UTCompress.Properties.Resources.messagebox_critical;
                    default:
                        return global::UTCompress.Properties.Resources.yellowled;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            string uccexe = "";
            if ((RK = Registry.CurrentUser.OpenSubKey("Software\\UTCompress")) == null)
            {
                RK = Registry.CurrentUser.CreateSubKey("Software\\UTCompress");
            }
            if(RK.GetValue("ucc.exe") != null)
                uccexe = RK.GetValue("ucc.exe").ToString();
            RK.Close();
            if (File.Exists(uccexe))
            {
                tbUccExePath.Text = uccexe;
            }

            btnAdd.Select();
        }

        private void btnBrowseUccExe_Click(object sender, EventArgs e)
        {
            if(File.Exists(tbUccExePath.Text))
                openFileDialogUccExe.InitialDirectory = (new FileInfo(tbUccExePath.Text)).DirectoryName;
            if (openFileDialogUccExe.ShowDialog() == DialogResult.OK)
            {
                tbUccExePath.Text = openFileDialogUccExe.FileName;

                if ((RK = Registry.CurrentUser.OpenSubKey(@"Software\\UTCompress",true)) == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\\UTCompress");
                    RK = Registry.CurrentUser.OpenSubKey(@"Software\\UTCompress",true);
                }

                try
                {
                    RK.SetValue("ucc.exe", tbUccExePath.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Failed save ucc.exe to registry!\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RK.Close();

            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (openFileDialogFiles.ShowDialog() == DialogResult.OK)
            {
                this.AddFiles(openFileDialogFiles.FileNames);
            }
        }

        private void AddFiles(string[] files) 
        {
            progressBar.Maximum = files.Length;
            progressBar.Value = 0;
            progressBar.ShowInTaskbar = true;
            EnableComponents(false);

           

            for (int i = 0; i < files.Length; i++) {

                int row = dataGridView.Rows.Add();

                dataGridView.Rows[row].Cells[COL_STATUS].Value = Status.getStateIcon(Status.types.ST_NEW);
                dataGridView.Rows[row].Cells[COL_FILE].Value = files[i];
                dataGridView.Rows[row].Cells[COL_CTYPE].Value = ( (new FileInfo(files[i])).Extension.Equals(".uz") ?  ST_DECOMPRESS : ST_COMPRESS );

                progressBar.Value = i + 1;

                Application.DoEvents();

            }

            EnableComponents(true);
            progressBar.Value = 0;
            progressBar.ShowInTaskbar = false;
        }

        private void EnableComponents(bool enabled)
        {
            EnableComponents(enabled, true);
        }

        private void EnableComponents(bool enabled, bool disableStarter) 
        {
            this.btnBrowseUccExe.Enabled = enabled;
            this.dataGridView.Columns[COL_CTYPE].ReadOnly = !enabled;
            this.btnAdd.Enabled = enabled;
            this.btnRemove.Enabled = enabled;
            this.btnRemoveAll.Enabled = enabled;
            if (disableStarter)
                this.btnStart.Enabled = enabled;
            else
                this.btnStart.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.deleteSelected();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            this.deleteAll();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (thread != null)
            {
                btnStart.Enabled = false;
                btnStart.Text = "Aborting...";
                progressBar.Style = ProgressBarStyle.Marquee;
                thread.Abort();
                return;
            }

            if (!File.Exists(tbUccExePath.Text))
            {
                MessageBox.Show(this, "UCC.exe file not setted! (ucc.exe)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnBrowseUccExe.Select();
                return;
            }

            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show(this, "Please add files to compress or decompress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAdd.Select();
                return;
            }

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells[COL_STATUS].Value = Status.getStateIcon(Status.types.ST_NEW);
            }

            this.EnableComponents(false, false);
            
            progressBar.Maximum = dataGridView.Rows.Count * 4;
            progressBar.Value = 0;
            progressBar.ShowInTaskbar = true;

            thread = new Thread(new ThreadStart(this.Execute));

            processForm = new ProcessForm();
            processForm.TopMost = true;
            processForm.Show();
            processForm.canClose = false;
            processForm.EraseText();

            btnStart.Text = "Abort process";

            startTime = DateTime.Now;
            thread.Start();
        }

        private void Execute()
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                try
                {
                    bool[] stages = new bool[4];
                    string send = "";
                    Process process = new Process();
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.FileName = tbUccExePath.Text;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.Arguments = dataGridView.Rows[i].Cells[COL_CTYPE].Value.ToString().ToLower() + " \"" + dataGridView.Rows[i].Cells[COL_FILE].Value.ToString() + "\"";
                    process.Start();

                    while (!process.StandardOutput.EndOfStream)
                    {
                        send = process.StandardOutput.ReadLine() + "\r\n";
                        Match m = Regex.Match(send, @"^stage (\d{1}): (\d+)\.(\d+) secs");

                        this.BeginInvoke(new AppendResultDelegate(AppendResult), new object[] { send });

                        if(m.Success){
                            try{
                                stages[int.Parse( m.Groups[1].Value.ToString() )] = true;
                                this.BeginInvoke(new UpdateProgressDelegate(UpdateProgress), new Object[] { (i * 4) + int.Parse(m.Groups[1].Value) + 1 });
                            }
                            catch(Exception){}
                        }

                    }

                    process.WaitForExit();
                    process.Dispose();

                    int c = 0;
                    for(int j = 0; j < stages.Length; j++){
                        if(stages[j])
                            c++;
                    }

                    this.BeginInvoke(new UpdateProgressDelegate(UpdateProgress), new Object[] { (i+1) * 4 });
                    this.BeginInvoke(new UpdateRowDelegate(UpdateRow), new Object[] {i,  (c == stages.Length ? Status.types.ST_COMPLETTED : Status.types.ST_FAILED ) });

                }
                catch (ThreadAbortException)
                {
                    this.BeginInvoke(new FinishedThreadDelegate(FinishedThread), new object[] { true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(null, ex.Message + "\r\n" + ex.GetBaseException(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            this.BeginInvoke(new FinishedThreadDelegate(FinishedThread), new object[] { false });

        }

        private void UpdateProgress(int val) {
            try
            {
                progressBar.Value = val;
            }
            catch (ArgumentOutOfRangeException) { 
            }
        }

        private void FinishedThread(bool aborted)
        {
            TimeSpan ts = DateTime.Now - this.startTime;
            btnStart.Text = "Start process";
            processForm.TopMost = false;
            
            if (aborted)
            {
                processForm.AppendText("\r\nAborted! Execution time: " + MainForm.formatSeconds((long)(ts.TotalSeconds)));
                MessageBox.Show(null, "Process aborted!", "Aborted!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                processForm.AppendText("\r\nFinished! Execution time: " + MainForm.formatSeconds((long)(ts.TotalSeconds)));
                MessageBox.Show(this, "Process finished!", "Finished!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.EnableComponents(true);
            processForm.canClose = true;
            progressBar.Value = 0;
            progressBar.ShowInTaskbar = false;
            progressBar.Style = ProgressBarStyle.Continuous;
            thread = null;
        }

        private void AppendResult(string result)
        {
            processForm.AppendText(result);
        }

        private void UpdateRow(int counter, Status.types type)
        {
            dataGridView.Rows[counter].Cells[COL_STATUS].Value = Status.getStateIcon(type);
        }

        public static string formatSeconds(long secs)
        {
            int hours, mins;
            hours = (int)(secs / 3600);
            secs %= 3600;
            mins = (int)(secs / 60);
            secs %= 60;
            return (hours < 10 ? "0" + hours.ToString() : hours.ToString()) + ":" +
                   (mins < 10 ? "0" + mins.ToString() : mins.ToString()) + ":" +
                   (secs < 10 ? "0" + secs.ToString() : secs.ToString());
        }

        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                contextMenuStrip.Show(dataGridView, e.Location);
            }
        }

        private void addFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogFiles.ShowDialog() == DialogResult.OK)
            {
                this.AddFiles(openFileDialogFiles.FileNames);
            }
        }

        private void deleteSelected() {
            progressBar.Maximum = dataGridView.SelectedRows.Count;
            progressBar.Value = 0;
            progressBar.ShowInTaskbar = true;
            EnableComponents(false);

            int counter = 0;
            for (int i = dataGridView.Rows.Count - 1; i >= 0; i--)
            {
                if (dataGridView.Rows[i].Selected)
                {
                    dataGridView.Rows.RemoveAt(i);
                    try
                    {
                        progressBar.Value = ++counter;
                    }
                    catch (ArgumentOutOfRangeException) { }

                    if (counter >= progressBar.Maximum)
                        break;

                }
                Application.DoEvents();
            }

            EnableComponents(true);
            progressBar.Value = 0;
            progressBar.ShowInTaskbar = false;
        }

        private void removeSelectedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.deleteSelected();
        }

        private void deleteAll() {
            EnableComponents(false);
            dataGridView.Rows.Clear();
            EnableComponents(true);
        }

        private void removeAllFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.deleteAll();
        }
    }
}
