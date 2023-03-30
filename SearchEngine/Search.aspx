<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SearchEngine.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="searchTerm" runat="server" ></asp:TextBox>
            <asp:Button ID="searchBtn" runat="server" OnClick="DoSearch" Text="Search..."/>
        </div>
        <br />
        <div id="resultsSearch" runat="server">

        </div>
    </form>
</body>
</html>
