using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace BSC_System
{
    public partial class PC32 : Form
    {
        string CKDH = "";
        public PC32()
        {
            InitializeComponent();            
        }
        private void button1_Click(object sender, EventArgs e)
        {
          //  CKDH = TxtCKDH.Text.ToString().Trim();
            //PC22 pc22 = new PC22();


            //Form fr = Application.OpenForms["PC22"];
            //if (fr != null)
            //{ 
            //   ((PC22)fr).CKDH = CKDH;                
            //}
           
            this.Close();
        }

        private void PC32_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                CKDH = TxtCKDH.Text.ToString().Trim();
                Form fr = Application.OpenForms["PC22"];
                if (fr != null)
                {
                    ((PC22)fr).CKDH = CKDH;                   
                }
            }
            catch
            { }
            //this.Close();
        }

        private void TxtCKDH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Keys.Enter)||e.KeyChar.Equals('\r'))
            {
                button1.PerformClick();
            }
        }
    }
}
