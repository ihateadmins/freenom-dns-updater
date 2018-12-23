using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        bool loggedin = false;
        public Form1()
        {
            InitializeComponent();
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

        void update()
        {
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            lst_logs.Items.Add("logged in Phase 2");
            string[] formdata = {"records[0][name]", "records[0][value]", "records[1][name]", "records[1][value]"};
            string[] postdata = {subdomain0, ip0, subdomain1, ip1};

            if (webBrowser1.Document != null)
            {
                HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("input");
                foreach (HtmlElement elem in elems)
                {
                    String nameStr = elem.GetAttribute("name");

                    if (nameStr == formdata[0])//leer
                    {
                        webBrowser1.Document.GetElementById(nameStr).SetAttribute("value", postdata[0]);
                        lst_logs.Items.Add("Logging in");
                    }
                    else
                    {
                        if (nameStr == formdata[1])
                        {
                            webBrowser1.Document.GetElementById(nameStr).SetAttribute("value", postdata[1]);
                            HtmlElementCollection classButton = webBrowser1.Document.All;
                            foreach (HtmlElement element in classButton)
                            {
                                if (element.GetAttribute("className") == "smallBtn primaryColor")
                                {
                                    element.InvokeMember("click");
                                }
                            }
                        }
                    }
                }
            }
        }

        void login(string link)
        {
            //Browser vorbereiten
            webBrowser1.Visible = true;
            webBrowser1.ScriptErrorsSuppressed = true;
            //Website öffnen
            webBrowser1.Navigate(new Uri(link));
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            if (webBrowser1.Document != null)
            {
                HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("input");
                foreach (HtmlElement elem in elems)
                {
                    String nameStr = elem.GetAttribute("name");

                    if (nameStr == "username")
                    {
                        webBrowser1.Document.GetElementById(nameStr).SetAttribute("value", email);
                        lst_logs.Items.Add("Logging in");
                    }
                    else
                    {
                        if (nameStr == "password")
                        {
                            webBrowser1.Document.GetElementById(nameStr).SetAttribute("value", password);
                            HtmlElementCollection classButton = webBrowser1.Document.All;
                            foreach (HtmlElement element in classButton)
                            {
                                if (element.GetAttribute("className") == "largeBtn primaryColor pullRight")
                                {
                                    element.InvokeMember("click");
                                }
                            }

                            if (File.Exists("rawhtml.html"))
                            {
                                File.Delete("rawhtml.html");
                            }
                            string rawHtml = webBrowser1.DocumentText;//webBrowser1.Document.Body.OuterHtml;
                            string[] lines = { rawHtml };
                            System.IO.File.WriteAllLines("rawhtml.txt", lines);

                            //int j = Environment.TickCount;
                            //while (rawHtml.Contains("Sign in with your e-mail") || Environment.TickCount < j + 35000) ; //wait five seconds.. 
                            //while (webBrowser1.ReadyState != WebBrowserReadyState.Complete) Application.DoEvents();

                            if (rawHtml.Contains("Sign in with your e-mail") || rawHtml.Contains("Sign in"))
                            {
                                lst_logs.Items.Add("Sign in with your e - mail detected");
                            }
                            else
                            {
                                if (rawHtml.Contains("DNS MANAGEMENT for " + domain) || webBrowser1.Url == new Uri("https://my.freenom.com/clientarea.php?managedns="+ domain +"&domainid=" + domainid) )
                                {
                                    System.IO.File.WriteAllLines("rawhtml.html", lines);
                                    lst_logs.Items.Add("rawhtml.html created");
                                    lst_logs.Items.Add("Logged in");
                                    loggedin = true;
                                }
                                else
                                {
                                    lst_logs.Items.Add("exception no sign in detected");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            lst_logs.Items.Clear();
            readtextboxes();
            if (domainid == "")
            {
                System.Diagnostics.Process.Start(website);
                lst_logs.Items.Add("Website opened");
                lst_logs.Items.Add("login and open Manage Domain and enter your id from your url for Example: https://my.freenom.com/clientarea.php?managedns=ihateadmins.tk&domainid=1234567890");
                // MessageBox.Show("Manage Domain and enter id from your url, 1234567890 for Example: https://my.freenom.com/clientarea.php?managedns=ihateadmins.tk&domainid=1234567890");
            }
            else
            {   //https://my.freenom.com/clientarea.php?managedns=ihateadmins.tk&domainid=123456789
                website = "https://my.freenom.com/clientarea.php?managedns=" + domain + "&domainid=" + domainid;
                login(website);
                if(loggedin)
                {
                    webBrowser1.Navigate(new Uri(website));
                    update();
                }
                //System.Diagnostics.Process.Start(website);

                //webBrowser1.Visible = true;
                //webBrowser1.ScriptErrorsSuppressed = true;
                //webBrowser1.Url = new Uri(website);
                //webBrowser1.Navigate(new Uri(website));
                /*
                string postData = "username=" + email + "&password=" + password;
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                byte[] bytes = encoding.GetBytes(postData);
                webBrowser1.Navigate(website, string.Empty, bytes, "Content-Type: application/x-www-form-urlencoded");*/

                /*while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }*/
                //if (webBrowser1.Document != null)
                //{
                //    HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("input");
                //    foreach (HtmlElement elem in elems)
                //    {
                //        String nameStr = elem.GetAttribute("name");

                //        if (nameStr == "username")
                //        {
                //            webBrowser1.Document.GetElementById(nameStr).SetAttribute("value", email);
                //            lst_logs.Items.Add("Logging in");
                //        }
                //        else
                //        {
                //            if (nameStr == "password")
                //            {
                //                webBrowser1.Document.GetElementById(nameStr).SetAttribute("value", password);
                //                HtmlElementCollection classButton = webBrowser1.Document.All;
                //                foreach (HtmlElement element in classButton)
                //                {
                //                    if (element.GetAttribute("className") == "largeBtn primaryColor pullRight")
                //                    {
                //                        element.InvokeMember("click");
                //                        break;
                //                    }
                //                }

                //            if (File.Exists("rawhtml.html"))
                //            {
                //                File.Delete("rawhtml.html");
                //            }
                //            string rawHtml = webBrowser1.DocumentText;//webBrowser1.Document.Body.OuterHtml;
                //            string[] lines = {rawHtml};
                //            System.IO.File.WriteAllLines("rawhtml.txt", lines);

                //            if (rawHtml.Contains("Sign in with your e-mail"))
                //            {
                //                lst_logs.Items.Add("Sign in with your e - mail detected");
                //            }
                //            else
                //            {
                //                lst_logs.Items.Add("exception no sign in");
                //                if (rawHtml.Contains("DNS MANAGEMENT for ihateadmins.tk"))
                //                {
                //                    System.IO.File.WriteAllLines("rawhtml.html", lines);
                //                    lst_logs.Items.Add("rawhtml.html created");
                //                    lst_logs.Items.Add("Logged in");
                //                    loggedin = true;
                //                    break;
                //                }
                //            }

                //            if (loggedin)
                //            {
                //                lst_logs.Items.Add("Phase 2");
                //                    //break;
                //                    if (nameStr == "records[0][name]")//leer
                //                    {
                //                        //webBrowser1.Document.GetElementById(nameStr).SetAttribute("value", subdomain1);
                //                        webBrowser1.Document.GetElementById(nameStr).SetAttribute("value", "plskappa");
                //                        lst_logs.Items.Add("subdomain1 updated");
                //                    }
                //                    else
                //                    {
                //                        lst_logs.Items.Add("error");
                //                        if (nameStr == "records[1][value]")
                //                        {
                //                            webBrowser1.Document.GetElementById(nameStr).SetAttribute("value", ip1);
                //                            lst_logs.Items.Add("subdomain1 ip updated");
                //                            //HtmlElementCollection classButton = webBrowser1.Document.All;
                //                            //foreach (HtmlElement element in classButton)
                //                            //{
                //                            //    if (element.GetAttribute("className") == "smallBtn primaryColor")
                //                            //    {
                //                            //        element.InvokeMember("click");
                //                            //        lst_logs.Items.Add("row updated");
                //                            //        updated = true;
                //                            //        break;
                //                            //    }
                //                            //}
                //                            //lst_logs.Items.Add("Phase 3 bye");
                //                            //if (updated)
                //                            //    break;
                //                        }
                //                    }
                //                }

                //            }
                //        }
                //    }
                //}


                //var client = new HttpClient();
                //var pairs = new List<KeyValuePair<string, string>>
                //{
                //new KeyValuePair<string, string>("username", email),
                //new KeyValuePair<string, string>("password", password)
                //};

                //var content = new FormUrlEncodedContent(pairs);
                //var response = client.PostAsync(website, content).Result;
                ///*if (response.IsSuccessStatusCode)
                //{
                //}*/
                //string[] lines = { response.ToString() };
                //System.IO.File.WriteAllLines("response.html", lines);

                //var pairs2 = new List<KeyValuePair<string, string>>
                //{
                //new KeyValuePair<string, string>("records[0][name]", subdomain0),
                //new KeyValuePair<string, string>("records[0][value]", ip0),
                //new KeyValuePair<string, string>("records[1][name]", subdomain1),
                //new KeyValuePair<string, string>("records[1][value]", ip1)
                //};
                //var content2 = new FormUrlEncodedContent(pairs2);
                //var response2 = client.PostAsync(website, content2).Result;
                //string[] lines2 = { response2.ToString() };
                //System.IO.File.WriteAllLines("response2.html", lines2);



                //string[] lines = {result};
                //System.IO.File.WriteAllLines(config, lines);
                //anmelden
                //sendRequest(website, "POST", String.Format("username={0}&password={1}", email, password));
                //update eintrag
                //sendRequest(website, "POST", String.Format("records[0][name]={0} & records[0][value]={1} & records[1][name]={2} & records[1][value]={3}", subdomain0, ip0, subdomain1, ip1));
                //var client = new WebClient();
                //client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 7.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                //var content = client.DownloadString(website);
            }
        }
    }
}
