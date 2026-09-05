<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcademicCalender.aspx.cs"
    Inherits="AttendanceReport.AcademicCalender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Academic Calendar</title>

    <style>

        body {
            font-family: Arial;
            background-color: #f2f5f9;
            margin: 0;
        }

        .header {
            background-color: #1f4e79;
            color: white;
            padding: 20px;
            text-align: center;
        }

        .container {
            width: 700px;
            margin: 40px auto;
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            text-align: center;
            box-shadow: 0px 0px 10px #cccccc;
        }

        .calendar {
            margin: auto;
        }

        .button {
            background-color: #1f4e79;
            color: white;
            border: none;
            padding: 12px 25px;
            margin: 15px;
            border-radius: 5px;
            font-size: 15px;
            cursor: pointer;
        }

        .button:hover {
            background-color: #163a5c;
        }

        .date {
            font-size: 18px;
            font-weight: bold;
            color: #1f4e79;
            margin: 20px;
        }

        .success {
                display: block;
                background-color: #d4edda;
                color: #155724;
                border: 1px solid #c3e6cb;
                padding: 12px;
                margin-bottom: 20px;
                border-radius: 5px;
                font-weight: bold;
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <div class="header">

        <h1>Academic Calendar</h1>

        <p>Student Academic Management System</p>

    </div>


    <div class="container">

        <h2>Select Date</h2>

        <asp:Label
            ID="lblSuccess"
            runat="server"
            CssClass="success">
        </asp:Label>

        <br /> 
        <asp:Calendar
            ID="Calendar1"
            runat="server"
            CssClass="calendar"
            BackColor="White"
            BorderColor="#999999"
            CellPadding="4"
            DayNameFormat="Shortest"
            Font-Names="Arial"
            Font-Size="10pt"
            ForeColor="Black"
            ShowGridLines="True"
            OnSelectionChanged="Calendar1_SelectionChanged">

            <SelectedDayStyle
                BackColor="#1f4e79"
                Font-Bold="True"
                ForeColor="White" />

            <TitleStyle
                BackColor="#1f4e79"
                Font-Bold="True"
                ForeColor="White" />

            <TodayDayStyle
                BackColor="#e6f0fa"
                ForeColor="Black" />

        </asp:Calendar>


        <asp:Label
            ID="lblDate"
            runat="server"
            CssClass="date"
            Text="Please select a date">
        </asp:Label>


        <br />

        <asp:Button
            ID="btnAttendance"
            runat="server"
            Text="Submit Attendance"
            CssClass="button"
            OnClick="btnAttendance_Click" />


        <asp:Button
            ID="btnLeave"
            runat="server"
            Text="Leave Report"
            CssClass="button"
            OnClick="btnLeave_Click" />

    </div>

</form>

</body>

</html>