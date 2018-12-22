using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freenom_Dns_Updater
{
    public partial class Form1 : Form
    {
        string email, password, subdomain0, subdomain1, domain, domainid, ip0, ip1, version;
        string website = "https://my.freenom.com/clientarea.php?action=domains";
        string config = "freenom.cfg";
        public Form1()
        {
            InitializeComponent();

            var client = new WebClient();
            var content = client.DownloadString("http://example.com");
            version = Application.ProductVersion.ToString();
            lbl_version.Text = version;

            if (File.Exists(config))
            {
                if (!(new FileInfo(config).Length == 0))
                {
                    string[] lines = File.ReadAllLines(config);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        //lst_logs.Items.Add(lines[i]);
                        txt_email.Text = lines[0];
                        txt_password.Text = lines[1];
                        txt_sub_domain0.Text = lines[2];
                        txt_sub_domain1.Text = lines[3];
                        txt_domain.Text = lines[4];
                        txt_domain_id.Text = lines[5];
                        txt_ip0.Text = lines[6];
                        txt_ip1.Text = lines[7];
                    }
                }
                else
                {
                    File.Delete(config);
                }
            }
            else
            {

                MessageBox.Show(Directory.GetCurrentDirectory()+" "+ config + " not found. Press Save to create the config");
            }

        }

        void readtextboxes()
        {
            email = txt_email.Text;
            password = txt_password.Text;
            subdomain0 = txt_sub_domain0.Text;
            subdomain1 = txt_sub_domain1.Text;
            domain = txt_domain.Text;
            domainid = txt_domain_id.Text;
            ip0 = txt_ip0.Text;
            ip1 = txt_ip1.Text;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //create freenom.cfg
            readtextboxes();

            if (File.Exists(config))
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to override the current config?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string[] lines = { email,password,subdomain0,subdomain1,domain,domainid,ip0,ip1 };
                    System.IO.File.WriteAllLines(config, lines);
                }
            }
            else
            {
                string[] lines = { email, password, subdomain0, subdomain1, domain, domainid, ip0, ip1 };
                System.IO.File.WriteAllLines(config, lines);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            lst_logs.Items.Clear();
            readtextboxes();
            if (domainid == "")
            {
                System.Diagnostics.Process.Start(website);
                lst_logs.Items.Add("login and open Manage Domain and enter your id from your url for Example: https://my.freenom.com/clientarea.php?managedns=ihateadmins.tk&domainid=1234567890");
                // MessageBox.Show("Manage Domain and enter id from your url, 1234567890 for Example: https://my.freenom.com/clientarea.php?managedns=ihateadmins.tk&domainid=1234567890");
            }
            else
            {//https://my.freenom.com/clientarea.php?managedns=ihateadmins.tk&domainid=123456789
                website = "https://my.freenom.com/clientarea.php?managedns=" + domain + "&domainid=" + domainid;
                System.Diagnostics.Process.Start(website);
            }
        }
    }
}
