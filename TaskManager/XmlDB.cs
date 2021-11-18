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
    public sealed class XmlDb
    {
        public DataSet ds;
        private DataTable tblNotes;
        private string xmlFile;

        /// <summary>
        /// add row to datatable
        /// </summary>
        public void AddRow(object[] rowData)
        {
            try
            {
                tblNotes.Rows.Add(rowData);
            }
            catch (ConstraintException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// save present data to XML file
        /// </summary>
        public void SaveToXml()
        {
            ds.WriteXml(xmlFile);
        }

        /// <summary>
        /// Create object from opened XML file
        /// </summary>
        /// <param name="pathXml">path to xml file</param>
        public void LoadXml(string pathXml)
        {
                DataSet temp = new DataSet();
                temp.ReadXml(pathXml);

                xmlFile = pathXml;
                ds = new DataSet();
                tblNotes = new DataTable(temp.Tables[0].TableName);

                foreach (DataColumn col in temp.Tables[0].Columns)
                {
                    if (col.ColumnName == "DateTime")
                    {
                        tblNotes.Columns.Add(col.ColumnName, typeof(System.DateTime));
                    }
                    else
                    {
                        tblNotes.Columns.Add(new DataColumn(col.ColumnName));
                    }
                }

                tblNotes.Columns[0].AutoIncrement = true;
                tblNotes.Columns[0].AutoIncrementStep = 1;
                tblNotes.Columns[0].ReadOnly = true;
                tblNotes.PrimaryKey = new DataColumn[] { tblNotes.Columns[0] };

                ds.Tables.Add(tblNotes);
                temp.Dispose();

                ds.ReadXml(pathXml);
        }

        /// <summary>
        /// Create object from new XML file
        /// </summary>
        /// <param name="dataBaseName">name of main node of xml</param>
        /// <param name="dataItemName">name of child node of xml (repeatable)</param>
        /// <param name="pathXml">path to xml file</param>
        /// <param name="itemColumns">name array of columns</param>
        public void CreateXml(string dataBaseName, string dataItemName, string pathXml, string[] itemColumns = null)
        {
            tblNotes = new DataTable(dataItemName);
            ds = new DataSet(dataBaseName);

            xmlFile = pathXml;

            if (itemColumns != null && itemColumns.Length > 0)
            {
                for (int i = 0; i < itemColumns.Length; i++)
                {
                    if (itemColumns[i] == "DateTime")
                    {
                        tblNotes.Columns.Add(itemColumns[i],typeof(System.DateTime));
                    }
                    else
                    {
                        tblNotes.Columns.Add(itemColumns[i]);
                    }
                }

                tblNotes.Columns[0].AutoIncrement = true;
                tblNotes.Columns[0].AutoIncrementSeed = 1;
                tblNotes.Columns[0].AutoIncrementStep = 1;
                tblNotes.Columns[0].ReadOnly = true;
                tblNotes.PrimaryKey = new DataColumn[] { tblNotes.Columns[0] };

                ds.Tables.Add(tblNotes);
            }

        }

        /// <summary>
        /// Constructor which creates or load xml file with database of tasks
        /// </summary>
        public XmlDb()
        {
            if (System.IO.File.Exists("NotesDB.xml"))
            {
                try
                {
                    this.LoadXml("NotesDB.xml");
                }
                catch
                {
                    System.IO.File.Delete("NotesDB.xml");
                    this.CreateXml("NotesDB", "Note", "NotesDB.xml", new string[] { "Id", "Title", "Text", "DateTime" });
                }
            }
            else
            {
                this.CreateXml("NotesDB", "Note", "NotesDB.xml", new string[] { "Id", "Title", "Text", "DateTime" });
            }
        }
    }
}
