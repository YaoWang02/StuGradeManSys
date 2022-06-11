﻿using StuGradeManSys.Entities;
using StuGradeManSys.Services;
using StuGradeManSys.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StuGradeManSys.SubForm
{
    public partial class FormStudent : Form
    {
        public static Student Student = new Student();
        
        public FormStudent()
        {
            InitializeComponent();
        }
        private void FormStudent_Load(object sender, EventArgs e)
        {
            var stu = FormMain.StudentService.GetEntity(FormMain.User.ID);
            if (stu == null)
            {
                MessageBox.Show("数据库出错");
                this.Close();
                return;
            }
            Student = stu;
            panel.OpenForm(new FormStudentInfo());
        }
        private bool CheckInfo()
        {
            if (Student.Department == string.Empty || Student.Class == string.Empty || Student.Mailbox == string.Empty)
                return false;
            return true;
        }
        private void InfoManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.OpenForm(new FormStudentInfo());
        }

        private void GradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckInfo())
            {
                MessageBox.Show("请先完善信息");
                return;
            }
            panel.OpenForm(new FormStudentGrade());
        }

        private void AlreadyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckInfo())
            {
                MessageBox.Show("请先完善信息");
                return;
            }
            panel.OpenForm(new FormStudentSelectedCoz());
        }

        private void AvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckInfo())
            {
                MessageBox.Show("请先完善信息");
                return;
            }
            panel.OpenForm(new FormStudentOptionalCoz());
        }
    }
}
