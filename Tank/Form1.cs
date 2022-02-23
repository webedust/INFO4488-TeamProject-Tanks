﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    public partial class Form1 : Form
    {
        Tank player;
        public Form1()
        {
            InitializeComponent();
            // Must be true for user input to work.
            KeyPreview = true;

            GameHandler gh = new(this);
            player = gh.Player;
        }
        void GameTimer_Tick(object sender, EventArgs e)
        {
            if (player.playerHealth > 1)
            {
                healthBar.Value = (int)player.playerHealth;
            }
            //Need to add gameover logic here
            else
            {
                player.gameOver = true;
            }


            //Movement breaks in the if statement since the player.goLeft is never true.
            //However if the player.goLeft is set to false,
            //the player tank then begins to move across the screen, without user input.
            if (player.goLeft == true && playerTank.Left > 0)
            {
                player.PlayerMove(Tank.Directions.Left);
            }
            if (player.goRight == true && playerTank.Left < this.ClientSize.Width)
            {
                player.PlayerMove(Tank.Directions.Right);
            }
            if (player.goUp == true && playerTank.Top > 0)
            {
                player.PlayerMove(Tank.Directions.Up);
            }
            if (player.goDown == true && playerTank.Left < this.ClientSize.Height)
            {
                player.PlayerMove(Tank.Directions.Down);
            }
        }
        void KeyIsDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine($"Key pressed is {e.KeyCode}");
            //The panel back color changing is for testing purposes.
            panel1.BackColor = Color.Black;
            switch (e.KeyCode)
            {
                case Keys.A:
                    panel1.BackColor = Color.Red;

                    player.goLeft = true;
                    player.direction = "left";
                    playerTank.Image = Properties.Resources.PlayerTankLeft;
                    break;

                case Keys.D:
                    panel1.BackColor = Color.Blue;

                    player.goRight = true;
                    player.direction = "right";
                    playerTank.Image= Properties.Resources.PlayerTankRight;
                    break;

                case Keys.W:
                    panel1.BackColor = Color.Yellow;

                    player.goUp = true;
                    player.direction = "up";
                    playerTank.Image = Properties.Resources.PlayerTankUp;
                    break;

                case Keys.S:
                    panel1.BackColor = Color.Green;

                    player.goDown = true;
                    player.direction = "down";
                    playerTank.Image = Properties.Resources.PlayerTankDown;
                    break;
            }
        }
        void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    player.goLeft = false;
                    break;

                case Keys.D:
                    player.goRight = false;
                    break;

                case Keys.W:
                    player.goUp = false;
                    break;

                case Keys.S:
                    player.goDown = false;
                    break;
                case Keys.Space:
                    player.Shoot(player.direction);
                    break;
            }
        }
    }
}
