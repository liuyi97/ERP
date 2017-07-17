<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingHouse.aspx.cs" Inherits="WebApplication1.Product.UsingHouse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        table td{
            border:1px solid #808080;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    库房选择：<asp:DropDownList ID="DDLSelect" runat="server" OnSelectedIndexChanged="DDLSelect_SelectedIndexChanged" AutoPostBack="True">
            
        </asp:DropDownList><br />
        <asp:DataList ID="DLHouse" runat="server" ItemStyle-Width= "50%" Width="51%" Height="94px">
            
            <HeaderTemplate>
                        ID
                        <td style="width:50%;">库区</td>
            </HeaderTemplate>

<ItemStyle Width="50%"></ItemStyle>
            <ItemTemplate>
                    <tr>                        
                        <td><%#Eval("HouseID") %></td>
                        <td><%#Eval("SubareaName") %></td>
                        <td>
                            <input type="button" onclick="kuqu(<%#Eval("HouseID") %>)" value="选择" /></td> 
                    </tr>
            </ItemTemplate>
        </asp:DataList>
    </div>
    </form>
    <script src="../Script/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          function kuqu(id) {
              var kuqu = $("#DDLSelect option[selected=selected]").val();
              window.opener.document.getElementById("txtHouse").value = kuqu;
              window.opener.document.getElementById("txtArea").value = id;
              window.close();
          }
    </script>
</body>
</html>
