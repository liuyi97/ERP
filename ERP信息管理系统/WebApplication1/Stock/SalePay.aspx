<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalePay.aspx.cs" Inherits="WebApplication1.Stock.SalePay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script src="../UI/jquery.min.js"></script>
    <script src="../UI/jquery.easyui.min.js"></script>   
    <link href="../UI/themes/icon.css" rel="stylesheet" />
    <link href="../UI/themes/default/easyui.css" rel="stylesheet" />
    <script src="../UI/locale/easyui-lang-zh_CN.js"></script>
    <link href="../css/salepay.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <%--标题--%>
    <p class="size">采购付款</p>
      <table style="float:left;margin-left:10px;margin-top:10px;">
          <tr>
              <td>采购单号：</td>
              <td>
                <%--  <asp:TextBox ID="TextBox1" class="CurledLineMiddle" Width="170px" runat="server"></asp:TextBox>--%>
                  <asp:DropDownList ID="DropDownList2" Width="170px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
              </td>
              <td>制单日期：</td>
              <td>
                  <asp:TextBox ID="TextBox1" class="CurledLineMiddle" Width="120px" ForeColor="Red" style="font-size:12px;" runat="server"></asp:TextBox></td>
              <td>票&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号：</td>
              <td>
                  <asp:TextBox ID="TextBox2" class="CurledLineMiddle" Width="70px" Text="无" runat="server"></asp:TextBox></td>
          </tr>
           <tr>
              <td>单据总额：</td>
              <td> <asp:TextBox ID="TextBox3" class="CurledLineMiddle" Width="70px" runat="server"></asp:TextBox></td>
              <td>已付金额：</td>
              <td> <asp:TextBox ID="TextBox4" class="CurledLineMiddle" Width="70px" runat="server"></asp:TextBox></td>
              <td>支付类型：</td>
              <td>
                  <asp:DropDownList ID="DropDownList1" Width="90px" runat="server"></asp:DropDownList></td>
          </tr>
           <tr>
              <td>实付金额：</td>
              <td> <asp:TextBox ID="TextBox5" class="CurledLineMiddle" Width="70px" runat="server"></asp:TextBox></td>
              <td>附加金额：</td>
              <td> <asp:TextBox ID="TextBox6" class="CurledLineMiddle" Width="70px" runat="server"></asp:TextBox></td>
              <td style="font-size:10px; ">(其他费用)</td>
          </tr>
          <tr>
              <td>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
              <td> <asp:TextBox ID="TextBox7" class="CurledLineMiddle" Width="170px" runat="server"></asp:TextBox></td>
               <td></td>
              <td>
                 <%--   <input type="button" name="name" id="btn"  value="提交" />--%>
               <asp:Button ID="Button1" Width="40px" Height="30px" runat="server" Text="提交" OnClick="Button1_Click" /></td>
          </tr>
      </table>

    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#btn").css(
                { "width": "60px", "height": "30px" }
                )

            //$("#begintime").datebox({
            //    required: true,
            //    eaditable: true,
            //    width:100
            //})
        })
    </script>
</body>
</html>
