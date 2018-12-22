using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freenom_Dns_Updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string email, password, subdomain0, subdomain1, domainid, ip0, ip1, version;

            var client = new WebClient();
            var content = client.DownloadString("http://example.com");
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_change_Click(object sender, EventArgs e)
        {

        }
    }
}
