<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerDataList.aspx.cs" Inherits="Website1.examinerDataList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <h1>Examiner Data</h1>
</head>
<body>
    <h2> View All personell and thesis of the defense you attended:</h2>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="returnToExaminer" runat="server" Text="Return to Examiner Page" Height="28px" OnClick="returnToExaminer_Click" align ="right"/>
            
            <br />
            <asp:Button ID="displayPersonel" runat="server" Text="Click here to Display Data in a Table" OnClick="displayPersonel_Click" />
        </div>
    </form>
</body>
</html>
