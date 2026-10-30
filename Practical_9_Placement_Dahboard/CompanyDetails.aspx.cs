using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace P9_Placement_Dashboard
{
    public partial class CompanyDetails : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                gvCompanySummary.DataSource = GetData(
                    "SELECT CompanyName, COUNT(*) AS StudentsHired, MIN(PackageLPA) AS MinimumPackage, " +
                    "MAX(PackageLPA) AS HighestPackage, AVG(PackageLPA) AS AveragePackage " +
                    "FROM dbo.Placements GROUP BY CompanyName ORDER BY CompanyName");
                gvCompanySummary.DataBind();

                gvCompanyStudents.DataSource = GetData(
                    "SELECT p.PlacementId, s.StudentName, s.Department, p.CompanyName, p.JobRole, p.PackageLPA " +
                    "FROM dbo.Placements p INNER JOIN dbo.Students s ON p.StudentId = s.StudentId " +
                    "ORDER BY p.CompanyName, s.StudentName");
                gvCompanyStudents.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + Server.HtmlEncode(ex.Message);
            }
        }

        DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            new SqlDataAdapter(sql, connStr).Fill(dt);
            return dt;
        }
    }
}
