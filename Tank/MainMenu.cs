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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }


        private void btnStartGame_Click(object sender, EventArgs e)
        {
            Form1 frm  = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInstructions_Click(object sender, EventArgs e)
        {
            Instructions frm = new Instructions();
            frm.Show();
            this.Hide();
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            Credits frm = new Credits();
            frm.Show();
            this.Hide();
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                MainMenu frm = new MainMenu();
                frm.Show();
                this.Close();
            }
        }
    }
}
