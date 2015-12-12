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
            string ReportName = "Relatorio_Pessoas.pdf";
            byte[] ReportBytes = RenderReport("PDF");

            return File(ReportBytes, "aplication/pdf", ReportName);
        }

        public FileResult Excel()
        {
            string ReportName = "Relatorio_Pessoas.xls";
            byte[] ReportBytes = RenderReport("Excel");

            return File(ReportBytes, "application/excel", ReportName);
        }

        private byte[] RenderReport(string Type)
        {
            LocalReport LocalReport = new LocalReport();
            PersonTableAdapter PersonTableAdapter = new PersonTableAdapter();
            byte[] ReportBytes = null;
            Stopwatch sw = new Stopwatch();

            LocalReport.ReportPath = Server.MapPath("~/Reports/ReportPessoas.rdlc");

            sw.Start();
            LocalReport.DataSources.Add(new ReportDataSource("dsPessoas", (object)PersonTableAdapter.GetData()));
            sw.Stop();

            Debug.WriteLine("{0} - Carregando a Query e passando pra objetos", sw.Elapsed);

            sw.Restart();
            ReportBytes = LocalReport.Render(Type);
            sw.Stop();

            Debug.WriteLine("{0} - Montando o PDF", sw.Elapsed);

            return ReportBytes;
        }
    }
}