namespace TaskManager
{
    partial class PopUpWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopUpWin));
            this.rtbxTaskTitle = new System.Windows.Forms.RichTextBox();
            this.btnCompleteTask = new System.Windows.Forms.Button();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.rtbxTaskDescribtion = new System.Windows.Forms.RichTextBox();
            this.rtbxTaskTime = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbxTaskTitle
            // 
            this.rtbxTaskTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbxTaskTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(172)))), ((int)(((byte)(237)))));
            this.rtbxTaskTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbxTaskTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbxTaskTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(56)))));
            this.rtbxTaskTitle.Location = new System.Drawing.Point(12, 12);
            this.rtbxTaskTitle.Multiline = false;
            this.rtbxTaskTitle.Name = "rtbxTaskTitle";
            this.rtbxTaskTitle.ReadOnly = true;
            this.rtbxTaskTitle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbxTaskTitle.Size = new System.Drawing.Size(472, 34);
            this.rtbxTaskTitle.TabIndex = 0;
            this.rtbxTaskTitle.TabStop = false;
            this.rtbxTaskTitle.Text = "";
            this.rtbxTaskTitle.WordWrap = false;
            // 
            // btnCompleteTask
            // 
            this.btnCompleteTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCompleteTask.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnCompleteTask.Image = ((System.Drawing.Image)(resources.GetObject("btnCompleteTask.Image")));
            this.btnCompleteTask.Location = new System.Drawing.Point(12, 212);
            this.btnCompleteTask.Name = "btnCompleteTask";
            this.btnCompleteTask.Size = new System.Drawing.Size(82, 80);
            this.btnCompleteTask.TabIndex = 0;
            this.btnCompleteTask.UseVisualStyleBackColor = true;
            // 
            // btnEditTask
            // 
            this.btnEditTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTask.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnEditTask.Image = ((System.Drawing.Image)(resources.GetObject("btnEditTask.Image")));
            this.btnEditTask.Location = new System.Drawing.Point(402, 212);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(82, 80);
            this.btnEditTask.TabIndex = 1;
            this.btnEditTask.UseVisualStyleBackColor = true;
            // 
            // rtbxTaskDescribtion
            // 
            this.rtbxTaskDescribtion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbxTaskDescribtion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(172)))), ((int)(((byte)(237)))));
            this.rtbxTaskDescribtion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbxTaskDescribtion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbxTaskDescribtion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(56)))));
            this.rtbxTaskDescribtion.Location = new System.Drawing.Point(11, 52);
            this.rtbxTaskDescribtion.Name = "rtbxTaskDescribtion";
            this.rtbxTaskDescribtion.ReadOnly = true;
            this.rtbxTaskDescribtion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbxTaskDescribtion.Size = new System.Drawing.Size(472, 154);
            this.rtbxTaskDescribtion.TabIndex = 3;
            this.rtbxTaskDescribtion.TabStop = false;
            this.rtbxTaskDescribtion.Text = "";
            // 
            // rtbxTaskTime
            // 
            this.rtbxTaskTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbxTaskTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.rtbxTaskTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbxTaskTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbxTaskTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(56)))));
            this.rtbxTaskTime.Location = new System.Drawing.Point(100, 241);
            this.rtbxTaskTime.Multiline = false;
            this.rtbxTaskTime.Name = "rtbxTaskTime";
            this.rtbxTaskTime.ReadOnly = true;
            this.rtbxTaskTime.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbxTaskTime.Size = new System.Drawing.Size(296, 34);
            this.rtbxTaskTime.TabIndex = 4;
            this.rtbxTaskTime.TabStop = false;
            this.rtbxTaskTime.Text = "";
            this.rtbxTaskTime.WordWrap = false;
            // 
            // PopUpWin
            // 
            this.AcceptButton = this.btnCompleteTask;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnEditTask;
            this.ClientSize = new System.Drawing.Size(495, 304);
            this.ControlBox = false;
            this.Controls.Add(this.rtbxTaskTime);
            this.Controls.Add(this.rtbxTaskDescribtion);
            this.Controls.Add(this.btnEditTask);
            this.Controls.Add(this.btnCompleteTask);
            this.Controls.Add(this.rtbxTaskTitle);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(56)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(497, 306);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(497, 306);
            this.Name = "PopUpWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.PopUpWin_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEditTask;
        public System.Windows.Forms.RichTextBox rtbxTaskTitle;
        public System.Windows.Forms.RichTextBox rtbxTaskDescribtion;
        public System.Windows.Forms.RichTextBox rtbxTaskTime;
        public System.Windows.Forms.Button btnCompleteTask;
    }
}