<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default1.aspx.cs" Inherits="To_DoListApp.Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Todo List</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">    
        <div class="container">
            <h1>Todo List</h1>
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
            <asp:CheckBox ID="chckStatus" runat="server" OnCheckedChanged="chckStatus_CheckedChanged" />
            <asp:Button ID="btnAdd" runat="server"  Text="Add"  OnClick="btnAdd_Click"  CssClass="btn btn-primary"/>
            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" 
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_OnRowCancelingEdit" DataKeyNames="Id">
                <Columns>
                     <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" Visible="false"  />
                      <asp:BoundField DataField="Title" HeaderText="Title"  />
                     <asp:CheckBoxField DataField="IsCompleted" HeaderText="Completed" />
                     <asp:CommandField ShowDeleteButton="true" ShowEditButton="True"  ShowCancelButton="True" ShowSelectButton="False" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha2/dist/js/bootstrap.bundle.min.js" type="text/javascript"> </script>
</body>
</html>
