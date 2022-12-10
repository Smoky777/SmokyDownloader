using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace DownloaderForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                WebClient webc = new WebClient();

                string url = "https://the.earth.li/~sgtatham/putty/latest/w64/putty.exe";
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "putty.exe");


                webc.DownloadFile(url, path);
                webc.Dispose();

                Thread.Sleep(4000);
                Process.Start(path);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                string url1 = "https://download.teamviewer.com/download/TeamViewer_Setup_x64.exe";
                string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeamViewer_Setup_x64.exe");

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                WebClient webcc = new WebClient();
                webcc.DownloadFile(url1, filename);
                webcc.Dispose();

                Thread.Sleep(15000);

                Process.Start(filename);

                Environment.Exit(0);
            }
        }
        
    }
    
}
