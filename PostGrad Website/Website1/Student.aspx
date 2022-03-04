<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Website1.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 778px;
        }
    </style>
</head>
<body style="height: 537px">
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="view_profile" runat="server" Text="View My Profile" onclick="viewprofile" Height="54px" Width="120px"/>
            <asp:Button ID="viewThesis" runat="server" Height="59px" onclick="viewMyThesis" style="margin-top: 4px" Text="View My theses" Width="122px" />
 
            <asp:Button ID="Button1" runat="server" OnClick="viewcourses" style="margin-top: 0px" Text="view My courses(Non-Gucians only)" Width="241px" />
 
            <asp:Button ID="Button2" runat="server" Text="Add Progress repoprt" OnClick="addprog" Height="25px" />
 
            <asp:Button ID="fill" runat="server" Text="fill progress report" OnClick="fill_Click" />
            <asp:Button ID="Button4" runat="server" Text="add publiation" OnClick="Button4_Click" />
 
            <asp:Button ID="links" runat="server" Text="link publication" OnClick="links_Click" />
 
            <asp:Button ID="Button5" runat="server" Text="add phone number" OnClick="Button5_Click" />
 
            <table style="width: 50%" runat="server" id="profile">
                    <tr>
                        <th>ID</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Type</th>
                        <th>Faculty</th>
                        <th>Address</th>
                        <th>GPA</th>
                        <th>undergrad ID</th>
                    </tr>
                </table>

        </div>
            <table style="width: 50%; margin-top: 0px;" runat="server" id="theses">
                    <tr>
                        <th></th>
                        <th>SerialNo</th>
                        <th>Field</th>
                        <th>Type</th>
                        <th>Title</th>
                        <th>Start Date</th>
                        <th>End date</th>
                        <th>defence date</th>
                        <th>years</th>
                        <th>Grade</th>
                        <th>Payment_id</th>
                        <th>Number of extensions</th>
                    </tr>
                </table>
        <table style="width: 50%" runat="server" id="courses">
                    <tr>
                        <th>Course Id</th>
                        <th>Grade</th>
                       
                    </tr>
                </table>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Thesis serial number is:"></asp:Label>
            <asp:TextBox ID="serialNumber" runat="server" Width="194px"></asp:TextBox>
            </p>
        <asp:Label ID="Label2" runat="server" Text="Progress report date is:"></asp:Label>
        <asp:TextBox ID="progressReportDate" TextMode="date" runat="server" Width="191px"></asp:TextBox>
        <p>
            <asp:Label ID="Label3" runat="server" Text="progress report number"></asp:Label>
            <asp:TextBox ID="progNo" runat="server" style="margin-left: 12px"></asp:TextBox>
            <asp:Button ID="submit1" runat="server" Text="submit" OnClick="submit" Height="25px" />
            </p>
        <asp:Label ID="Label4" runat="server" Text="title"></asp:Label>
        <asp:TextBox ID="Title" runat="server" style="margin-left: 21px; margin-right: 123px;" Width="161px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="publication date"></asp:Label>
        <asp:TextBox ID="pubdate" runat="server"  TextMode="date" style="margin-left: 18px" Width="210px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="host"></asp:Label>
        <asp:TextBox ID="host" runat="server" style="margin-left: 19px" Width="277px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="place"></asp:Label>
        <asp:TextBox ID="place" runat="server" style="margin-left: 23px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="accepted ?"></asp:Label>
         <asp:RadioButtonList ID="Radio" runat="server" CssClass="auto-style7" OnSelectedIndexChanged="acceptance">
                <asp:ListItem ID="accepted">accepted</asp:ListItem>
                <asp:ListItem ID="notaccepted">not_accepted</asp:ListItem>
            </asp:RadioButtonList>
        <asp:Button ID="submit3" runat="server" Text="submit" OnClick="submit3_Click" style="margin-left: 14px" />
        <br />
        <asp:Label ID="Label9" runat="server" Text="thesis serial number"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 16px; margin-bottom: 0px"></asp:TextBox>
        <br />
        <asp:Label ID="Label11" runat="server" Text="publication number"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 12px"></asp:TextBox>
        <asp:Button ID="linkpub" runat="server" Text="submit" OnClick="linkpub_Click" />
        <br />
        <br />
        <asp:Label ID="Label12" runat="server" Text="thesis serial number"></asp:Label>
        <asp:TextBox ID="serial2" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label13" runat="server" Text="progress report number"></asp:Label>
        <asp:TextBox ID="prg" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label14" runat="server" Text="state"></asp:Label>
        <asp:TextBox ID="state1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label15" runat="server" Text="description"></asp:Label>
        <asp:TextBox ID="des" runat="server"></asp:TextBox>
        <asp:Button ID="submits" runat="server" Text="submit" OnClick="submits_Click" />
        <br />
    </form>
</body>
</html>