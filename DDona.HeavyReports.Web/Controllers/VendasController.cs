using DDona.HeavyReports.RV.DataSets.dsReportVendasTableAdapters;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDona.HeavyReports.Web.Controllers
{
    public class VendasController : Controller
    {
        public FileResult PDF()
        {
            string ReportName = "Relatorio_Vendas.pdf";
            byte[] ReportBytes = RenderReport("PDF");

            return File(ReportBytes, "aplication/pdf", ReportName);
        }

        public FileResult Excel()
        {
            string ReportName = "Relatorio_Vendas.xls";
            byte[] ReportBytes = RenderReport("Excel");

            return File(ReportBytes, "application/excel", ReportName);
        }

        private byte[] RenderReport(string Type)
        {
            LocalReport LocalReport = new LocalReport();
            VendasTableAdapter VendasTableAdapter = new VendasTableAdapter();
            byte[] ReportBytes = null;
            Stopwatch sw = new Stopwatch();

            LocalReport.ReportPath = Server.MapPath("~/Reports/ReportVendas.rdlc");

            sw.Start();
            LocalReport.DataSources.Add(new ReportDataSource("dsVendas", (object)VendasTableAdapter.GetData()));
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