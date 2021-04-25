using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HadoopOnUbuntu
{
    public partial class Form1 : Form
    {
        String nameContainer_master= "bold_mccarthy";
        String nameContainer_slave = "vibrant_wiles";
        String nameImage_master = "m2:20.04";
        String nameImage_slave = "slave2:20.04";
        public Form1()
        {
            InitializeComponent();
        }
        public void checkStatusContainer(String name)
        {
            String cmdText = "docker ps --filter "+"\"name = "+ name + "\"";
            int result = cmdText.ToString().Split('\n').Length ;
            if (result == 1)
            {
                lbStatus.Text = "Running";
            }
            else//0
            {
                lbStatus.Text = "Stop";
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            String cmdText = "docker start bold_mccarthy ";
            ExeCommand(cmdText);
            checkStatusContainer("bold_mccarthy");
        }
        public string ExeCommand(object cmd)
        {
            ProcessStartInfo proc = new ProcessStartInfo("cmd", "/c" + cmd);
            proc.RedirectStandardOutput = true;
            proc.RedirectStandardError = true;//bật hiện lỗi cmd
            proc.UseShellExecute = false;
            proc.CreateNoWindow = true; //không hiển thị cửa sổ cmd
            Process p = new Process();
            p.StartInfo = proc;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            //in lỗi nếu có
            string err = p.StandardError.ReadToEnd();
            tbOutput.Visible = true;
            tbOutput.Text = err;

            return output;
        }

    }
}
