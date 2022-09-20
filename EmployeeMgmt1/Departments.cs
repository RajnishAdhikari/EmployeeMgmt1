﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeMgmt1
{
    public partial class Departments : Form
    {
        Functions Con;
        public Departments()
        {
            InitializeComponent();
            Con = new Functions();
            ShowDepartments();

        }
        private void ShowDepartments()
        {
            string Query = "Select * from DepartmentTb1";
            DepList.DataSource = Con.GetData(Query);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "Insert into DepartmentTb1 values ('{0}')";
                    Query = string.Format(Query,DepNameTb.Text);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Added");
                    DepNameTb.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
