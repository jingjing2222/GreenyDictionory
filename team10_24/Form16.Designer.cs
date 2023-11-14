
namespace team10_24
{
    partial class Form16
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form16));
            this.label1 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.history = new System.Windows.Forms.Button();
            this.diary = new System.Windows.Forms.Button();
            this.community = new System.Windows.Forms.Button();
            this.bookmark = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.logout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼둥근헤드라인", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(369, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "초록도감";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(386, 151);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(159, 56);
            this.Search.TabIndex = 1;
            this.Search.Text = "식물 검색";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // history
            // 
            this.history.Location = new System.Drawing.Point(386, 223);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(159, 54);
            this.history.TabIndex = 2;
            this.history.Text = "식물 히스토리";
            this.history.UseVisualStyleBackColor = true;
            this.history.Click += new System.EventHandler(this.history_Click);
            // 
            // diary
            // 
            this.diary.Location = new System.Drawing.Point(386, 300);
            this.diary.Name = "diary";
            this.diary.Size = new System.Drawing.Size(159, 54);
            this.diary.TabIndex = 3;
            this.diary.Text = "식물 일기장";
            this.diary.UseVisualStyleBackColor = true;
            this.diary.Click += new System.EventHandler(this.diary_Click);
            // 
            // community
            // 
            this.community.Location = new System.Drawing.Point(386, 380);
            this.community.Name = "community";
            this.community.Size = new System.Drawing.Size(159, 54);
            this.community.TabIndex = 4;
            this.community.Text = "커뮤니티";
            this.community.UseVisualStyleBackColor = true;
            this.community.Click += new System.EventHandler(this.community_Click);
            // 
            // bookmark
            // 
            this.bookmark.Location = new System.Drawing.Point(386, 455);
            this.bookmark.Name = "bookmark";
            this.bookmark.Size = new System.Drawing.Size(159, 54);
            this.bookmark.TabIndex = 5;
            this.bookmark.Text = "내가 북마크 한 식물";
            this.bookmark.UseVisualStyleBackColor = true;
            this.bookmark.Click += new System.EventHandler(this.bookmark_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(65, 151);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 205);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(694, 276);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(164, 168);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(843, 12);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(87, 30);
            this.logout.TabIndex = 8;
            this.logout.Text = "로그아웃";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // Form16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 565);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bookmark);
            this.Controls.Add(this.community);
            this.Controls.Add(this.diary);
            this.Controls.Add(this.history);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.label1);
            this.Name = "Form16";
            this.Text = "Form16";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button history;
        private System.Windows.Forms.Button diary;
        private System.Windows.Forms.Button community;
        private System.Windows.Forms.Button bookmark;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button logout;
    }
}