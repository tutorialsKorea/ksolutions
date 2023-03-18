using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using ControlManager;
using Microsoft.Win32;

namespace LogInForm
{
    public sealed partial class WebView : BaseMenu
    {
        public override void BarCodeScanInput(string barcode)
        {


        }

        public WebView()
        {            
            string strWebViewPath = string.Empty;
            if(!Getinstalledsoftware("Microsoft Edge WebView2"))
            {
                MemoryStream ms = new MemoryStream(Resource.MicrosoftEdgeWebview2Setup);                

                //FileStream fs = new FileStream("DRM.zip",
                FileStream fs = new FileStream("MicrosoftEdgeWebview2Setup.exe", FileMode.Create, FileAccess.ReadWrite);                

                ms.WriteTo(fs);

                fs.Close();

                ms.Close();                

                Process p = new Process();

                p.StartInfo.FileName = "MicrosoftEdgeWebview2Setup.exe";

                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                p.Start();

                p.WaitForExit();                

            }

            InitializeComponent();
        }

        private bool Getinstalledsoftware(string programName)
        {
            //Declare the string to hold the list:
            //string Software = null;

            //The registry key:
            string SoftwareKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(SoftwareKey))
            {
                //Let's go through the registry keys and get the info we need:
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            //If the key has value, continue, if not, skip it:
                            if (!(sk.GetValue("DisplayName") == null))
                            {
                                //Is the install location known?
                                //if (sk.GetValue("InstallLocation") == null)
                                //    Software += sk.GetValue("DisplayName") + " - Install path not known\n"; //Nope, not here.
                                //else
                                //    Software += sk.GetValue("DisplayName") + " - " + sk.GetValue("InstallLocation") + "\n"; //Yes, here it is...

                                if(sk.GetValue("DisplayName").ToString().Contains(programName))
                                {
                                    return true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //No, that exception is not getting away... :P
                        }
                    }
                }
            }

            return false;
        }

        private string url = string.Empty;

        public string URL
        {
            set
            {
                this.webView21.Source = new System.Uri(value, System.UriKind.Absolute);
                url = value;
            }

            get
            {
                return url;
            }
        }

        //public WebView(string url)
        //{
        //    InitializeComponent();

        //    this.webView21.Source = new System.Uri(url, System.UriKind.Absolute);
        //}


        public override void MenuInit()
        {
            try
            {
                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public override bool MenuDestory(object sender)
        {

            return base.MenuDestory(sender);
        }

        public override void MenuGotFocus()
        {
            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {
            base.MenuLostFocus();
        }

    }

}
