<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="EventRegistration.aspx.cs"
    Inherits="Event_Registration.EventRegistration"
    EnableEventValidation="false" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>Online Event Registration Form</title>
    <script type="text/javascript">

    var posters = [
        "Posters/Technical_Workshop.png",
        "Posters/Coding_Competition.png",
        "Posters/Hackathon.png",
        "Posters/Seminar.png"
    ];

    var currentPoster = 0;

    function nextPoster() {

        currentPoster++;

        if (currentPoster >= posters.length) {
            currentPoster = 0;
        }

        document.getElementById("posterImage").src =
            posters[currentPoster];
    }

    function previousPoster() {

        currentPoster--;

        if (currentPoster < 0) {
            currentPoster = posters.length - 1;
        }

        document.getElementById("posterImage").src =
            posters[currentPoster];
    }

</script>
</head>

<body>

<form id="form1" runat="server">

    <h2>Online Event Registration Form</h2>

    <hr />

    <table>

        <!-- Name -->
        <tr>
            <td>Enter Name :</td>
            <td>
                <asp:TextBox
                    ID="txtName"
                    runat="server">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="rfvName"
                    runat="server"
                    ControlToValidate="txtName"
                    ErrorMessage="Student Name is required"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <!-- Enrollment Number -->
        <tr>
            <td>Enter Enrollment No. :</td>
            <td>
                <asp:TextBox
                    ID="txtEnrollment"
                    runat="server">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="rfvEnrollment"
                    runat="server"
                    ControlToValidate="txtEnrollment"
                    ErrorMessage="Student Enrollment No is required"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <!-- Email -->
        <tr>
            <td>Enter Email :</td>
            <td>
                <asp:TextBox
                    ID="txtEmail"
                    runat="server">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="rfvEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    ErrorMessage="Email is required"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator
                    ID="revEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    ErrorMessage="Enter Valid Email"
                    ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                    ForeColor="Red">
                </asp:RegularExpressionValidator>
            </td>
        </tr>

        <!-- Age -->
        <tr>
            <td>Enter Age :</td>
            <td>
                <asp:TextBox
                    ID="txtAge"
                    runat="server">
                </asp:TextBox>

                <asp:RangeValidator
                    ID="rvAge"
                    runat="server"
                    ControlToValidate="txtAge"
                    MinimumValue="18"
                    MaximumValue="40"
                    Type="Integer"
                    ErrorMessage="Age should be between 18 to 40"
                    ForeColor="Red">
                </asp:RangeValidator>
            </td>
        </tr>

        <!-- Password -->
        <tr>
            <td>Password :</td>
            <td>
                <asp:TextBox
                    ID="txtPassword"
                    runat="server"
                    TextMode="Password">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="rfvPassword"
                    runat="server"
                    ControlToValidate="txtPassword"
                    ErrorMessage="Password is required"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <!-- Confirm Password -->
        <tr>
            <td>Confirm Password :</td>
            <td>
                <asp:TextBox
                    ID="txtConfirmPassword"
                    runat="server"
                    TextMode="Password">
                </asp:TextBox>

                <asp:CompareValidator
                    ID="cvPassword"
                    runat="server"
                    ControlToValidate="txtConfirmPassword"
                    ControlToCompare="txtPassword"
                    ErrorMessage="Password and Confirm Password should match"
                    ForeColor="Red">
                </asp:CompareValidator>
            </td>
        </tr>

        <!-- Branch -->
        <tr>
    <td>Select Branch :</td>
    <td>
        <asp:DropDownList
            ID="ddlBranch"
            runat="server">

            <asp:ListItem Text="-- Select Branch --"
                          Value="">
            </asp:ListItem>

            <asp:ListItem Text="Computer Engineering"
                          Value="Computer Engineering">
            </asp:ListItem>

            <asp:ListItem Text="Information Technology"
                          Value="Information Technology">
            </asp:ListItem>

            <asp:ListItem Text="Mechanical Engineering"
                          Value="Mechanical Engineering">
            </asp:ListItem>

            <asp:ListItem Text="Electrical Engineering"
                          Value="Electrical Engineering">
            </asp:ListItem>

        </asp:DropDownList>

        <asp:RequiredFieldValidator
            ID="rfvBranch"
            runat="server"
            ControlToValidate="ddlBranch"
            InitialValue=""
            ErrorMessage="Select Branch"
            ForeColor="Red">
        </asp:RequiredFieldValidator>
    </td>
</tr>

        <!-- Gender -->
        <tr>
            <td>Gender :</td>
            <td>

                <asp:RadioButtonList
                    ID="rblGender"
                    runat="server"
                    RepeatDirection="Horizontal">

                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>

                </asp:RadioButtonList>

                <asp:RequiredFieldValidator
                    ID="rfvGender"
                    runat="server"
                    ControlToValidate="rblGender"
                    ErrorMessage="Select Gender"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>

            </td>
        </tr>

        <!-- Event Type -->
        <tr>
            <td>Event Type :</td>
            <td>

                <asp:CheckBoxList
                    ID="cblEvent"
                    runat="server">

                    <asp:ListItem>
                        Technical Workshop
                    </asp:ListItem>

                    <asp:ListItem>
                        Coding Competition
                    </asp:ListItem>

                    <asp:ListItem>
                        Hackathon
                    </asp:ListItem>

                    <asp:ListItem>
                        Seminar
                    </asp:ListItem>

                </asp:CheckBoxList>

            </td>
        </tr>

        <!-- Select Date -->
        <tr>
            <td>Select Date :</td>
            <td>

                <asp:Calendar
                    ID="calEventDate"
                    runat="server"
                    OnSelectionChanged="calEventDate_SelectionChanged">
                </asp:Calendar>

                <br />

                Selected Date :

                <asp:Label
                    ID="lblDate"
                    runat="server">
                </asp:Label>

            </td>
        </tr>

        <!-- Poster Slider -->
        <tr>
            <td>Poster :</td>

            <td>

                <input type="button" value="<" onclick="previousPoster()" />

<img id="posterImage"
     src="Posters/TechnicalWorkshop.png"
     width="300"
     height="200" />

<input type="button" value=">" onclick="nextPoster()" />

            </td>
        </tr>

        <!-- Register and Clear -->
        <tr>
            <td></td>

            <td>

                <asp:Button
                    ID="btnRegister"
                    runat="server"
                    Text="Register"
                    OnClick="btnRegister_Click">
                </asp:Button>

                &nbsp;&nbsp;

                <asp:Button
                    ID="btnClear"
                    runat="server"
                    Text="Clear"
                    CausesValidation="false"
                    OnClick="btnClear_Click">
                </asp:Button>

            </td>
        </tr>

    </table>

    <br />

    <!-- Validation Summary -->

    <asp:ValidationSummary
        ID="ValidationSummary1"
        runat="server"
        HeaderText="Summary"
        ForeColor="Black">
    </asp:ValidationSummary>

    <br />

    <asp:Label
        ID="lblMessage"
        runat="server"
        ForeColor="Green">
    </asp:Label>

</form>

</body>
</html>