<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="P9_Placement_Dashboard.Dashboard" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Placement Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Student Placement Dashboard</h1>
        <asp:Label ID="lblMessage" runat="server" />

        <h2>Summary</h2>
        <table border="1" cellpadding="5">
            <tr><td>Total Students</td><td><asp:Label ID="lblTotal" runat="server" /></td></tr>
            <tr><td>Students Placed</td><td><asp:Label ID="lblPlaced" runat="server" /></td></tr>
            <tr><td>Not Placed</td><td><asp:Label ID="lblNotPlaced" runat="server" /></td></tr>
            <tr><td>Companies</td><td><asp:Label ID="lblCompanies" runat="server" /></td></tr>
            <tr><td>Placement Percentage</td><td><asp:Label ID="lblPercent" runat="server" /></td></tr>
        </table>

        <h2>Student Placement Details</h2>
        <asp:GridView ID="gvStudents" runat="server" />

        <p><a href="CompanyDetails.aspx">View Company-wise Placement Details</a></p>
    </form>
</body>
</html>
