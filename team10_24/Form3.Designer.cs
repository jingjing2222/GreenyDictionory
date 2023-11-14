
namespace team10_24
{
    partial class Form3
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
            this.Id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Id_check_bt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pw = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pw_check = new System.Windows.Forms.TextBox();
            this.pw_check_bt = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.name_tx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.email_tx = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Id
            // 
            this.Id.Location = new System.Drawing.Point(119, 98);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(181, 25);
            this.Id.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(117, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "회원가입 ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "아이디";
            // 
            // Id_check_bt
            // 
            this.Id_check_bt.Location = new System.Drawing.Point(316, 97);
            this.Id_check_bt.Name = "Id_check_bt";
            this.Id_check_bt.Size = new System.Drawing.Size(101, 26);
            this.Id_check_bt.TabIndex = 3;
            this.Id_check_bt.Text = "아이디 확인";
            this.Id_check_bt.UseVisualStyleBackColor = true;
            this.Id_check_bt.Click += new System.EventHandler(this.Id_check_bt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "비밀번호";
            // 
            // pw
            // 
            this.pw.Location = new System.Drawing.Point(119, 163);
            this.pw.Name = "pw";
            this.pw.Size = new System.Drawing.Size(181, 25);
            this.pw.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "비밀번호 재확인";
            // 
            // pw_check
            // 
            this.pw_check.Location = new System.Drawing.Point(122, 232);
            this.pw_check.Name = "pw_check";
            this.pw_check.Size = new System.Drawing.Size(178, 25);
            this.pw_check.TabIndex = 7;
            // 
            // pw_check_bt
            // 
            this.pw_check_bt.Location = new System.Drawing.Point(316, 232);
            this.pw_check_bt.Name = "pw_check_bt";
            this.pw_check_bt.Size = new System.Drawing.Size(133, 25);
            this.pw_check_bt.TabIndex = 8;
            this.pw_check_bt.Text = "비밀번호 재확인";
            this.pw_check_bt.UseVisualStyleBackColor = true;
            this.pw_check_bt.Click += new System.EventHandler(this.pw_check_bt_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "이름";
            // 
            // name_tx
            // 
            this.name_tx.Location = new System.Drawing.Point(122, 300);
            this.name_tx.Name = "name_tx";
            this.name_tx.Size = new System.Drawing.Size(178, 25);
            this.name_tx.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "이메일";
            // 
            // email_tx
            // 
            this.email_tx.Location = new System.Drawing.Point(122, 363);
            this.email_tx.Name = "email_tx";
            this.email_tx.Size = new System.Drawing.Size(178, 25);
            this.email_tx.TabIndex = 12;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(122, 423);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 36);
            this.submit.TabIndex = 13;
            this.submit.Text = "제출";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 511);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.email_tx);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.name_tx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pw_check_bt);
            this.Controls.Add(this.pw_check);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Id_check_bt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Id);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Id_check_bt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pw_check;
        private System.Windows.Forms.Button pw_check_bt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox name_tx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox email_tx;
        private System.Windows.Forms.Button submit;
    }
}