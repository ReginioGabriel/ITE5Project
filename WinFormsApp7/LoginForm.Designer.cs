namespace WinFormsApp7
{
    partial class LoginForm
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
            btntest = new Button();
            btnSignUp = new Button();
            btnLogin = new Button();
            txtUsername = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtPassword = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btntest
            // 
            btntest.Location = new Point(1085, 12);
            btntest.Name = "btntest";
            btntest.Size = new Size(87, 27);
            btntest.TabIndex = 3;
            btntest.Text = "Test Connection";
            btntest.UseVisualStyleBackColor = true;
            btntest.Click += label1_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.Yellow;
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Font = new Font("Franklin Gothic Medium Cond", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSignUp.ForeColor = SystemColors.ActiveCaptionText;
            btnSignUp.Location = new Point(469, 440);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(242, 31);
            btnSignUp.TabIndex = 4;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(192, 0, 0);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Franklin Gothic Medium Cond", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(469, 493);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(242, 33);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(28, 32, 65);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = SystemColors.Window;
            txtUsername.Location = new Point(469, 307);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(242, 29);
            txtUsername.TabIndex = 6;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.HighlightText;
            label2.Location = new Point(469, 283);
            label2.Name = "label2";
            label2.Size = new Size(87, 21);
            label2.TabIndex = 10;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.HighlightText;
            label3.Location = new Point(469, 354);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 12;
            label3.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(28, 32, 65);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = SystemColors.Window;
            txtPassword.Location = new Point(469, 378);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(242, 29);
            txtPassword.TabIndex = 11;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(540, 88);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.logo_1;
            pictureBox2.Location = new Point(530, 158);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(143, 79);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Heavy", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(499, 170);
            label1.Name = "label1";
            label1.Size = new Size(108, 21);
            label1.TabIndex = 15;
            label1.Text = "WELCOME TO";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(6F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 32, 61);
            ClientSize = new Size(1184, 660);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(btnLogin);
            Controls.Add(btnSignUp);
            Controls.Add(txtUsername);
            Controls.Add(btntest);
            Font = new Font("Franklin Gothic Medium Cond", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoginForm";
            ShowIcon = false;
            Text = "Form2";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btntest;
        private Button btnSignUp;
        private Button btnLogin;
        private TextBox txtUsername;
        private Label label2;
        private Label label3;
        private TextBox txtPassword;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
    }
}