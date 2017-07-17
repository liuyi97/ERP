<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleInStoreDetail.aspx.cs" Inherits="WebApplication1.Stock.SaleInStoreDetail" %>

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
    <link href="../css/saleinstoredetail.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
    <p class="size">采购入库明细</p>
        <div id="center">
            <table  style="float:left;margin-left:10px;margin-top:10px;">
                <tr>
                    <td>入库单号：</td>
                     <td>
                         <asp:TextBox ID="TextBox1"  class="CurledLineMiddle" width="200px"  runat="server"></asp:TextBox></td>
                     <td>制单日期：</td>
                     <td id="begintime">
                         <asp:TextBox ID="TextBox8" class="CurledLineMiddle" width="100px" runat="server"></asp:TextBox></td>
                     <td>制单人：</td>
                     <td>
                         <asp:TextBox ID="TextBox2" class="CurledLineMiddle" width="70px" runat="server"></asp:TextBox></td>
                </tr>
                    <tr>
                    <td>库房/库区：</td>
                     <td><%-- <asp:TextBox ID="TextBox3" class="CurledLineMiddle" width="70px" runat="server"></asp:TextBox>
                          <asp:TextBox ID="TextBox4" class="CurledLineMiddle" width="70px" runat="server"></asp:TextBox>--%>
                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:DropDownList ID="DropDownList1" style="margin-top:5px;float:left;" Width="90px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                             <ContentTemplate>
                                      <asp:DropDownList ID="DropDownList2" style="margin-top:5px;float:left;" width="90px" runat="server"></asp:DropDownList>
                             </ContentTemplate>
                             <Triggers>
                                 <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                             </Triggers>
                         </asp:UpdatePanel>
                     </td>
                     <td>合计金额：</td>
                     <td> <asp:TextBox ID="TextBox5" class="CurledLineMiddle" width="70px" runat="server"></asp:TextBox></td>
                     <td>状态：</td>
                     <td> <asp:TextBox ID="TextBox6" class="CurledLineMiddle" ForeColor="Red" width="70px" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>入库日期：</td>
                    <td id="endtime">
                        <asp:TextBox ID="TextBox9" class="CurledLineMiddle" width="100px" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>备注：</td>
                    <td> <asp:TextBox ID="TextBox7" class="CurledLineMiddle" width="200px" runat="server"></asp:TextBox></td>
                </tr>
            </table>

        </div>
        <div id="datagrid"></div>

    </div>
    </form>
    <script type="text/javascript">
        $(function () {

            $("#datagrid").datagrid({
                height: 200,
                fitColumns: true,
                pagination: true,
                pageList: [5, 10, 15],
                pageSize: 5,
                url: "ashx/addsaleNum.ashx",
                columns: [[
                     { field: "ck", checkbox: true, title: "操作", align: "center", width: 80 },
                    { field: "ProductsID", title: "商品编号", align: "center", width: 80 },
                    { field: "ProductsName", title: "商品名称", align: "center", width: 80 },
                    { field: "SupplierName", title: "供应商", align: "center", width: 80 },
                    { field: "Quantity", title: "数量", align: "center", width: 80 },
                    { field: "TotalPrice", title: "采购额", align: "center", width: 80 },
                    { field: "TaxRate", title: "折扣额", align: "center", width: 80 },
                    { field: "DiscountRate", title: "税额", align: "center", width: 80 },
                    { field: "Price", title: "金额", align: "center", width: 80 }
                ]]
            })
        })

    </script>
</body>
</html>
