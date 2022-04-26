
namespace Tank
{
    partial class Map
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.healthLabel = new System.Windows.Forms.Label();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.playerTank = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblKills = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.pictureBox23 = new System.Windows.Forms.PictureBox();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.pictureBox25 = new System.Windows.Forms.PictureBox();
            this.pictureBox26 = new System.Windows.Forms.PictureBox();
            this.pictureBox27 = new System.Windows.Forms.PictureBox();
            this.pictureBox28 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.playerTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).BeginInit();
            this.SuspendLayout();
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.healthLabel.Location = new System.Drawing.Point(12, 9);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(61, 21);
            this.healthLabel.TabIndex = 0;
            this.healthLabel.Text = "Health";
            // 
            // healthBar
            // 
            this.healthBar.Location = new System.Drawing.Point(79, 9);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(159, 23);
            this.healthBar.TabIndex = 1;
            this.healthBar.Value = 100;
            // 
            // playerTank
            // 
            this.playerTank.BackColor = System.Drawing.Color.Transparent;
            this.playerTank.Image = global::Tank.Properties.Resources.PlayerTankUp;
            this.playerTank.Location = new System.Drawing.Point(552, 356);
            this.playerTank.Name = "playerTank";
            this.playerTank.Size = new System.Drawing.Size(50, 75);
            this.playerTank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerTank.TabIndex = 2;
            this.playerTank.TabStop = false;
            this.playerTank.Tag = "Tank";
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Tank.Properties.Resources.Rock;
            this.pictureBox1.InitialImage = global::Tank.Properties.Resources.Rock;
            this.pictureBox1.Location = new System.Drawing.Point(857, 221);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "Rock";
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Tank.Properties.Resources.Rock;
            this.pictureBox2.InitialImage = global::Tank.Properties.Resources.Rock;
            this.pictureBox2.Location = new System.Drawing.Point(346, 452);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "Rock";
            this.pictureBox2.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Tank.Properties.Resources.Rock;
            this.pictureBox3.InitialImage = global::Tank.Properties.Resources.Rock;
            this.pictureBox3.Location = new System.Drawing.Point(209, 84);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(110, 93);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "Rock";
            this.pictureBox3.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Tank.Properties.Resources.Rock;
            this.pictureBox4.InitialImage = global::Tank.Properties.Resources.Rock;
            this.pictureBox4.Location = new System.Drawing.Point(1005, 581);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(98, 53);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "Rock";
            this.pictureBox4.Visible = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::Tank.Properties.Resources.Rock;
            this.pictureBox5.InitialImage = global::Tank.Properties.Resources.Rock;
            this.pictureBox5.Location = new System.Drawing.Point(779, 176);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(62, 93);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Tag = "Rock";
            this.pictureBox5.Visible = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::Tank.Properties.Resources.Rock;
            this.pictureBox6.InitialImage = global::Tank.Properties.Resources.Rock;
            this.pictureBox6.Location = new System.Drawing.Point(820, 534);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(98, 53);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Tag = "Rock";
            this.pictureBox6.Visible = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::Tank.Properties.Resources.Rock;
            this.pictureBox7.InitialImage = global::Tank.Properties.Resources.Rock;
            this.pictureBox7.Location = new System.Drawing.Point(665, 433);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(98, 53);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 9;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Tag = "Rock";
            this.pictureBox7.Visible = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Image = global::Tank.Properties.Resources.Rock;
            this.pictureBox8.InitialImage = global::Tank.Properties.Resources.Rock;
            this.pictureBox8.Location = new System.Drawing.Point(1044, 84);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(59, 62);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 10;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Tag = "Rock";
            this.pictureBox8.Visible = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox9.Image = global::Tank.Properties.Resources.Rock;
            this.pictureBox9.InitialImage = global::Tank.Properties.Resources.Rock;
            this.pictureBox9.Location = new System.Drawing.Point(127, 378);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(111, 53);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 11;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Tag = "Rock";
            this.pictureBox9.Visible = false;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLevel.Location = new System.Drawing.Point(244, 11);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(58, 21);
            this.lblLevel.TabIndex = 12;
            this.lblLevel.Tag = "level";
            this.lblLevel.Text = "Level: ";
            // 
            // lblKills
            // 
            this.lblKills.AutoSize = true;
            this.lblKills.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKills.Location = new System.Drawing.Point(327, 11);
            this.lblKills.Name = "lblKills";
            this.lblKills.Size = new System.Drawing.Size(50, 21);
            this.lblKills.TabIndex = 13;
            this.lblKills.Tag = "kills";
            this.lblKills.Text = "Kills: ";
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Location = new System.Drawing.Point(536, 203);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(100, 50);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 14;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Tag = "Rock2";
            this.pictureBox10.Visible = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox11.Location = new System.Drawing.Point(414, 176);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(84, 104);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 15;
            this.pictureBox11.TabStop = false;
            this.pictureBox11.Tag = "Rock2";
            this.pictureBox11.Visible = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Location = new System.Drawing.Point(613, 109);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(57, 160);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 16;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Tag = "Rock2";
            this.pictureBox12.Visible = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox13.Location = new System.Drawing.Point(150, 518);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(152, 59);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 17;
            this.pictureBox13.TabStop = false;
            this.pictureBox13.Tag = "Rock2";
            this.pictureBox13.Visible = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox14.Location = new System.Drawing.Point(692, 567);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(57, 55);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox14.TabIndex = 18;
            this.pictureBox14.TabStop = false;
            this.pictureBox14.Tag = "Rock2";
            this.pictureBox14.Visible = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Location = new System.Drawing.Point(847, 31);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(139, 146);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox15.TabIndex = 19;
            this.pictureBox15.TabStop = false;
            this.pictureBox15.Tag = "Rock2";
            this.pictureBox15.Visible = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox16.Location = new System.Drawing.Point(104, 122);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(84, 104);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox16.TabIndex = 20;
            this.pictureBox16.TabStop = false;
            this.pictureBox16.Tag = "Rock3";
            this.pictureBox16.Visible = false;
            // 
            // pictureBox17
            // 
            this.pictureBox17.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox17.Location = new System.Drawing.Point(978, 382);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(84, 170);
            this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox17.TabIndex = 21;
            this.pictureBox17.TabStop = false;
            this.pictureBox17.Tag = "Rock3";
            this.pictureBox17.Visible = false;
            // 
            // pictureBox18
            // 
            this.pictureBox18.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox18.Location = new System.Drawing.Point(433, 42);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(142, 104);
            this.pictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox18.TabIndex = 22;
            this.pictureBox18.TabStop = false;
            this.pictureBox18.Tag = "Rock3";
            this.pictureBox18.Visible = false;
            // 
            // pictureBox19
            // 
            this.pictureBox19.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox19.Location = new System.Drawing.Point(518, 452);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(66, 135);
            this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox19.TabIndex = 23;
            this.pictureBox19.TabStop = false;
            this.pictureBox19.Tag = "Rock3";
            this.pictureBox19.Visible = false;
            // 
            // pictureBox20
            // 
            this.pictureBox20.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox20.Location = new System.Drawing.Point(793, 324);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(48, 86);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox20.TabIndex = 24;
            this.pictureBox20.TabStop = false;
            this.pictureBox20.Tag = "Rock3";
            this.pictureBox20.Visible = false;
            // 
            // pictureBox21
            // 
            this.pictureBox21.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox21.Location = new System.Drawing.Point(209, 404);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(110, 87);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox21.TabIndex = 25;
            this.pictureBox21.TabStop = false;
            this.pictureBox21.Tag = "Rock3";
            this.pictureBox21.Visible = false;
            // 
            // pictureBox22
            // 
            this.pictureBox22.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox22.Location = new System.Drawing.Point(104, 295);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(118, 45);
            this.pictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox22.TabIndex = 26;
            this.pictureBox22.TabStop = false;
            this.pictureBox22.Tag = "Rock4";
            this.pictureBox22.Visible = false;
            // 
            // pictureBox23
            // 
            this.pictureBox23.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox23.Location = new System.Drawing.Point(847, 286);
            this.pictureBox23.Name = "pictureBox23";
            this.pictureBox23.Size = new System.Drawing.Size(71, 94);
            this.pictureBox23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox23.TabIndex = 27;
            this.pictureBox23.TabStop = false;
            this.pictureBox23.Tag = "Rock4";
            this.pictureBox23.Visible = false;
            // 
            // pictureBox24
            // 
            this.pictureBox24.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox24.Location = new System.Drawing.Point(327, 132);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Size = new System.Drawing.Size(51, 94);
            this.pictureBox24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox24.TabIndex = 28;
            this.pictureBox24.TabStop = false;
            this.pictureBox24.Tag = "Rock4";
            this.pictureBox24.Visible = false;
            // 
            // pictureBox25
            // 
            this.pictureBox25.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox25.Location = new System.Drawing.Point(346, 534);
            this.pictureBox25.Name = "pictureBox25";
            this.pictureBox25.Size = new System.Drawing.Size(32, 115);
            this.pictureBox25.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox25.TabIndex = 29;
            this.pictureBox25.TabStop = false;
            this.pictureBox25.Tag = "Rock4";
            this.pictureBox25.Visible = false;
            // 
            // pictureBox26
            // 
            this.pictureBox26.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox26.Location = new System.Drawing.Point(793, 507);
            this.pictureBox26.Name = "pictureBox26";
            this.pictureBox26.Size = new System.Drawing.Size(118, 45);
            this.pictureBox26.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox26.TabIndex = 30;
            this.pictureBox26.TabStop = false;
            this.pictureBox26.Tag = "Rock4";
            this.pictureBox26.Visible = false;
            // 
            // pictureBox27
            // 
            this.pictureBox27.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox27.Location = new System.Drawing.Point(904, 42);
            this.pictureBox27.Name = "pictureBox27";
            this.pictureBox27.Size = new System.Drawing.Size(199, 94);
            this.pictureBox27.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox27.TabIndex = 31;
            this.pictureBox27.TabStop = false;
            this.pictureBox27.Tag = "Rock4";
            this.pictureBox27.Visible = false;
            // 
            // pictureBox28
            // 
            this.pictureBox28.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox28.Location = new System.Drawing.Point(391, 295);
            this.pictureBox28.Name = "pictureBox28";
            this.pictureBox28.Size = new System.Drawing.Size(127, 75);
            this.pictureBox28.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox28.TabIndex = 32;
            this.pictureBox28.TabStop = false;
            this.pictureBox28.Tag = "Rock4";
            this.pictureBox28.Visible = false;
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(94)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pictureBox28);
            this.Controls.Add(this.pictureBox25);
            this.Controls.Add(this.pictureBox24);
            this.Controls.Add(this.pictureBox22);
            this.Controls.Add(this.pictureBox21);
            this.Controls.Add(this.pictureBox20);
            this.Controls.Add(this.pictureBox19);
            this.Controls.Add(this.pictureBox18);
            this.Controls.Add(this.pictureBox17);
            this.Controls.Add(this.pictureBox16);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.pictureBox14);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.lblKills);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.playerTank);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.pictureBox23);
            this.Controls.Add(this.pictureBox26);
            this.Controls.Add(this.pictureBox27);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Map";
            this.Text = "Tank Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.playerTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.PictureBox playerTank;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblKills;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.PictureBox pictureBox17;
        private System.Windows.Forms.PictureBox pictureBox18;
        private System.Windows.Forms.PictureBox pictureBox19;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.PictureBox pictureBox21;
        private System.Windows.Forms.PictureBox pictureBox22;
        private System.Windows.Forms.PictureBox pictureBox23;
        private System.Windows.Forms.PictureBox pictureBox24;
        private System.Windows.Forms.PictureBox pictureBox25;
        private System.Windows.Forms.PictureBox pictureBox26;
        private System.Windows.Forms.PictureBox pictureBox27;
        private System.Windows.Forms.PictureBox pictureBox28;
    }
}

