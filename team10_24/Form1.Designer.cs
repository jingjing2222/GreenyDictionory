﻿
namespace team10_24
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Id = new System.Windows.Forms.TextBox();
            this.PW = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            this.Signup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Id
            // 
            this.Id.Location = new System.Drawing.Point(322, 139);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(170, 25);
            this.Id.TabIndex = 0;
            // 
            // PW
            // 
            this.PW.Location = new System.Drawing.Point(322, 195);
            this.PW.Name = "PW";
            this.PW.Size = new System.Drawing.Size(170, 25);
            this.PW.TabIndex = 1;
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(363, 267);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(88, 23);
            this.Login.TabIndex = 2;
            this.Login.Text = "로그인";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Signup
            // 
            this.Signup.Location = new System.Drawing.Point(363, 307);
            this.Signup.Name = "Signup";
            this.Signup.Size = new System.Drawing.Size(88, 23);
            this.Signup.TabIndex = 3;
            this.Signup.Text = "회원가입";
            this.Signup.UseVisualStyleBackColor = true;
            this.Signup.Click += new System.EventHandler(this.Signup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "비밀번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(366, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "로그인";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Signup);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.PW);
            this.Controls.Add(this.Id);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Id;
        private System.Windows.Forms.TextBox PW;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button Signup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

