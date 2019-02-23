using System;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Diagnostics;


namespace Main
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Main.Login login = null;

            
                login = new Main.Login();

                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Forms.Start());
                }

                login.Disposed += delegate { login.Dispose(); };
          
        }
    }
}
