namespace Wsc2023Day2Paper2App
{
    partial class FrmTicketManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTicketManagement));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvticketcategories = new System.Windows.Forms.DataGridView();
            this.tbticketcategoryId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbclass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbseats = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbnumberofbaggages = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbfare = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbchangefee = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbcancellation = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbweightofbaggages = new System.Windows.Forms.TextBox();
            this.btncreate = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnupdate = new System.Windows.Forms.Button();
            this.cbfiights = new System.Windows.Forms.ComboBox();
            this.cbairline = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvticketcategories)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(51)))), ((int)(((byte)(64)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1355, 125);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "c";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(283, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(758, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "WorldSKills Airlines Management System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dgvticketcategories
            // 
            this.dgvticketcategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvticketcategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvticketcategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvticketcategories.Location = new System.Drawing.Point(17, 547);
            this.dgvticketcategories.Name = "dgvticketcategories";
            this.dgvticketcategories.Size = new System.Drawing.Size(1327, 441);
            this.dgvticketcategories.TabIndex = 8;
            this.dgvticketcategories.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvticketcategories_CellContentClick);
            // 
            // tbticketcategoryId
            // 
            this.tbticketcategoryId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbticketcategoryId.Location = new System.Drawing.Point(381, 205);
            this.tbticketcategoryId.Name = "tbticketcategoryId";
            this.tbticketcategoryId.Size = new System.Drawing.Size(228, 29);
            this.tbticketcategoryId.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(205, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ticket Category Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(310, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Class";
            // 
            // tbclass
            // 
            this.tbclass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbclass.Location = new System.Drawing.Point(381, 255);
            this.tbclass.Name = "tbclass";
            this.tbclass.Size = new System.Drawing.Size(228, 29);
            this.tbclass.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "Seats";
            // 
            // tbseats
            // 
            this.tbseats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbseats.Location = new System.Drawing.Point(381, 309);
            this.tbseats.Name = "tbseats";
            this.tbseats.Size = new System.Drawing.Size(228, 29);
            this.tbseats.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(176, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "Number of Baggages";
            // 
            // tbnumberofbaggages
            // 
            this.tbnumberofbaggages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnumberofbaggages.Location = new System.Drawing.Point(381, 365);
            this.tbnumberofbaggages.Name = "tbnumberofbaggages";
            this.tbnumberofbaggages.Size = new System.Drawing.Size(228, 29);
            this.tbnumberofbaggages.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(742, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 24);
            this.label6.TabIndex = 24;
            this.label6.Text = "Fare";
            // 
            // tbfare
            // 
            this.tbfare.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbfare.Location = new System.Drawing.Point(802, 365);
            this.tbfare.Name = "tbfare";
            this.tbfare.Size = new System.Drawing.Size(228, 29);
            this.tbfare.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(675, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 24);
            this.label7.TabIndex = 22;
            this.label7.Text = "Change Fee";
            // 
            // tbchangefee
            // 
            this.tbchangefee.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbchangefee.Location = new System.Drawing.Point(802, 309);
            this.tbchangefee.Name = "tbchangefee";
            this.tbchangefee.Size = new System.Drawing.Size(228, 29);
            this.tbchangefee.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(635, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 24);
            this.label8.TabIndex = 20;
            this.label8.Text = "Cancellation Fees";
            // 
            // tbcancellation
            // 
            this.tbcancellation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcancellation.Location = new System.Drawing.Point(802, 255);
            this.tbcancellation.Name = "tbcancellation";
            this.tbcancellation.Size = new System.Drawing.Size(228, 29);
            this.tbcancellation.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(615, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 24);
            this.label9.TabIndex = 18;
            this.label9.Text = "Weight of Baggages";
            // 
            // tbweightofbaggages
            // 
            this.tbweightofbaggages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbweightofbaggages.Location = new System.Drawing.Point(802, 205);
            this.tbweightofbaggages.Name = "tbweightofbaggages";
            this.tbweightofbaggages.Size = new System.Drawing.Size(228, 29);
            this.tbweightofbaggages.TabIndex = 17;
            // 
            // btncreate
            // 
            this.btncreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncreate.Location = new System.Drawing.Point(535, 430);
            this.btncreate.Name = "btncreate";
            this.btncreate.Size = new System.Drawing.Size(123, 42);
            this.btncreate.TabIndex = 25;
            this.btncreate.Text = "Create";
            this.btncreate.UseVisualStyleBackColor = true;
            this.btncreate.Click += new System.EventHandler(this.btncreate_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.Location = new System.Drawing.Point(679, 430);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(123, 42);
            this.btnupdate.TabIndex = 26;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // cbfiights
            // 
            this.cbfiights.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbfiights.FormattingEnabled = true;
            this.cbfiights.Location = new System.Drawing.Point(381, 155);
            this.cbfiights.Name = "cbfiights";
            this.cbfiights.Size = new System.Drawing.Size(228, 32);
            this.cbfiights.TabIndex = 27;
            // 
            // cbairline
            // 
            this.cbairline.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbairline.FormattingEnabled = true;
            this.cbairline.Location = new System.Drawing.Point(802, 155);
            this.cbairline.Name = "cbairline";
            this.cbairline.Size = new System.Drawing.Size(228, 32);
            this.cbairline.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(309, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 24);
            this.label10.TabIndex = 29;
            this.label10.Text = "Flight";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(731, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 24);
            this.label11.TabIndex = 30;
            this.label11.Text = "Airline";
            // 
            // FrmTicketManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 1000);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbairline);
            this.Controls.Add(this.cbfiights);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btncreate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbfare);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbchangefee);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbcancellation);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbweightofbaggages);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbnumberofbaggages);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbseats);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbclass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbticketcategoryId);
            this.Controls.Add(this.dgvticketcategories);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmTicketManagement";
            this.Text = "FrmTicketManagement";
            this.Load += new System.EventHandler(this.FrmTicketManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvticketcategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvticketcategories;
        private System.Windows.Forms.TextBox tbticketcategoryId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbclass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbseats;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbnumberofbaggages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbfare;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbchangefee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbcancellation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbweightofbaggages;
        private System.Windows.Forms.Button btncreate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.ComboBox cbfiights;
        private System.Windows.Forms.ComboBox cbairline;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}