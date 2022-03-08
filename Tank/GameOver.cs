using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }
        MainMenu frm = new MainMenu();


        private void btnReturn_Click(object sender, EventArgs e)
        {
            frm.Show();
            this.Close();
        }


    }
}
