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
    public partial class MainWinForm : Form
    {
        public MainWinForm()
        {
            InitializeComponent();

            System.Drawing.Rectangle currentResolution = Screen.PrimaryScreen.Bounds;

            this.Top = currentResolution.Height - 480 - 50;
            this.Left = currentResolution.Width - 320 - 10;

            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.AllowUserToAddRows = false;

            this.dataGridView1.Columns.Add(new DataGridViewImageColumn());
            this.dataGridView1.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridView1.Columns[0].Width = 30;
            
            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridView1.Columns[1].HeaderText = string.Empty;
            this.dataGridView1.Columns[1].Width = 10;
            this.dataGridView1.Columns[1].Visible = false;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[2].HeaderText = string.Empty;
            this.dataGridView1.Columns[2].Width = 280;

            this.dataGridView1.ShowCellToolTips = true;

            this.Show();
        }

        private void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    Controller.InstanceController.DoTask(e.RowIndex);
                    break;
            }
        }

        private void DataGridView1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Controller.InstanceController.EditTaskDataGrid(e.ColumnIndex ,e.RowIndex);
        }

        private void DataGridView1MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Controller.InstanceController.ShowAddForm();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
