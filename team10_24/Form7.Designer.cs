
namespace team10_24
{
    partial class Form7
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
            this.Modify = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Okay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Modify
            // 
            this.Modify.Location = new System.Drawing.Point(346, 350);
            this.Modify.Name = "Modify";
            this.Modify.Size = new System.Drawing.Size(91, 39);
            this.Modify.TabIndex = 0;
            this.Modify.Text = "수정";
            this.Modify.UseVisualStyleBackColor = true;
            this.Modify.Click += new System.EventHandler(this.Modify_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(189, 350);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(91, 39);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "삭제";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(238, 62);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(300, 245);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Okay
            // 
            this.Okay.Location = new System.Drawing.Point(497, 352);
            this.Okay.Name = "Okay";
            this.Okay.Size = new System.Drawing.Size(91, 35);
            this.Okay.TabIndex = 3;
            this.Okay.Text = "확인";
            this.Okay.UseVisualStyleBackColor = true;
            this.Okay.Click += new System.EventHandler(this.Okay_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 450);
            this.Controls.Add(this.Okay);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Modify);
            this.Name = "Form7";
            this.Text = "Form7";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Modify;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button Okay;
    }
}