namespace TaskManager
{
    partial class AddTaskForm
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
            this.dateTaskPicker = new System.Windows.Forms.DateTimePicker();
            this.timeTaskPicker = new System.Windows.Forms.DateTimePicker();
            this.textBoxTaskTitle = new System.Windows.Forms.TextBox();
            this.textBoxTaskText = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCloseTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTaskPicker
            // 
            this.dateTaskPicker.CustomFormat = "DD.MM.yyyy";
            this.dateTaskPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTaskPicker.Location = new System.Drawing.Point(12, 12);
            this.dateTaskPicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTaskPicker.Name = "dateTaskPicker";
            this.dateTaskPicker.Size = new System.Drawing.Size(197, 22);
            this.dateTaskPicker.TabIndex = 2;
            // 
            // timeTaskPicker
            // 
            this.timeTaskPicker.CustomFormat = "HH:mm";
            this.timeTaskPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeTaskPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeTaskPicker.Location = new System.Drawing.Point(215, 12);
            this.timeTaskPicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.timeTaskPicker.Name = "timeTaskPicker";
            this.timeTaskPicker.ShowUpDown = true;
            this.timeTaskPicker.Size = new System.Drawing.Size(65, 22);
            this.timeTaskPicker.TabIndex = 3;
            // 
            // textBoxTaskTitle
            // 
            this.textBoxTaskTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTaskTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(56)))));
            this.textBoxTaskTitle.Location = new System.Drawing.Point(12, 40);
            this.textBoxTaskTitle.Name = "textBoxTaskTitle";
            this.textBoxTaskTitle.Size = new System.Drawing.Size(268, 22);
            this.textBoxTaskTitle.TabIndex = 0;
            // 
            // textBoxTaskText
            // 
            this.textBoxTaskText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTaskText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(56)))));
            this.textBoxTaskText.Location = new System.Drawing.Point(12, 68);
            this.textBoxTaskText.Multiline = true;
            this.textBoxTaskText.Name = "textBoxTaskText";
            this.textBoxTaskText.Size = new System.Drawing.Size(268, 91);
            this.textBoxTaskText.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.ForeColor = System.Drawing.Color.Navy;
            this.btnSave.Location = new System.Drawing.Point(12, 165);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btnCloseTask
            // 
            this.btnCloseTask.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCloseTask.ForeColor = System.Drawing.Color.Black;
            this.btnCloseTask.Location = new System.Drawing.Point(205, 165);
            this.btnCloseTask.Name = "btnCloseTask";
            this.btnCloseTask.Size = new System.Drawing.Size(75, 26);
            this.btnCloseTask.TabIndex = 5;
            this.btnCloseTask.Text = "Close";
            this.btnCloseTask.UseVisualStyleBackColor = true;
            // 
            // AddTaskForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseTask;
            this.ClientSize = new System.Drawing.Size(291, 196);
            this.Controls.Add(this.btnCloseTask);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxTaskText);
            this.Controls.Add(this.textBoxTaskTitle);
            this.Controls.Add(this.timeTaskPicker);
            this.Controls.Add(this.dateTaskPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Task";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCloseTask;
        public System.Windows.Forms.TextBox textBoxTaskTitle;
        public System.Windows.Forms.TextBox textBoxTaskText;
        public System.Windows.Forms.DateTimePicker dateTaskPicker;
        public System.Windows.Forms.DateTimePicker timeTaskPicker;
    }
}