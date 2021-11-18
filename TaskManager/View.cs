using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskManager
{
    public class Tray
    {
        #region Объявляем ПУНКТЫ меню в трее
        //... объявляем пункты будущего меню
        private ToolStripMenuItem ToolStripMenuAdd;
        private ToolStripSeparator ToolStripMenuSep2;
        private ToolStripMenuItem ToolStripMenuAbout;
        private ToolStripSeparator ToolStripMenuSep;
        private ToolStripMenuItem ToolStripMenuExit;
        #endregion

        private ContextMenuStrip contextMenuStrip;
        public NotifyIcon NotifyIcon;

        public Tray()
        {
            #region Создаем ПУНКТЫ меню в трее
            // ... создаем пункты будущего меню
            ToolStripMenuAdd = new ToolStripMenuItem("+ Add New Task", null, ToolStripMenuAdd_Click);
            ToolStripMenuSep2 = new ToolStripSeparator();
            ToolStripMenuAbout = new ToolStripMenuItem("About", null, ToolStripMenuAbout_Click);
            ToolStripMenuSep = new ToolStripSeparator();
            ToolStripMenuExit = new ToolStripMenuItem("Exit", null, ToolStripMenuExit_Click);
            #endregion

            #region Создаем меню в трее
            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] 
            {
                //... вписуем созданные пункты меню
                ToolStripMenuAdd,
                ToolStripMenuSep2,
                ToolStripMenuAbout, 
                ToolStripMenuSep, 
                ToolStripMenuExit 
            });
            #endregion

            #region Создаем иконку в трее
            this.NotifyIcon = new NotifyIcon();
            this.NotifyIcon.Icon = Properties.Resources.CheckIco; // ресурс иконки обязательно нужен иначе не будет видно при запуске
            this.NotifyIcon.Click += new EventHandler(NotifyIcon_Click);
            this.NotifyIcon.ContextMenuStrip = contextMenuStrip;
            this.NotifyIcon.Visible = true;
            #endregion
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            Controller.InstanceController.ShowHideMainWinForm(sender, (MouseEventArgs)e);
        }


        private void ToolStripMenuAdd_Click(object sender, EventArgs e)
        {
            Controller.InstanceController.ShowAddForm();
        }

        private void ToolStripMenuExit_Click(object sender, EventArgs e)
        {
            NotifyIcon.Dispose(); // убирает зависшую иконку в трее
            Application.Exit();
        }

        private void ToolStripMenuAbout_Click(object sender, EventArgs e)
        {
            Controller.InstanceController.EventAbout();
        }
    }
}
