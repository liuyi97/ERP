<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleReturn.aspx.cs" Inherits="WebApplication1.Stock.SaleReturn" %>

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
    <link href="../css/salereturn.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <h2 style="text-align:center;margin-top:10px;margin-bottom:10px;">采购退货</h2>
       <table style="margin-left:25px;margin-top:20px;border:1px solid #b9b4b4;width:750px;height:100px;">
        <tr>
            <td>订单编号：</td>
            <td><asp:TextBox ID="TextBox1" class="CurledLineMiddle" runat="server"></asp:TextBox></td>
            <td>制单日期：</td>
             <td><asp:TextBox ID="TextBox2" class="CurledLineMiddle" Width="90px" ForeColor="Red" runat="server"></asp:TextBox></td>
               <td>调用入库单：</td>
             <td><asp:DropDownList ID="DropDownList1" Width="160px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
         <tr>
            <td>库房/库区：</td>
            <td><asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
            </td>
               <td>出库日期：</td>
             <td id="returntime"></td>
             <td><div id="mydiv" style="display:none;"><asp:TextBox ID="TextBox4" Width="50px" runat="server"></asp:TextBox>
              <asp:TextBox ID="TextBox5" Width="50px" runat="server"></asp:TextBox></div></td>
        </tr>
        <tr>
            <td>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
            <td><asp:TextBox ID="TextBox3"  class="CurledLineMiddle" runat="server"></asp:TextBox></td>
            <td>
                <input type="button" name="btn" id="btn" value="生成采购退货单" />
            </td>
        </tr>
    </table>
    <table style="margin-left:25px;margin-top:20px;border:1px solid #b9b4b4;width:750px;height:100px;">
        <tr>
            <td>商&nbsp;&nbsp;&nbsp;&nbsp;品：</td>
            <td><asp:DropDownList ID="DropDownList4" width="90px" runat="server"></asp:DropDownList></td>
            <td >价钱：</td>
            <td><asp:TextBox ID="TextBox6" class="CurledLineMiddle" Width="70px" runat="server"></asp:TextBox></td>
            <td>数量：</td>
            <td><asp:TextBox ID="TextBox7" class="CurledLineMiddle" Width="70px" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>供应商：</td>
            <td><asp:DropDownList ID="DropDownList5" Width="70px" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>描&nbsp;&nbsp;&nbsp;&nbsp;述：</td>
            <td><asp:TextBox ID="TextBox8" class="CurledLineMiddle" runat="server"></asp:TextBox></td>
            <td>
                <asp:Button ID="Button1" Width="50px" runat="server" Text="保存" OnClick="Button1_Click" /></td>
        </tr>
    </table>
        <div id="box">
        </div>
</div>
    </form>
</body>
    <script type="text/javascript">
        $(function () {
            $("#returntime").datebox({
                required: true,
                editable: true,
                width: 100
            })
            $("#box").datagrid({
                url: "ashx/saleReturnDetail.ashx",
                columns: [[
                    { field: "ck", checkbox: true, title: "选择" },
                    { field: "BuyReturnID", title: '订单编号', align: "center", width: 140 },
                    { field: "ProductsName", title: '商品名', align: "center", width: 80 },
                    { field: "SupplierName", title: '供应商名', align: "center", width: 80 },
                    { field: "Quantity", title: '数量', align: "center", width: 50 },
                    { field: "Price", title: '价格', align: "center", width: 80 },
                    { field: "ReceiptOrderID", title: '入库单号', align: "center", width: 140 },
                    { field: "TotalPrice", title: '总金额', align: "center", width: 80 },
                    { field: "AlreadyPay", title: '预支付金额', align: "center", width: 80 }
                ]],
                pagination: true,
                pageSize: 5,
                height: 200,
                pageList: [5, 10, 15, 20],
                fitColumns: true
            })

            $("#btn").linkbutton({
                width: 100,
                height: 25,
                onClick: function () {
                    var obj = {
                        "BuyReturnID": $("#TextBox1").val(),
                        "BuyReturnDate": $("#TextBox2").val(),
                        "ReceiptOrderID": $("#DropDownList1").val(),
                        "StoreHouseID": $("#DropDownList2").val(),
                        "HouseDetailID": $("#DropDownList3").val(),
                        "userName": "huhai123",
                        "TradeDate": $("#returntime").datebox("getValue"),
                        "TotalPrice": $("#TextBox4").val(),
                        "AlreadyPay": $("#TextBox5").val(),
                        "Description": $("#TextBox3").val(),
                        "State": 1
                    };
                    $.ajax({
                        url: "ashx/salereturn.ashx",
                        data: obj,
                        type: "post",
                        dataType: "text",
                        success: function (data) {
                            if (data == "True") {
                                $.messager.alert("提示", "退货成功！");
                            }
                            else {
                                $.messager.alert("提示", "退货失败！");
                            }
                        }
                    })
                }
            })
        })

    </script>
</html>
