<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleOrder.aspx.cs" Inherits="WebApplication1.Stock.SaleOrder" %>

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
    <link href="../css/saleorder.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
    <p class="size">添加采购订单</p>
        <div id="center">
            <table style="margin-top:10px;float:left;margin-left:10px;">
                <tr>
                               <td>订单编号：</td>
                    <td>
                        <asp:TextBox ID="TextBox1" name="TextBox1" class="CurledLineMiddle" Width="170px" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;</td>
                      <td>制单日期：</td>
                    <td id="begintime">
                      <%--  <asp:TextBox ID="TextBox2" Width="100px" runat="server"></asp:TextBox> --%>
                     </td>
                     <td>业务代表：</td>
                    <td>   <asp:TextBox ID="TextBox3" name="TextBox3" class="CurledLineMiddle" Width="100px" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;</td>
                </tr>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <tr>
                    <td>库房/库区：</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" name="DropDownList1" style="margin-top:5px;float:left;" Width="80px" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> 
                         
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <asp:DropDownList ID="DropDownList2" name="DropDownList2" style="margin-left:85px;margin-top:-20px; float:left;" runat="server" Width="80px" ></asp:DropDownList>
                        
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                        </td>
                    <td>签订日期：</td>
                  <td id="ordertime"> 
             <%--         <asp:TextBox ID="TextBox4" Width="100px" runat="server"></asp:TextBox>--%>
                    </td>
                    <td>交货日期：</td>
                    <td id="endtime"> 
                     <%--   <asp:TextBox ID="TextBox5" Width="100px" runat="server"></asp:TextBox>--%>
                        </td>
                </tr>
                <tr>
                    <td>交货地址：</td>
                    <td>
                        <asp:TextBox ID="TextBox6" name="TextBox6" class="CurledLineMiddle" Width="170px" runat="server"></asp:TextBox></td>
                     <td>合计金额：</td>
                    <td>
                        <asp:TextBox ID="TextBox7" name="TextBox7" class="CurledLineMiddle" Width="60px" runat="server"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td>备注：</td>
                    <td>
                        <asp:TextBox ID="TextBox8" name="TextBox8" class="CurledLineMiddle" Width="170px" runat="server"></asp:TextBox></td>
                     <td></td>
                           <td></td>
                           <td ></td>
                      <td >
   <%--  <asp:Button ID="Button1" runat="server" Width="40px" Height="30px" Text="添加" OnClick="Button1_Click" />--%>
                          <input type="button" name="btn" id="btn" value="添加 " />
                      </td>
                    
                </tr>
            </table>
        </div>
        <div id="end">
            <table style="float:left;margin-left:10px;margin-top:10px;">
                <tr>
                    <td> 商&nbsp;&nbsp;&nbsp;品：</td>
                  <td>
                      <asp:DropDownList ID="DropDownList3" Width="90px" runat="server"></asp:DropDownList></td>
                     <td>价&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;格：</td>
                     <td>
                         <asp:TextBox ID="TextBox9" class="CurledLineMiddle" Width="50px" runat="server"></asp:TextBox>RMB&nbsp;&nbsp;</td>
                     <td>数&nbsp;&nbsp;&nbsp;量：</td>
                     <td>
                         <asp:TextBox ID="TextBox10" class="CurledLineMiddle"  Width="50px" runat="server"></asp:TextBox></td>
                </tr>
                <tr style="margin-top:10px">
                    <td>税率%：</td>
                    <td>
                        <asp:TextBox ID="TextBox11" class="CurledLineMiddle" Width="70px" runat="server"></asp:TextBox></td>
                    <td>折扣率%：</td>
                    <td>
                        <asp:TextBox ID="TextBox12" class="CurledLineMiddle" Width="70px" runat="server"></asp:TextBox></td>
                    <td>供应商：</td>
                    <td>
                        <asp:DropDownList ID="DropDownList4" Width="70px" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>描&nbsp;&nbsp;述：</td>
                    <td>
                        <asp:TextBox ID="TextBox13" width="200px" class="CurledLineMiddle"  runat="server"></asp:TextBox></td>
                    <td></td>
                    <td></td>
                    <td> 
                       <%-- <asp:Button ID="Button2" runat="server" Width="40px" Height="30px" Text="保存" OnClick="Button2_Click" />--%>
                          <input type="button" name="btnagain" id="btnagain" value="保存 " />
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server"  Width="60px"  Height="30px" Text="完成所有" OnClick="Button3_Click" /></td>
                </tr>
            </table>
        </div>
        <table id="datagrid">

        </table>
    </div>
    </form>
    <script type="text/javascript">

        $(function () {
            $("#btn").linkbutton({
                width: 40,
                height: 25,
                text: "添加",
                onClick: function () {
                    var obj = {
                        "BuyOrderID": $("#TextBox1").val(),
                        "BuyOrderDate": $("#begintime").datebox("getValue"),
                        "userName": $("#TextBox3").val(),
                        "StoreHouseID": $("#DropDownList1").val(),
                        "HouseDetailID": $("#DropDownList2").val(),
                        "SignDate": $("#ordertime").datebox("getValue"),
                        "TradeDate": $("#endtime").datebox("getValue"),
                        "TradeAddress": $("#TextBox6").val(),
                        "TotalPrice": $("#TextBox7").val(),
                        "Description": $("#TextBox8").val(),
                        "State": 2,
                    }
                    $.ajax({
                        url: "ashx/addsaleorder.ashx",
                        data: obj,
                        dataType: "text",
                        type: "post",
                        success: function (data) {
                            if (data == "True") {
                                $.messager.alert("提示", "添加成功");
                            }
                            else {
                                $.messager.alert("提示", "添加失败");
                            }
                        }

                    })
                }
            })

            $("#btnagain").linkbutton({
                width: 40,
                height: 25,
                text: "添加",
                onClick: function () {
                    var obj = {
                        "ProductsID": $("#DropDownList3").val(),
                        "Price": $("#TextBox9").val(),
                        "Quantity": $("#TextBox10").val(),
                        "TaxRate": $("#TextBox11").val(),
                        "DiscountRate": $("#TextBox12").val(),
                        "SupplierID": $("#DropDownList4").val(),
                        "Description": $("#TextBox13").val(),
                        "BuyOrderID": $("#TextBox1").val(),
                    }
                    $.ajax({
                        data: obj,
                        dataType: "text",
                        type: "post",
                        url: "ashx/addproductHandler1.ashx",
                        success: function (data) {
                            if (data == "True") {
                                $.messager.alert("提示", "保存成功");
                            }
                            else {
                                $.messager.alert("提示", "保存失败");
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
            $("#ordertime").datebox({
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
                url:"ashx/ProductSelect.ashx",
                columns: [[
                    { 'title':"操作",'field': "ck", checkbox: true,  "align": "center", width: 80 },
                    {' title':"商品编号",'field': "ProductsID",  "align": "center", width: 80 },
                    { 'title':"商品名称",'field': "ProductsName",  "align": "center", width: 80 },
                    { 'title':"供应商",'field': "SupplierName",  "align": "center", width: 80 },
                    { 'title':"数量",'field': "Quantity",  "align": "center", width: 80 },
                    {  'title':"采购额",'field': "TotalPrice", "align": "center", width: 80 },
                    { 'title':"折扣额",'field': "DiscountRate",  "align": "center", width: 80 },
                    { 'title':"税额",'field': "TaxRate",  "align": "center", width: 80 },
                    { 'title':"金额",'field': "Price",  "align": "center", width: 80 }
                ]],
                height:200,
                width:800,
                fitColumns:true,
                pagination:true,
                pageList:[5, 10, 15, 20],
                pageSize:5
            })
        })

    </script>
</body>
</html>
