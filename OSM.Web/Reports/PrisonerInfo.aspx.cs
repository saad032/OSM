using System;
using System.Linq;
using OSM.Interfaces.IServices;
using OSM.Web.ModelMappers;
using OSM.WebBase.UnityConfiguration;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using OSM.Interfaces.IServices;
using OSM.Models.RequestModels;

namespace OSM.Web.Reports
{
    public partial class PrisonerInfo : System.Web.UI.Page
    {

        public IPrisonerService PrisonerService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            SetupReport();
        }

        private void SetupReport()
        {

            var id = Request.QueryString["id"];
            PrisonerService = UnityWebActivator.Container.Resolve<IPrisonerService>();

            PrisonerViewer1.ProcessingMode = ProcessingMode.Local;
            PrisonerViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/PrisonerInfo.rdlc");
            PrisonerSearchRequest request = new PrisonerSearchRequest();
            request.Id = Convert.ToInt32(id);
            
            ReportDataSource reportDataSource = new ReportDataSource
            {
                Name = "DataSet1",
                Value = PrisonerService.GetAllPrisoners(request).Prisoners.Select(x=> x.CreateFrom())
            };

            PrisonerViewer1.LocalReport.EnableExternalImages = true;
            PrisonerViewer1.LocalReport.EnableHyperlinks = true;
            PrisonerViewer1.HyperlinkTarget = "_blank";
            PrisonerViewer1.LinkActiveColor = System.Drawing.Color.Blue;
            PrisonerViewer1.LocalReport.DataSources.Clear();
            PrisonerViewer1.LocalReport.DataSources.Add(reportDataSource);

        }
    }
}