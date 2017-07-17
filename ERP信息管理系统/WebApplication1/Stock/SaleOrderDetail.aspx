<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleOrderDetail.aspx.cs" Inherits="WebApplication1.Stock.SaleOrderDetail" %>

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
    <link href="../css/saleorderdetail.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
    <p class="size">采购单明细</p>
        <div id="Top">
            <table style="float:left;margin-left:10px;margin-top:10px;">
                <tr style="margin-top:15px">
                    <td>采购&nbsp;单号：</td>
                    <td>
                        <asp:TextBox ID="TextBox1" class="CurledLineMiddle "  runat="server"></asp:TextBox></td>
                    <td>制单日期：</td>
                    <td id="begintime">
                       <asp:TextBox ID="TextBox2" Height="30px" class="CurledLineMiddle" Width="100px" runat="server"></asp:TextBox> </td>
                    <td>制&nbsp;&nbsp;单&nbsp;&nbsp;人：</td>
                    <td> <asp:TextBox ID="TextBox3" class="CurledLineMiddle " width="70px" runat="server"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td>库房/库区：</td>
                    <td><asp:TextBox ID="TextBox4"  Width="50px" class="CurledLineMiddle "   runat="server"></asp:TextBox><asp:TextBox ID="TextBox5" Width="50px" class="CurledLineMiddle " runat="server"></asp:TextBox>
                        
                    </td>
                    <td>业务代表：</td>
                    <td><asp:TextBox ID="TextBox6" class="CurledLineMiddle " Width="70px" runat="server"></asp:TextBox></td>
                    <td>状&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;态：</td>
                    <td><asp:TextBox ID="TextBox7" class="CurledLineMiddle " ForeColor="Red" width="70px" runat="server"></asp:TextBox></td>
                </tr>
                <tr style="margin-top:15px">
                     <td>签订&nbsp;日期：</td>
                    <td id="ordertime">
                           <asp:TextBox ID="TextBox8" class="CurledLineMiddle" Height="30px" Width="100px" runat="server"></asp:TextBox> 
                    </td>
                    <td>交货日期：</td>
                    <td id="endtime">
                           <asp:TextBox ID="TextBox9" class="CurledLineMiddle" Height="30px" Width="100px" runat="server"></asp:TextBox> 
                    </td>
                </tr>
                   <tr>
                     <td>交货&nbsp;地址：</td>
                    <td><asp:TextBox ID="TextBox10" Width="200px"  class="CurledLineMiddle " runat="server"></asp:TextBox></td>
                </tr>
                     <tr style="margin-top:15px">
                     <td>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
                    <td><asp:TextBox ID="TextBox11"  Width="200px" class="CurledLineMiddle " runat="server"></asp:TextBox></td>
                </tr>
            </table>

        </div>
        <div id="end">


        </div>

    </div>
    </form>
    <script type="text/javascript">
        $(function () {

            $("#end").datagrid({
                height: 200,
                fitColumns: true,
                pagination: true,
                pageList: [5, 10, 15, 20],
                pageSize: 5,
                url: "ashx/ProductSelect.ashx",
                columns: [[
                  //{ "field": "ck", checkbox: true, "title": "操作", "align": "center", width: 80 },
                    { field: "ProductsID", title: "商品编号", align: "center", width: 80 },
                    { field: "ProductsName", title: "商品名称", align: "center", width: 80 },
                    { field: "SupplierName", title: "供应商", align: "center", width: 80 },
                    { field: "Quantity", title: "数量", align: "center", width: 80 },
                    { field: "TotalPrice", title: "采购额", align: "center", width: 80 },
                    { field: "DiscountRate", title: "折扣额", align: "center", width: 80 },
                    { field: "TaxRate", title: "税额", align: "center", width: 80 },
                    { field: "Price", title: "金额", align: "center", width: 80 }
                ]]
            })

        })

    </script>
</body>
</html>
