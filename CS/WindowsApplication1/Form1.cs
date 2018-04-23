using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Painters;
using DevExpress.XtraVerticalGrid.Rows;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
                private DataTable CreateTable(int RowCount)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("Number", typeof(int));
            tbl.Columns.Add("Date", typeof(DateTime));
            for (int i = 0; i < RowCount; i++)
                tbl.Rows.Add(new object[] { String.Format("Name{0}", i), i, 3 - i, DateTime.Now.AddDays(i) });
            return tbl;
        }
        

        public Form1()
        {
            InitializeComponent();
            myVGridControl1.DataSource = CreateTable(20);
            (myVGridControl1.Rows[0] as EditorRow).Enabled = false;
        }

    }
}