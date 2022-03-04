<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchThesis.aspx.cs" Inherits="Website1.SearchThesis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SearchThesis</title>
</head>
<body>
    <h1>Thesis Search</h1>
    <form id="form1" runat="server">

        <div>

            <asp:Label ID="Label1" runat="server" Text="Enter a Keyword to get All Matching Thesis Titles:"></asp:Label>
            <asp:Button ID="returnToExaminer" runat="server" Text="Return to Examiner Page" Height="28px" OnClick="returnToExaminer_Click" align ="right"/>
            <br />
            <asp:TextBox ID="ThesisTitleInput" runat="server" Width="453px"></asp:TextBox>


            <br />
            <asp:Button ID="thesisSearch" runat="server" Text="Search" OnClick="thesisSearch_Click" />


        </div>
    </form>
</body>
</html>
