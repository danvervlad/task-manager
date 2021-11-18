using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class AddTaskForm : Form
    {
        public enum CurrentModeEnum
        {
            newTask,
            editTask
        }

        public CurrentModeEnum CurrentMode;
        public int CurrentDatasetRow;

        public AddTaskForm()
        {
            this.CurrentMode = CurrentModeEnum.newTask;
            this.CurrentDatasetRow = 0;
            InitializeComponent();
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
                switch (this.CurrentMode)
                {
                    case CurrentModeEnum.newTask:
                        Controller.InstanceController.AddNewTaskForm(new object[] { null, this.textBoxTaskTitle.Text, this.textBoxTaskText.Text, 
                              System.DateTime.Parse(this.dateTaskPicker.Value.ToShortDateString() + " " + this.timeTaskPicker.Value.ToShortTimeString()) });
                        break;
                    case CurrentModeEnum.editTask:
                        Controller.InstanceController.EditTaskAddForm(this.CurrentDatasetRow, new object[] { null, this.textBoxTaskTitle.Text, this.textBoxTaskText.Text, 
                              System.DateTime.Parse(this.dateTaskPicker.Value.ToShortDateString() + " " + this.timeTaskPicker.Value.ToShortTimeString()) });
                        break;
                }
        }
    }
}
