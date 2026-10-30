<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyDetails.aspx.cs" Inherits="P9_Placement_Dashboard.CompanyDetails" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Company Placement Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Company-wise Placement Details</h1>
        <asp:Label ID="lblMessage" runat="server" />

        <h2>Company Summary</h2>
        <asp:GridView ID="gvCompanySummary" runat="server" />

        <h2>Student and Job Details</h2>
        <asp:GridView ID="gvCompanyStudents" runat="server" />

        <p><a href="Dashboard.aspx">Back to Dashboard</a></p>
    </form>
</body>
</html>
