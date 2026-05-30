<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChatbotWebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome To ChatBot</title>
</head>

<body>

<form id="form1" runat="server">

    <table width="100%">

        <tr>

            <!-- ChatBot: structure-->
            <td width="50%" valign="top">

                <h3>Chatbot</h3>

                <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
                <br /><br />
                <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                <br /><br />
                <asp:Label ID="lblChat" runat="server"></asp:Label>

            </td>

            <!-- Task manager: structure -->
            <td width="50%" valign="top">

                <h3>Task Manager</h3>
                <asp:TextBox ID="txtTaskName" runat="server" placeholder="Task Name"></asp:TextBox>
                <br /><br />   
                <asp:TextBox ID="txtTaskDesc" runat="server" placeholder="Task Description"></asp:TextBox>
                <br /><br />
                <asp:TextBox ID="txtDueDate" runat="server" placeholder="Due Date (YYYY-MM-DD)"></asp:TextBox>
                <br /><br /> 
                <asp:Button ID="btnAddTask" runat="server" Text="Add Task" OnClick="btnAddTask_Click" />
                <asp:Button ID="btnViewTasks" runat="server" Text="View Tasks" OnClick="btnViewTasks_Click" />

                <br /><br />

                <asp:Label ID="lblTasks" runat="server"></asp:Label>

                <br /><br />

                <asp:GridView ID="gvTasks" runat="server"></asp:GridView>

            </td>

        </tr>

    </table>

</form>

</body>
</html>

