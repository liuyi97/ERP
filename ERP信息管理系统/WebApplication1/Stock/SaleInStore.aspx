<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleInStore.aspx.cs" Inherits="WebApplication1.Stock.SaleInStore" %>

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
    <link href="../css/saleinstore.css" rel="stylesheet" />
     <style type="text/css">
        .auto-style1 {
            height: 34px;
        }
         #s {
         display:none;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
    <p class="size">采&nbsp;购&nbsp;入&nbsp;库</p>
        <div id="center">
            <table style="float:left;margin-left:10px;margin-top:10px;">
                <tr>
                    <td class="auto-style1">入库&nbsp;单号：</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox1" class="CurledLineMiddle" width="200px" runat="server"></asp:TextBox></td>
                    <td>制单日期：</td>
                    <td id="begintime"></td>
                    <td class="auto-style1">按订单入库：</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="DropDownList1"  Width="165px" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>库房/库区：</td>
                    <td>
                       <asp:DropDownList ID="DropDownList2"   Width="90px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged1" ></asp:DropDownList>
                          <%--    </ContentTemplate>
                    </asp:UpdatePanel>--%>
                        <asp:DropDownList ID="DropDownList3"  Width="90px" runat="server"></asp:DropDownList>
                    </td>
                     <td>入库日期：</td>
                    <td id="endtime"></td>  
                    <td>
                        <div id="s"><asp:TextBox ID="TextBox8" Width="50px" runat="server"></asp:TextBox></div>
                    </td> 
                </tr>
                <tr>
                    <td>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
                    <td>
                        <asp:TextBox ID="TextBox2" Width="200px" class="CurledLineMiddle" runat="server"></asp:TextBox></td>
                    <td></td>
                    <td></td>
                     <td></td>
                    <td>
                        <input type="button" name="btnagain" id="btnagain" value="生成采购入库单" />
             </td>
                </tr>
            </table>
        </div>
        <div id="end">
              <table style="float:left;margin-left:10px;margin-top:10px;">
                <tr>
                    <td> 商&nbsp;&nbsp;&nbsp;品：</td>
                  <td>
                      <asp:DropDownList ID="DropDownList4" Width="90px" runat="server"></asp:DropDownList>

                  </td>
                     <td>价&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;格：</td>
                     <td>
                         <asp:TextBox ID="TextBox3" class="CurledLineMiddle" Width="70px" runat="server"></asp:TextBox>RMB&nbsp;&nbsp;</td>
                     <td>数&nbsp;&nbsp;&nbsp;量：</td>
                     <td>
                         <asp:TextBox ID="TextBox4" class="CurledLineMiddle"  Width="50px" runat="server"></asp:TextBox></td>
                </tr>
                <tr style="margin-top:10px">
                    <td>税率%：</td>
                    <td>
                        <asp:TextBox ID="TextBox5" class="CurledLineMiddle" Width="70px" runat="server"></asp:TextBox></td>
                    <td>折扣率%：</td>
                    <td>
                        <asp:TextBox ID="TextBox6" class="CurledLineMiddle" Width="70px" runat="server"></asp:TextBox></td>
                    <td>供应商：</td>
                    <td>
                        <asp:DropDownList ID="DropDownList5" Width="90px" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>描&nbsp;&nbsp;述：</td>
                    <td>
                        <asp:TextBox ID="TextBox7" width="200px" class="CurledLineMiddle"  runat="server"></asp:TextBox></td>
                    <td></td>
                    <td></td>
                    <td>
                        <input type="button" name="name" id="btnSave" value="保存" />
                        </td>
                    <td>
                       <%-- <input type="button" name="name" id="btnFinall" value="完成所有" />--%>
                        <asp:Button ID="Button1" runat="server" Text="完成所有" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="datagrid">

        </div>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            //生成采购入库
            $("#btnagain").linkbutton({
                width: 100,
                height: 35,
                onClick: function () {
                    var obj = {
                        "ReceiptOrderID": $("#TextBox1").val(),
                        "ReceiptOrderDate": $("#begintime").datebox("getValue"),
                        "BuyOrderID": $("#DropDownList1").val(),
                        "StoreHouseID": $("#DropDownList2").val(),
                        "HouseDetailID": $("#DropDownList3").val(),
                        "TradeDate": $("#endtime").datebox("getValue"),
                        "Description": $("#TextBox2").val(),
                        "UserName": "huhai123",
                        "TotalPrice": $("#TextBox8").val(),
                        "State": 1,
                    }
                    $.ajax({
                        url: "ashx/addsaleReceipt.ashx",
                        data: obj,
                        type: "post",
                        dataType: "text",
                        success: function (data) {
                            if (data == "True") {
                                $.messager.alert("提示", "生成采购入库单成功！");
                            }
                            else {
                                $.messager.alert("提示", "生成采购入库单失败！");
                            }
                        }
                    })
                }
            })
            //保存
            $("#btnSave").linkbutton({
                width: 50,
                height: 30,
                onClick: function () {
                    var obj = {
                        "ProductsID": $("#DropDownList4").val(),
                        "Price": $("#TextBox3").val(),
                        "Quantity": $("#TextBox4").val(),
                        "TaxRate": $("#TextBox5").val(),
                        "DiscountRate": $("#TextBox6").val(),
                        "SupplierID": $("#DropDownList5").val(),
                        "Description": $("#TextBox7").val(),
                        "ReceiptOrderID": $("#TextBox1").val(),
                    }
                    $.ajax({
                        url: "ashx/addsaleProduct.ashx",
                        type: "post",
                        data: obj,
                        dataType: "text",
                        success: function (data) {
                            if (data == "True") {
                                $.messager.alert("提示", "保存成功！");
                            }
                            else {
                                $.messager.alert("提示", "保存失败！");
                            }
                        }
                    })
                }
            })


            $("#begintime").datebox({
                required: true,
                editable: true,
                width: 100
            })
            $("#endtime").datebox({
                required: true,
                editable: true,
                width: 100
            })
            $("#datagrid").datagrid({
                height: 280,
                fitColumns: true,
                pagination: true,
                pageList: [5, 10, 15, 20],
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