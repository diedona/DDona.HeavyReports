using DDona.HeavyReports.RV.DataSets.dsReportPessoasTableAdapters;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDona.HeavyReports.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public FileResult PDF()
        {
            LocalReport LocalReport = new LocalReport();
            PersonTableAdapter PersonTableAdapter = new PersonTableAdapter();

            string ReportName = "Relatorio_Pessoas.pdf";
            byte[] ReportBytes = null;

            LocalReport.ReportPath = Server.MapPath("~/Reports/ReportPessoas.rdlc");
            LocalReport.DataSources.Add(new ReportDataSource("dsPessoas", (object)PersonTableAdapter.GetData()));

            Debug.WriteLine(DateTime.Now);
            ReportBytes = LocalReport.Render("PDF");
            Debug.WriteLine(DateTime.Now);

            return File(ReportBytes, "aplication/pdf", ReportName);
        }
    }
}