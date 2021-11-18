using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace TaskManager
{
    public sealed class Controller
    {
        public static readonly Controller InstanceController;
        public static readonly Tray InstanceTray;
        public static readonly MainWinForm InstanceMainWinForm;
        public static readonly XmlDb InstanceXmlDb;
        public static bool StartProg;

        #region Info about soft
        public readonly string AppName;
        public readonly string AutorName;
        public readonly string Description;
        public readonly string ContactInfo;
        #endregion
        
        private object rowDeletelocker;

        private System.Timers.Timer cycleTimer;

        /// <summary>
        /// Dictionary of displaying PopUp windows (in different threads).
        /// </summary>
        private Dictionary<int,Thread> dictThreadPopUps;

        /// <summary>
        /// When push Save button in Add Form while adding new task.
        /// </summary>
        /// <param name="rowData">all task data for editing row in DataSet (xmlDB)</param>
        public void AddNewTaskForm(object[] rowData)
        {
            InstanceXmlDb.AddRow(rowData);
            InstanceMainWinForm.Invoke(new Action(this.ReloadDataGridView));
        }

        /// <summary>
        /// Reload all tasks in DataGridView.
        /// </summary>
        private void ReloadDataGridView()
        {
            InstanceMainWinForm.dataGridView1.Rows.Clear();

            var dataTable = InstanceXmlDb.ds.Tables[0];

            dataTable.DefaultView.Sort = "DateTime";

            dataTable = dataTable.DefaultView.ToTable();

            foreach (DataRow r in dataTable.Rows)
            {
                InstanceController.AddNewRowDataGridView(r.Field<int>("id"), r.Field<string>("Title"), r.Field<string>("Text"));
            }
        }

        /// <summary>
        /// When right mouse button is clicked in Main Form. It shows Add Form for adding new task.
        /// </summary>
        public void ShowAddForm()
        {
            AddTaskForm addForm = new AddTaskForm
                {
                    Text = "Add New Task",
                    CurrentMode = AddTaskForm.CurrentModeEnum.newTask,
                    Icon = Properties.Resources.plusAdd
                };

            addForm.ShowDialog();

            InstanceXmlDb.SaveToXml();
        }

        /// <summary>
        /// When About tray menu item is clicked. It shows About MessageBox.
        /// </summary>
        public void EventAbout()
        {
            MessageBox.Show("The " + AppName + " was created by " + AutorName +
                "\n\n" + Description + "\n\n" + ContactInfo, AppName);
        }

        /// <summary>
        /// When tray icon is clicked. It shows or hides Main Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowHideMainWinForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (InstanceMainWinForm.Visible)
                {
                    InstanceMainWinForm.Hide();
                }
                else
                {
                    InstanceMainWinForm.Show();
                    InstanceMainWinForm.Activate();
                }
            }
        }

        /// <summary>
        /// When check icon is clicked in task PopUp window.
        /// </summary>
        /// <param name="row">numb of row in DataGridView of Main Form</param>
        public void DoTask(int row)
        {
            lock (rowDeletelocker)
            {
                var taskInDB = InstanceXmlDb.ds.Tables[0].Rows.Find((int)InstanceMainWinForm.dataGridView1.Rows[row].Cells[1].Value);

                taskInDB.Delete();

                InstanceMainWinForm.dataGridView1.Rows.RemoveAt(row);
                InstanceXmlDb.SaveToXml();
            }
        }

        /// <summary>
        /// When push Save button in Add Form while editing task.
        /// </summary>
        /// <param name="currentDatasetRow">numb of task row in DataSet (xmlDB)</param>
        /// <param name="rowData">all task data for editing row in DataSet (xmlDB)</param>
        public void EditTaskAddForm(int currentDatasetRow, object[] rowData)
        {
            InstanceXmlDb.ds.Tables[0].Rows[currentDatasetRow].ItemArray = rowData;

            InstanceMainWinForm.Invoke(new Action(this.ReloadDataGridView));

            InstanceXmlDb.SaveToXml();
        }

        /// <summary>
        /// Add new row to DataGridView in Main Form.
        /// </summary>
        /// <param name="id">uniq task ID (this field will be hidden)</param>
        /// <param name="title">task title</param>
        private void AddNewRowDataGridView(int id, string title, string text)
        {
            InstanceMainWinForm.dataGridView1.Rows.Add();
            DataGridViewRow row = InstanceMainWinForm.dataGridView1.Rows[InstanceMainWinForm.dataGridView1.Rows.Count - 1];
            InstanceMainWinForm.dataGridView1.Rows[InstanceMainWinForm.dataGridView1.Rows.Count - 1].Height = 30;

            DataGridViewImageCell cell0 = (DataGridViewImageCell)row.Cells[0];
            cell0.Value = Properties.Resources.check;

            DataGridViewTextBoxCell cell1 = (DataGridViewTextBoxCell)row.Cells[1];
            cell1.Value = id;

            DataGridViewTextBoxCell cell2 = (DataGridViewTextBoxCell)row.Cells[2];
            cell2.Value = title;
            cell2.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            cell2.ToolTipText = text;

            row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(124, 147, 203);
            row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(91, 107, 148);
            row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(34, 41, 56);
            row.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        /// <summary>
        /// When row in DataGridView is double clicked. Edit task row in DataGridView in MainForm.
        /// </summary>
        /// <param name="column">numb of column in DataGridView of Main Form</param>
        /// <param name="row">numb of row in DataGridView of Main Form</param>
        public void EditTaskDataGrid(int column, int row)
        {
            if (column > 1)
            {
                AddTaskForm addForm = new AddTaskForm();

                for (int i = 0; i < InstanceXmlDb.ds.Tables[0].Rows.Count; i++)
                {
                    if (InstanceXmlDb.ds.Tables[0].Rows[i].Field<int>(0) == (int)InstanceMainWinForm.dataGridView1.Rows[row].Cells[1].Value)
                    {
                        addForm.textBoxTaskTitle.Text = InstanceXmlDb.ds.Tables[0].Rows[i].Field<string>(1).ToString();
                        addForm.textBoxTaskText.Text = InstanceXmlDb.ds.Tables[0].Rows[i].Field<string>(2);
                        addForm.dateTaskPicker.Value = InstanceXmlDb.ds.Tables[0].Rows[i].Field<System.DateTime>(3);
                        addForm.timeTaskPicker.Value = InstanceXmlDb.ds.Tables[0].Rows[i].Field<System.DateTime>(3);

                        addForm.CurrentMode = AddTaskForm.CurrentModeEnum.editTask;
                        addForm.Icon = Properties.Resources.editIco;
                        addForm.CurrentDatasetRow = i;
                        addForm.Text = "Edit Task";
                        addForm.ShowDialog();

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Create new thread, which shows PopUp window.
        /// </summary>
        private void ShowTaskMessageThread()
        {
            var curDataRowInDB = (from DataRow Row in Controller.InstanceXmlDb.ds.Tables[0].Rows
                       where Row.Field<int>(0) == int.Parse(Thread.CurrentThread.Name)
                       select Row).Single();

            var curDataRowInDataGrid = (from DataGridViewRow row in Controller.InstanceMainWinForm.dataGridView1.Rows
                                        where (int)row.Cells[1].Value == curDataRowInDB.Field<int>(0)
                                        select row).Single();

            PopUpWin popUpWin = new PopUpWin();

            popUpWin.rtbxTaskTitle.Text = curDataRowInDB.Field<string>(1);
            popUpWin.rtbxTaskTitle.SelectAll();
            popUpWin.rtbxTaskTitle.SelectionAlignment = HorizontalAlignment.Center;
            popUpWin.rtbxTaskDescribtion.Text = curDataRowInDB.Field<string>(2);
            popUpWin.rtbxTaskTime.Text = "at " + curDataRowInDB.Field<System.DateTime>("DateTime").ToShortTimeString();
            popUpWin.rtbxTaskTime.SelectAll();
            popUpWin.rtbxTaskTime.SelectionAlignment = HorizontalAlignment.Center;
            popUpWin.Icon = Properties.Resources.CheckIco;

            var resultPopUp = popUpWin.ShowDialog();

            if (resultPopUp == DialogResult.Yes)
            {
                    try
                    {
                        if (curDataRowInDataGrid != null)
                        {
                            if ((int)curDataRowInDataGrid.Cells[1].Value == curDataRowInDB.Field<int>(0))
                            {
                                InstanceMainWinForm.dataGridView1.Invoke(new Action(() => InstanceMainWinForm.dataGridView1.Rows.RemoveAt(curDataRowInDataGrid.Index)));
                            }
                        }

                        curDataRowInDB.Delete();
                    }
                    catch (RowNotInTableException)
                    {

                    }
                InstanceXmlDb.SaveToXml();
            }
            else
            {
                AddTaskForm addForm = new AddTaskForm();

                if (curDataRowInDataGrid != null)
                {
                    if (curDataRowInDB.Field<int>(0) == (int)curDataRowInDataGrid.Cells[1].Value)
                        {
                            addForm.textBoxTaskTitle.Text = curDataRowInDB.Field<string>(1).ToString();
                            addForm.textBoxTaskText.Text = curDataRowInDB.Field<string>(2);
                            addForm.dateTaskPicker.Value = curDataRowInDB.Field<System.DateTime>(3);
                            addForm.timeTaskPicker.Value = curDataRowInDB.Field<System.DateTime>(3);

                            addForm.CurrentMode = AddTaskForm.CurrentModeEnum.editTask;
                            addForm.Icon = Properties.Resources.editIco;
                            addForm.CurrentDatasetRow = InstanceXmlDb.ds.Tables[0].Rows.IndexOf(curDataRowInDB);
                            addForm.Text = "Edit Task";

                            addForm.ShowDialog();
                        }
                }

                Controller.InstanceController.dictThreadPopUps.Remove(curDataRowInDB.Field<int>(0));
            }
        }

        /// <summary>
        /// Method is run in cycle by Timer.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void StartTimer(object source, System.Timers.ElapsedEventArgs e)
        {
                var oldTasks = (from DataRow row in InstanceXmlDb.ds.Tables[0].Rows
                                where row.Field<System.DateTime>("DateTime") < System.DateTime.Now
                                select row).ToArray();

                if (oldTasks.Length > 0)
                {
                    foreach (var tt in oldTasks)
                    {
                        for (int i = 0; i < InstanceMainWinForm.dataGridView1.Rows.Count; i++)
                        {
                            // может проще шагать по датагриду ?
                            if ((int)InstanceMainWinForm.dataGridView1.Rows[i].Cells[1].Value != tt.Field<int>(0))
                            {
                                continue;
                            }
                            if (InstanceMainWinForm.dataGridView1.Rows[i].Cells[0].Value != Properties.Resources.Warning)
                            {
                                InstanceMainWinForm.dataGridView1.Invoke(new Action(() => { InstanceMainWinForm.dataGridView1.Rows[i].Cells[0].Value = Properties.Resources.Warning; }));
                            }
                            break;
                        }
                    }
                }

                var curTasks = (from DataRow row in InstanceXmlDb.ds.Tables[0].Rows
                                where row.Field<System.DateTime>("DateTime") >= System.DateTime.Now
                                && row.Field<System.DateTime>("DateTime") <= System.DateTime.Now.AddSeconds(60)
                                select row).ToList();

                if (curTasks.Count > 0)
                {
                    foreach (var tt in curTasks)
                    {
                        var isExist = this.dictThreadPopUps.ContainsKey(tt.Field<int>(0));

                        if (!isExist)
                        {
                            System.Threading.Thread threadPopUp = new System.Threading.Thread(this.ShowTaskMessageThread);
                            threadPopUp.Name = string.Format("{0}", tt.Field<int>(0));
                            this.dictThreadPopUps.Add(tt.Field<int>(0), threadPopUp);
                            threadPopUp.Start();

                        }
                    }
                }
        }

        #region Constructors
        /// <summary>
        /// Static constructor, which create tray icon, Main Form, Timer, xmlDB.
        /// </summary>
        static Controller()
        {
            InstanceController = new Controller("Task Manager", "Danver", string.Empty, "x-vlad-x@bk.ru");
            InstanceController.cycleTimer = new System.Timers.Timer(500);
            InstanceController.cycleTimer.Elapsed += new System.Timers.ElapsedEventHandler(InstanceController.StartTimer);
            InstanceController.cycleTimer.Start();
            InstanceController.dictThreadPopUps = new Dictionary<int, Thread>();
            InstanceController.rowDeletelocker = new object();

            InstanceTray = new Tray();

            InstanceMainWinForm = new MainWinForm();

            InstanceXmlDb = new XmlDb();

            InstanceController.ReloadDataGridView();
        }

        /// <summary>
        /// Privat conctructor (only Static constructor can create instance itself, pattern Singletone)
        /// </summary>
        /// <param name="appName">name of application (for About MessageBox)</param>
        /// <param name="autorName">author of application (for About MessageBox)</param>
        /// <param name="description">description of application (for About MessageBox)</param>
        /// <param name="contactInfo">author contact info (for About MessageBox)</param>
        private Controller(string appName, string autorName, string description = "", string contactInfo = "")
        {
            this.AppName = appName;
            this.AutorName = autorName;
            this.Description = description;
            this.ContactInfo = contactInfo;
        }
        #endregion
    }
}
