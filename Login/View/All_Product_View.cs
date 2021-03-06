﻿using Project.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.View
{
    public partial class All_Product_View : MetroFramework.Forms.MetroForm
    {
        public DataSet Ds { get; set; }
        DataAccess Da { get; set; }
        public All_Product_View()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        void PopulateGridView(string sql)
        {
            this.metroGrid.AutoGenerateColumns = false;
            this.Ds = this.Da.ExecuteQuery(sql);
            this.metroGrid.DataSource = this.Ds.Tables[0];
        }
        private void Form_Load(object sender, EventArgs e)
        {
            metroGrid.DataSource = ProductController.GetAllProducts();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
           // new Manager_View().Show();
            this.Close();
        }
        private void SeachBox_Text_Change(object sender, EventArgs e)
        {
            DataAccess DA = new DataAccess();
            string Name = this.Search_Box.Text;
            {
                string sql = "select * from Products where Name like '" + Name + "%'; ";
                this.PopulateGridView(sql);
            }
        }

        private void All_Product_View_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
