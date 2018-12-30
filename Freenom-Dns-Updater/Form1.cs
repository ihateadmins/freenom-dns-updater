using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Gecko;
using Gecko.DOM;
using Gecko.Events;

namespace Freenom_Dns_Updater
{
    public partial class Form1 : Form
    {
        string email, password, subdomain0, subdomain1, domain, domainid, ip0, ip1, version;
        string website = "https://my.freenom.com/clientarea.php?action=domains";
        string config = "freenom.cfg";
        bool loggedin = false;
        int pagenumber;
        bool execute = true;
        int timebuffer_minuteb;
        bool timetrigger = true;
        int futuretime;
        GeckoWebBrowser browser = new GeckoWebBrowser { Dock = DockStyle.Fill };

        public Form1()
        {
            InitializeComponent();
            Xpcom.EnableProfileMonitoring = false;
            Xpcom.Initialize("Firefox");
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
                lst_logs.Items.Add(Directory.GetCurrentDirectory() + " " + config + " not found. Press Save to create the config");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tab_browser.Controls.Add(browser);
            Task mytask = Task.Run(() =>
            {
                get_dns_ip_loop();
                MethodInvoker inv = delegate
                {
                    this.lbl_dns_ip_value.Text = domain + " | " + Dns.GetHostAddresses(domain).ToString();
                    this.lst_logs.Items.Add(Dns.GetHostAddresses(domain)[0].ToString());
                };
                this.Invoke(inv);
                lst_logs.Items.Add("loop end");
            });
        }
        
        void get_dns_ip_loop()
        {
            while (true)
            {
                //string time = DateTime.Now.ToString("HH:mm:ss");
                
                int time_minute = DateTime.Now.Minute;
                if (timetrigger)
                {
                    timebuffer_minuteb = DateTime.Now.Minute;
                    timetrigger = false;
                }

                if(timebuffer_minuteb >= 58)
                {
                    futuretime = timebuffer_minuteb - 58;
                }
                else
                {
                    futuretime = timebuffer_minuteb;
                }
                if (time_minute >= 58)
                {
                    time_minute -= 59;
                }

                //if (time_minute > futuretime +1)
                if (time_minute > futuretime)
                {
                    MethodInvoker inv = delegate
                    {
                        this.browser.DocumentCompleted += this.OnDocumentCompleted;
                        this.detectpage();
                        //this.lst_logs.Items.Add("current ip: " + Dns.GetHostAddresses("ihateadmins.tk")[0].ToString());
                        this.lst_logs.Items.Add("current ip: " + Dns.GetHostAddresses(this.txt_domain.Text)[0].ToString());
                        this.lbl_dns_ip_value.Text = this.txt_domain.Text + " | " + Dns.GetHostAddresses(this.txt_domain.Text)[0].ToString();
                    };
                    this.Invoke(inv);
                    timetrigger = true;
                }
                //t2.Stop();
                //}
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
                    lst_logs.Items.Add("config overriden");
                }
            }
            else
            {
                string[] lines = { email, password, subdomain0, subdomain1, domain, domainid, ip0, ip1 };
                System.IO.File.WriteAllLines(config, lines);
                lst_logs.Items.Add("config created");
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool pageloaded;

        private void btn_folder_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath.ToString());
        }

        private void OnDocumentCompleted(object sender, GeckoDocumentCompletedEventArgs e)
        {
            pageloaded = true;
        }

        bool error_display = true;
        void freenom_responses(object sender, EventArgs e)
        {
            if (error_display)
            {
                string[] freenom_responses = { "Record modified successfully", "There were no changes", "Error occured: Invalid value in dnsrecord", "" };
                //There were no changes
                //Error occured: Invalid value in dnsrecord
                //Record modified successfully

                //var dnserror0 = new GeckoInputElement(browser.Document.GetElementsByClassName("dnserror")[0].DomObject);
                //var dnserror1 = new GeckoInputElement(browser.Document.GetElementsByClassName("dnserror")[1].DomObject);
                if (browser.Document.Body.OuterHtml.Contains("Record modified successfully"))
                {
                    lst_logs.Items.Add("Record modified successfully");
                }

                if (browser.Document.Body.OuterHtml.Contains("There were no changes"))
                {
                    lst_logs.Items.Add("There were no changes");
                }

                if (browser.Document.Body.OuterHtml.Contains("Error occured: Invalid value in dnsrecord"))
                {
                    lst_logs.Items.Add("Error occured: Invalid value in dnsrecord");
                }
                error_display = false;
            }
        }

        void detectpage()//1=login page , 2=dns-managment page
        {
            if (File.Exists("rawhtml.html")){File.Delete("rawhtml.html");}
            string rawHtml = browser.Document.Body.OuterHtml;//webBrowser1.Document.Body.OuterHtml;
            //string[] lines = { rawHtml };
            //System.IO.File.WriteAllLines("rawhtml.txt", lines);
            if (rawHtml.Contains("Sign in with your e-mail") || rawHtml.Contains("Sign in"))
            {
                lst_logs.Items.Add("Sign in with your e - mail detected");
                pagenumber = 1;
            }
            else
            {
                if (rawHtml.Contains("DNS MANAGEMENT for " + domain))
                {
                    if (!execute)
                    {
                        lst_logs.Items.Add("Updating Freenom DNS can take up to 5min");
                    }
                    else
                    {
                        //System.IO.File.WriteAllLines("rawhtml.html", lines);
                        lst_logs.Items.Add("DNS MANAGEMENT for " + domain + " page");
                        loggedin = true;
                        pagenumber = 2;
                    }
                    if (rawHtml.Contains("dnserror") && loggedin)
                    {
                        System.Windows.Forms.Timer t3 = new System.Windows.Forms.Timer();
                        //to stop The Timer: t.Stop();
                        t3.Interval = 100;
                        t3.Tick += new EventHandler(freenom_responses);
                        t3.Start();
                        if (error_display == false)
                        {
                            t3.Stop();
                        }
                    }
                }
                else
                {
                    lst_logs.Items.Add("exception no sign in detected");
                }
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (execute)
            {
                var dnschangebutton = new GeckoInputElement(browser.Document.GetElementsByClassName("smallBtn primaryColor")[1].DomObject);
                dnschangebutton.Click();
                lst_logs.Items.Add("dns changed...");
                execute = false;
            }
        }

        void update()
        {
            browser.DocumentCompleted += OnDocumentCompleted;
            detectpage();
            if (pagenumber == 2)//loginpage
            {
                string[] formdata = { "records[0][name]", "records[0][value]", "records[1][name]", "records[1][value]" };
                string[] postdata = { subdomain0, ip0, subdomain1, ip1 };

                var browser_entry_subdomain0 = new GeckoInputElement(browser.Document.GetElementsByName(formdata[0])[0].DomObject);
                browser_entry_subdomain0.Value = postdata[0];
                lst_logs.Items.Add("subdomain0 entered");

                var browser_entry_ip0 = new GeckoInputElement(browser.Document.GetElementsByName(formdata[1])[0].DomObject);
                browser_entry_ip0.Value = postdata[1];
                lst_logs.Items.Add("ip0 entered");

                var browser_entry_subdomain1 = new GeckoInputElement(browser.Document.GetElementsByName(formdata[2])[0].DomObject);
                browser_entry_subdomain1.Value = postdata[2];
                lst_logs.Items.Add("subdomain1 entered");

                var browser_entry_ip1 = new GeckoInputElement(browser.Document.GetElementsByName(formdata[3])[0].DomObject);
                browser_entry_ip1.Value = postdata[3];
                lst_logs.Items.Add("ip1 entered");

                System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
                //to stop The Timer: t.Stop();
                t.Interval = 2000; // specify interval time as you want
                t.Tick += new EventHandler(timer_Tick);
                t.Start();
                if(execute == false)
                {
                    t.Stop();
                    execute = true;
                }

            }
        }

        void login()
        {
            //webBrowser1.ScriptErrorsSuppressed = true;
            //Website öffnen
            //webBrowser1.Navigate(new Uri(link));

            browser.DocumentCompleted += OnDocumentCompleted;
            if (pageloaded)
            {
                pageloaded = false;
                detectpage();
                if (pagenumber == 1)//loginpage
                {
                    lst_logs.Items.Add("page loaded - ready");
                    /*if (cb_remember.Checked)
                    {
                        var browser_login_rememberme = new GeckoInputElement(browser.Document.GetElementById("rememberMe").DomObject);
                        browser_login_rememberme.Click();
                        lst_logs.Items.Add("remember me checked");
                    }*/
                    var browser_login_id = new GeckoInputElement(browser.Document.GetElementById("username").DomObject);
                    //new GeckoInputElement(browser.Document.GetElementsByName("username")[0].DomObject).Value = email;
                    browser_login_id.Value = email;
                    lst_logs.Items.Add("entered login");

                    var browser_login_pw = new GeckoInputElement(browser.Document.GetElementById("password").DomObject);
                    browser_login_pw.Value = password;
                    lst_logs.Items.Add("entered password");

                    var buttonAnmelden = new GeckoInputElement(browser.Document.GetElementsByClassName("largeBtn primaryColor pullRight")[0].DomObject);
                    buttonAnmelden.Click();
                    lst_logs.Items.Add("Logging in...");
                }
                else
                {
                    if (pagenumber == 2 && loggedin)//dns-managment
                    {
                        update();
                    }
                    else
                    {
                        lst_logs.Items.Add("exception pagenumber unknown:" + pagenumber);
                    }
                }
            }
            else
            {
                browser.Navigate(website);
                lst_logs.Items.Add("page not loaded");
            }
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            lst_logs.Items.Clear();
            readtextboxes();
            //lst_logs.Items.Add("Started loop");
            //Task mytask = Task.Run(() =>
            //{
            /*MethodInvoker inv = delegate
            {
                this.lst_logs.Items.Add(Dns.GetHostAddresses("ihateadmins.tk")[0].ToString());
            };
            this.Invoke(inv);*/

            //get_dns_ip_loop();
            //lst_logs.Items.Add("loop end");
            //});
            //lst_logs.Items.Add(Dns.GetHostAddresses("ihateadmins.tk")[0].ToString());

            if (domainid == "" || domainid=="1234567890")
            {
                System.Diagnostics.Process.Start(website);
                lst_logs.Items.Add("Website opened");
                lst_logs.Items.Add("login and open Manage Domain and enter your id from your url for Example: https://my.freenom.com/clientarea.php?managedns=ihateadmins.tk&domainid=1234567890");
                // MessageBox.Show("Manage Domain and enter id from your url, 1234567890 for Example: https://my.freenom.com/clientarea.php?managedns=ihateadmins.tk&domainid=1234567890");
            }
            else
            {   //https://my.freenom.com/clientarea.php?managedns=ihateadmins.tk&domainid=123456789
                website = "https://my.freenom.com/clientarea.php?managedns=" + domain + "&domainid=" + domainid;
                login();
            }
        }
    }
}
