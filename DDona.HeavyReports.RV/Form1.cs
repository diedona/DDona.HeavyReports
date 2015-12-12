using DDona.HeavyReports.RV.DataSets;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDona.HeavyReports.RV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DDona.HeavyReports.RV.DataSets.dsReportPessoasTableAdapters.PersonTableAdapter PersonTA =
                new DataSets.dsReportPessoasTableAdapters.PersonTableAdapter();
            ReportDataSource rds = new ReportDataSource("dsPessoas", (object)PersonTA.GetData());

            this.reportViewer1.Reset();
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.LocalReport.ReportPath = @"Reports/ReportPessoas.rdlc";

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}