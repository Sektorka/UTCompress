using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UTCompress
{
    public partial class ProcessForm : Form
    {
        public bool canClose;

        public ProcessForm()
        {
            InitializeComponent();
        }

        public void AppendText(string text)
        {
            this.tbResult.AppendText(text);
            this.tbResult.SelectionStart = this.tbResult.Text.Length;
            this.tbResult.ScrollToCaret();
        }

        public void EraseText() 
        {
            this.tbResult.Clear();
        }

        private void ProcessForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canClose)
            {
                e.Cancel = true;
                MessageBox.Show(this, "You can not close \"Process\" window while process is running!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
