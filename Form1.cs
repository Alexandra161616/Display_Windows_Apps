using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace mi_e_greu2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Acceseaza GetInstalledApps in Window Forms Constructor.  
            GetInstalledApps();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void GetInstalledApps()

        {
            int distanceUnit = 1;

            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"; //path ul bine cunoscut al aplicatiilor in windows

            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))

            {
                foreach (string skName in rk.GetSubKeyNames())
                { 
                    using (RegistryKey sk = rk.OpenSubKey(skName))  //asta permite accesul la subkeys(installed aplication entries)
                    {
                        

                        object displayName = sk.GetValue("DisplayName");
                        if (displayName != null)
                        {

                            Label lbl = new Label();
                            lbl.Top = distanceUnit * 30;
                            lbl.Height = 20;
                          
                            distanceUnit += 1;
                            lbl.Text = displayName.ToString();
                            panel1.Controls.Add(lbl);
                            
                        }
                    }

                }



            }

        }



      
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //scrii asta ca sa ai consola
        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        
    }
}
