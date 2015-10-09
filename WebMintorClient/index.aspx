<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebMintorClient.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddl_ip" runat="server"></asp:DropDownList>
        <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
        <br />
        <%=htmlTable %>
    </div>
    </form>
</body>
</html>
