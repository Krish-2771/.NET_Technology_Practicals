<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="LeaveReport.aspx.cs"
    Inherits="AcademicCalendarPractical.LeaveReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Leave Application</title>

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
            width: 650px;
            margin: 35px auto;
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0px 0px 10px #cccccc;
        }

        .row {
            margin-bottom: 18px;
        }

        .label {
            display: block;
            font-weight: bold;
            margin-bottom: 6px;
        }

        .textbox {
            width: 95%;
            padding: 10px;
            border: 1px solid #cccccc;
            border-radius: 5px;
        }

        .dropdown {
            width: 99%;
            padding: 10px;
            border: 1px solid #cccccc;
            border-radius: 5px;
        }

        .button {
            background-color: #1f4e79;
            color: white;
            border: none;
            padding: 12px 25px;
            border-radius: 5px;
            cursor: pointer;
        }

        .error {
            color: red;
            font-size: 13px;
        }

        .success {
            color: green;
            font-weight: bold;
        }

        .selected-date {
            background-color: #eaf3ff;
            padding: 12px;
            border-left: 5px solid #1f4e79;
            margin-bottom: 20px;
        }

        .logout-button {
            background-color: #dc3545;
            color: white;
            border: none;
            padding: 9px 18px;
            border-radius: 5px;
            cursor: pointer;
        }

        .logout-button:hover {
            background-color: #b52a37;
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <div class="header">

        <h1>Leave Application Form</h1>

        <p>Student Leave Management</p>

    </div>


    <div class="container">

        <div style="text-align: right; margin-bottom: 15px;">

        <asp:Button
            ID="btnLogout"
            runat="server"
            Text="Logout"
            CssClass="logout-button"
            OnClick="btnLogout_Click" 
            CausesValidation="false" />
            
        </div>

        <div class="selected-date">

            <strong>Selected Leave Date:</strong>

            <asp:Label
                ID="lblSelectedDate"
                runat="server">
            </asp:Label>

        </div>


        <!-- Student Name -->

        <div class="row">

            <span class="label">
                Student Name
            </span>

            <asp:TextBox
                ID="txtName"
                runat="server"
                CssClass="textbox">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvName"
                runat="server"
                ControlToValidate="txtName"
                ErrorMessage="Student name is required."
                CssClass="error">
            </asp:RequiredFieldValidator>

        </div>


        <!-- Student ID -->

        <div class="row">

            <span class="label">
                Student ID (Full Enrollment no.)
            </span>

            <asp:TextBox
                ID="txtStudentID"
                runat="server"
                CssClass="textbox">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvStudentID"
                runat="server"
                ControlToValidate="txtStudentID"
                ErrorMessage="Student ID is required."
                CssClass="error">
            </asp:RequiredFieldValidator>

        </div>


        <!-- Email -->

        <div class="row">

            <span class="label">
                Email
            </span>

            <asp:TextBox
                ID="txtEmail"
                runat="server"
                CssClass="textbox">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvEmail"
                runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Email is required."
                CssClass="error">
            </asp:RequiredFieldValidator>

        </div>


        <!-- Leave Type -->

        <div class="row">

            <span class="label">
                Leave Type
            </span>

            <asp:DropDownList
                ID="ddlLeaveType"
                runat="server"
                CssClass="dropdown">

                <asp:ListItem
                    Text="-- Select Leave Type --"
                    Value="">
                </asp:ListItem>

                <asp:ListItem
                    Text="Medical Leave"
                    Value="Medical">
                </asp:ListItem>

                <asp:ListItem
                    Text="Personal Leave"
                    Value="Personal">
                </asp:ListItem>

                <asp:ListItem
                    Text="Emergency Leave"
                    Value="Emergency">
                </asp:ListItem>

                <asp:ListItem
                    Text="Other"
                    Value="Other">
                </asp:ListItem>

            </asp:DropDownList>

            <asp:RequiredFieldValidator
                ID="rfvLeaveType"
                runat="server"
                ControlToValidate="ddlLeaveType"
                InitialValue=""
                ErrorMessage="Please select leave type."
                CssClass="error">
            </asp:RequiredFieldValidator>

        </div>


        <!-- From Date -->

        <div class="row">

            <span class="label">
                From Date
            </span>

            <asp:TextBox
                ID="txtFromDate"
                runat="server"
                CssClass="textbox"
                TextMode="Date">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvFromDate"
                runat="server"
                ControlToValidate="txtFromDate"
                ErrorMessage="From date is required."
                CssClass="error">
            </asp:RequiredFieldValidator>

        </div>


        <!-- To Date -->

        <div class="row">

            <span class="label">
                To Date
            </span>

            <asp:TextBox
                ID="txtToDate"
                runat="server"
                CssClass="textbox"
                TextMode="Date">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvToDate"
                runat="server"
                ControlToValidate="txtToDate"
                ErrorMessage="To date is required."
                CssClass="error">
            </asp:RequiredFieldValidator>

        </div>


        <!-- Reason -->

        <div class="row">

            <span class="label">
                Reason for Leave
            </span>

            <asp:TextBox
                ID="txtReason"
                runat="server"
                CssClass="textbox"
                TextMode="MultiLine"
                Rows="5">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvReason"
                runat="server"
                ControlToValidate="txtReason"
                ErrorMessage="Please enter reason for leave."
                CssClass="error">
            </asp:RequiredFieldValidator>

        </div>


        <!-- Submit -->

        <asp:Button
            ID="btnSubmit"
            runat="server"
            Text="Submit Leave Application"
            CssClass="button"
            OnClick="btnSubmit_Click" />

        <br /><br />

        <asp:Label
            ID="lblMessage"
            runat="server"
            CssClass="success">
        </asp:Label>

    </div>

</form>

</body>

</html>