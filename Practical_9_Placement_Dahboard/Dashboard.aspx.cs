using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace P9_Placement_Dashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int total = GetCount("SELECT COUNT(*) FROM dbo.Students");
                int placed = GetCount("SELECT COUNT(*) FROM dbo.Students WHERE IsPlaced = 1");
                int companies = GetCount("SELECT COUNT(DISTINCT CompanyName) FROM dbo.Placements");

                lblTotal.Text = total.ToString();
                lblPlaced.Text = placed.ToString();
                lblNotPlaced.Text = (total - placed).ToString();
                lblCompanies.Text = companies.ToString();
                lblPercent.Text = (total == 0 ? 0 : placed * 100.0 / total).ToString("0.00") + "%";

                string sql = "SELECT s.StudentId, s.EnrollmentNo, s.StudentName, s.Department, s.PassingYear, " +
                             "CASE WHEN s.IsPlaced = 1 THEN 'Placed' ELSE 'Not Placed' END AS Status, " +
                             "p.CompanyName, p.JobRole, p.PackageLPA " +
                             "FROM dbo.Students s LEFT JOIN dbo.Placements p ON s.StudentId = p.StudentId " +
                             "ORDER BY s.StudentId";
                DataTable dt = new DataTable();
                new SqlDataAdapter(sql, connStr).Fill(dt);
                gvStudents.DataSource = dt;
                gvStudents.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + Server.HtmlEncode(ex.Message);
            }
        }

        int GetCount(string sql)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                return Convert.ToInt32(new SqlCommand(sql, con).ExecuteScalar());
            }
        }
    }
}
