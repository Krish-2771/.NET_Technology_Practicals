<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AttendanceReport.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Login - Attendance Report</title>

    <style>

        body {
            font-family: Arial;
            background-color: #f2f5f9;
            margin: 0;
        }

        .header {
            background-color: #1f4e79;
            color: white;
            padding: 25px;
            text-align: center;
        }

        .login-container {
            width: 400px;
            margin: 70px auto;
            background-color: white;
            padding: 35px;
            border-radius: 10px;
            box-shadow: 0px 0px 12px #cccccc;
        }

        h2 {
            text-align: center;
            color: #1f4e79;
        }

        .row {
            margin-bottom: 20px;
        }

        .label {
            display: block;
            font-weight: bold;
            margin-bottom: 7px;
        }

        .textbox {
            width: 95%;
            padding: 11px;
            border: 1px solid #cccccc;
            border-radius: 5px;
        }

        .checkbox {
            margin-bottom: 15px;
        }

        .button {
            width: 100%;
            background-color: #1f4e79;
            color: white;
            border: none;
            padding: 12px;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
        }

        .button:hover {
            background-color: #163a5c;
        }

        .error {
            color: red;
            font-size: 13px;
        }

        .message {
            display: block;
            text-align: center;
            margin-top: 15px;
            color: red;
            font-weight: bold;
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <div class="header">

        <h1>Attendance Report System</h1>

        <p>Student Login</p>

    </div>


    <div class="login-container">

        <h2>Login</h2>


        <!-- User ID -->

        <div class="row">

            <span class="label">
                User ID
            </span>

            <asp:TextBox
                ID="txtUserID"
                runat="server"
                CssClass="textbox">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvUserID"
                runat="server"
                ControlToValidate="txtUserID"
                ErrorMessage="User ID is required."
                CssClass="error">
            </asp:RequiredFieldValidator>

        </div>


        <!-- Password -->

        <div class="row">

            <span class="label">
                Password
            </span>

            <asp:TextBox
                ID="txtPassword"
                runat="server"
                CssClass="textbox"
                TextMode="Password">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvPassword"
                runat="server"
                ControlToValidate="txtPassword"
                ErrorMessage="Password is required."
                CssClass="error">
            </asp:RequiredFieldValidator>

        </div>


        <!-- Remember Me -->

        <div class="checkbox">

            <asp:CheckBox
                ID="chkRemember"
                runat="server"
                Text=" Remember Me" />

        </div>


        <!-- Login Button -->

        <asp:Button
            ID="btnLogin"
            runat="server"
            Text="Login"
            CssClass="button"
            OnClick="btnLogin_Click" />


        <asp:Label
            ID="lblMessage"
            runat="server"
            CssClass="message">
        </asp:Label>

    </div>

</form>

</body>

</html>