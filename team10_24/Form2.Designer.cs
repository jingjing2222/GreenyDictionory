
namespace team10_24
{
    partial class Form2
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
            this.Color = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.Modify = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.Bloom = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Color
            // 
            this.Color.Location = new System.Drawing.Point(252, 90);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(263, 25);
            this.Color.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "식물 검색";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "식물 이름";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "식물 색";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "식물 개화기";
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(179, 172);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(58, 23);
            this.Add.TabIndex = 10;
            this.Add.Text = "추가";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Modify
            // 
            this.Modify.Location = new System.Drawing.Point(280, 172);
            this.Modify.Name = "Modify";
            this.Modify.Size = new System.Drawing.Size(58, 23);
            this.Modify.TabIndex = 11;
            this.Modify.Text = "수정";
            this.Modify.UseVisualStyleBackColor = true;
            this.Modify.Click += new System.EventHandler(this.Modify_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(389, 172);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(58, 23);
            this.Delete.TabIndex = 12;
            this.Delete.Text = "삭제";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(490, 172);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(58, 23);
            this.Search.TabIndex = 13;
            this.Search.Text = "찾기";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Bloom
            // 
            this.Bloom.Location = new System.Drawing.Point(252, 121);
            this.Bloom.Name = "Bloom";
            this.Bloom.Size = new System.Drawing.Size(263, 25);
            this.Bloom.TabIndex = 14;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(252, 57);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(263, 25);
            this.name.TabIndex = 16;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.name);
            this.Controls.Add(this.Bloom);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Modify);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Color);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Color;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Modify;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.TextBox Bloom;
        private System.Windows.Forms.TextBox name;
    }
}