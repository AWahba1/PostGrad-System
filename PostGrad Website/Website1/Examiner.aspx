<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examiner.aspx.cs" Inherits="Website1.Examiner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Examiner Page </title>
</head>
<body>
    <h1> Welcome Examiner</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="ID:"></asp:Label>
&nbsp;&nbsp;&nbsp; <asp:Label ID="idPlace" runat="server" Text="[id]"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
            <asp:Label ID="namePlace" runat="server" Text="[name]"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Field Of Work:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
            <asp:Label ID="fieldOfWorkPlace" runat="server" Text="[fieldOfWork]"></asp:Label>
        </div>

        <div>

            <asp:Button ID="signOut" runat="server" Text="Click Here to Sign Out" OnClick="signOut_Click" />

        </div>
        <h2>Edit your Personal Information:</h2>
        <div>

            <asp:Label ID="Label12" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="emailInput" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label13" runat="server" Text="Password:"></asp:Label>

            <asp:TextBox ID="passInput" runat="server"></asp:TextBox>

        </div>
            <asp:Button ID="editPersonalInfo" runat="server" Text="Click here to Edit Personal Informaton" OnClick="editPersonalInfo_Click" />

        <br />
        <h2>Edit your data:</h2>
        <asp:Label ID="label4" runat="server" Text="New Name:" BorderStyle="Inset"></asp:Label>
        <br />
        <asp:TextBox ID="nameInput" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="New Field of Work:" BorderStyle="Inset"></asp:Label>
        <br />
        <asp:TextBox ID="placeOfWorkInput" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="editProfile" runat="server" Text="Click to Edit Profile" OnClick="editProfile_Click" />

        <h2>Click Button Below to view all personell and thesis of the defense you attended:</h2>
        <div>

            <asp:Button ID="goToSelectAttendees" runat="server" OnClick="Button1_Click" Text="Go To Select Attendees" Width="422px" />

        </div>
        <h2>Click the Button Below to search for a Thesis</h2>
        <div>

            <asp:Button ID="Button2" runat="server" Text="Click here to go to Search for a Thesis" OnClick="Button2_Click" />

        </div>
        <h2>Fill the fields Below to add Comment to a Defense:</h2>
        <div>

            <asp:Label ID="label6" runat="server" Text="Thesis Serial Number:"></asp:Label>

            <br />

            <asp:TextBox ID="thesisSerialNoInput" runat="server" Width="231px" type="number"></asp:TextBox>

            <br />
            <asp:Label ID="Label7" runat="server" Text="Defense Date:"></asp:Label>

            <br />

            <asp:TextBox ID="defenseDateInput" runat="server" OnTextChanged="DefenseDate_TextChanged" Width="237px" type="date"></asp:TextBox>

            <br />
            <asp:Label ID="Label8" runat="server" Text="Comment:"></asp:Label>

            <br />
            <asp:TextBox ID="commentInput" runat="server" Height="159px" Width="827px" maxLength ="300"></asp:TextBox>

            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit Comment" Width="691px" align ="center" OnClick="Button1_Click1" />

        </div>
        <h2>Add Grade for a defense:</h2>
        <div>

            <asp:Label ID="Label9" runat="server" Text="Thesis Serial Number:"></asp:Label>

            <br />
            <asp:TextBox ID="thesisSerialNo2" runat="server" type="number"></asp:TextBox>

            <br />
            <asp:Label ID="Label10" runat="server" Text="Defense Date:"></asp:Label>

            <br />
            <asp:TextBox ID="defenseDate2" runat="server" Width="201px" type="date"></asp:TextBox>

            <br />
            <asp:Label ID="Label11" runat="server" Text="Grade Assigned to Thesis:"></asp:Label>

            <br />
            <asp:TextBox ID="thesisGrade" runat="server" Width="228px" type="number" min="0" max="99.99"></asp:TextBox>

            <br />
            <asp:Button ID="submitGrade" runat="server" Text="Submit Grade" Width="311px" OnClick="submitGrade_Click" />



        </div>

    </form>
</body>
</html>
