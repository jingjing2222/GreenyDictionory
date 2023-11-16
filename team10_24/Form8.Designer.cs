
namespace team10_24
{
    partial class Form8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            this.Modify = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.review = new System.Windows.Forms.Button();
            this.bookmark = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Modify
            // 
            this.Modify.Location = new System.Drawing.Point(107, 353);
            this.Modify.Name = "Modify";
            this.Modify.Size = new System.Drawing.Size(120, 31);
            this.Modify.TabIndex = 1;
            this.Modify.Text = "수정";
            this.Modify.UseVisualStyleBackColor = true;
            this.Modify.Click += new System.EventHandler(this.Modify_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(287, 354);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(121, 30);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "삭제";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(107, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(483, 272);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // review
            // 
            this.review.Location = new System.Drawing.Point(469, 354);
            this.review.Name = "review";
            this.review.Size = new System.Drawing.Size(121, 30);
            this.review.TabIndex = 4;
            this.review.Text = "리뷰";
            this.review.UseVisualStyleBackColor = true;
            this.review.Click += new System.EventHandler(this.review_Click);
            // 
            // bookmark
            // 
            this.bookmark.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bookmark.Image = ((System.Drawing.Image)(resources.GetObject("bookmark.Image")));
            this.bookmark.Location = new System.Drawing.Point(616, 41);
            this.bookmark.Name = "bookmark";
            this.bookmark.Size = new System.Drawing.Size(62, 63);
            this.bookmark.TabIndex = 6;
            this.bookmark.UseVisualStyleBackColor = false;
            this.bookmark.Click += new System.EventHandler(this.bookmark_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 460);
            this.Controls.Add(this.bookmark);
            this.Controls.Add(this.review);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Modify);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form8";
            this.Text = "Form8";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Modify;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button review;
        private System.Windows.Forms.Button bookmark;
    }
}