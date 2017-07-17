<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsWeb.aspx.cs" Inherits="WebApplication1.Sys.ProductsWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Script/jquery-1.8.3.min.js"></script>
    <script src="../UI/jquery.easyui.min.js"></script>
    <link href="../UI/themes/icon.css" rel="stylesheet" />
    <link href="../UI/themes/default/easyui.css" rel="stylesheet" />
    <script src="../UI/locale/easyui-lang-zh_CN.js"></script>
    <style type="text/css">
        #you {
            margin: 0px;
            padding: 0px;
            width: 850px;
        }

        #ku1 table tr td {
            height: 60px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="you">
            <div><a href="#">乐易拍信息系统</a>><a href="#">系统设置</a>>商品资料</div>
            <h2>商品基本维护</h2>
            <p>
                搜索条件：<asp:CheckBox ID="CheckBox1" runat="server" Text="启用商品类型" />
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                <asp:CheckBox ID="CheckBox2" runat="server" Text="启用商品品牌" />
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
                关键字：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <input type="button" name="name" value="搜索" id="Button1" />
                <input type="button" name="name" value="添加商品" id="Button2" />
            </p>
            <div>
                <table id="tab"></table>
            </div>
        </div>
        <div id="you1">
            <p id="zheid">编辑商品信息编号：<label id="bianhao"></label></p>
            <table>
                <tr>
                    <td  colspan="4">基本信息</td>
                </tr>
                <tr>
                    <td>商品名称：</td>
                    <td><input type="text" id="m1" /></td>
                    <td>商品类型：</td>
                    <td><input id="m2" /></td>
                </tr>
                <tr>
                    <td>商品品牌：</td>
                    <td><input id="m3" /></td>
                    <td>颜色：</td>
                    <td><input type="text" id="m4" /></td>
                </tr>
                <tr>
                    <td>单位：</td>
                    <td><input type="text" id="m5" /></td>
                    <td>成本：</td>
                    <td><input type="text" id="m6" /></td>
                </tr>
                <tr>
                    <td>重量：</td>
                    <td><input type="text" id="m7" /></td>
                    <td>售价：</td>
                    <td><input type="text" id="m8" /></td>
                </tr>
                <tr>
                    <td>规格：</td>
                    <td><input type="text" id="m9" /></td>
                    <td>材质：</td>
                    <td><input type="text" id="m10" /></td>
                </tr>
                <tr>
                    <td>库存上限：</td>
                    <td><input type="text" id="m11" /></td>
                    <td>库存下线：</td>
                    <td><input type="text" id="m12" /></td>
                </tr>
                <tr>
                    <td colspan="4">高级信息</td>
                </tr>
                <tr>
                    <td>初始入库时间：</td>
                    <td><input type="text" id="m13" class="easyui-datebox"/></td>
                    <td>最后入库时间：</td>
                    <td><input type="text" id="m14" class="easyui-datebox"/></td>
                </tr>
                <tr>
                    <td>上架日期：</td>
                    <td><input type="text" id="m15" class="easyui-datebox"/></td>
                    <td>最近缺货时间：</td>
                    <td><input type="text" id="m16" class="easyui-datebox"/></td>
                </tr>
                <tr>
                    <td>下架日期：</td>
                    <td><input type="text" id="m17" class="easyui-datebox"/></td>
                    <td>其他描述：</td>
                    <td><input type="text" id="m18" /></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <input type="button"  value="提交" id="m19" /></td>
                </tr>
            </table>
        </div>
        <div id="you2">
            <div><a href="#">乐易拍信息系统</a>><a href="#">系统设置</a>><a href="ProductsWeb.aspx">商品资料</a>>商品调价</div>
            <br /><br /><br />
            <div>商品编号：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;不同的二级用户类型看到的商品价格</div>
            <table id="tab2"></table>
        </div>
        <script type="text/javascript">
            var mm = 3;
            var editRow=undefined;
            function Productstiaojia(id) {
                $("#you").css("display", "none");
                $("#you2").css("display", "block");
                $("#Label1").text(id);
                $("#tab2").datagrid({
                    url: "handler/Productserji.ashx?id="+id,
                    columns: [[
                    { "title": "一级类型", "field": "TypeName", width: 20, "align": "center" },
                    { "title": "二级类型", "field": "SubClassName", width: 40, "align": "center" },
                    {
                        "title": "显示标价", "field": "Price", width: 40, "align": "center", editor: {
                            type: 'validatebox',
                            options: {required:true}
                        }
                    },
                    {
                        "title": "操作", "field": "num", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<a href='javascript:Productsshanchu(" + row.ProductsID + ")'>删除</a>"
                        }
                    }
                    ]],
                    width: 800,
                    singleSelect:true,
                    pagination: true,
                    fitColumns: true,
                    pageList: [10, 20, 30],
                    pageSize: 10,
                    onClickRow: function (index,row) {
                        if (editRow != undefined) {
                            //alert("pp");
                            $("#tab2").datagrid('endEdit', editRow);
                        }
                        else if (editRow == undefined) {
                            $("#tab2").datagrid('beginEdit', index);
                            //console.info(row);
                            editRow = index;
                            //alert(editRow);
                        }
                    },
                    onAfterEdit: function (index, row, changes) {
                        //console.info(row);
                        $.ajax({
                            data: {
                                "typeid": row.TypeID,
                                "Price": row.Price
                            },
                            type: "post",
                            dataType: "json",
                            url: "handler/ProductstiaojiaUpdate.ashx",
                            success: function (data) {
                                if (data == "True") {
                                    $.messager.alert("提示", "修改成功！");
                                } else {
                                    $.messager.alert("提示", "修改失败！");
                                }
                                $("#tab2").datagrid("reload");
                            }
                        })
                        editRow = undefined;
                    }
                })
            }
            function Productsbianji(id) {
                mm = 2;
                $("#zheid").css("display", "block");
                $("#you").css("display", "none");
                $("#you1").css("display", "block");
                $("#bianhao").text(id);
                $.ajax({
                    data: { "id": id },
                    type: "post",
                    dataType: "json",
                    url: "handler/ProductsID.ashx",
                    success: function (data) {
                        $("#m1").val(data[0]["ProductsName"]);
                        $("#m2").combobox("setValue", data[0]["TypeID"]);
                        $("#m3").combobox("setValue", data[0]["BrandID"]);
                        $("#m4").val(data[0]["Color"]);
                        $("#m5").val(data[0]["ProductsUints"]);
                        $("#m6").val(data[0]["Cost"]);
                        $("#m7").val(data[0]["Weight"]);
                        $("#m8").val(data[0]["Price"]);
                        $("#m9").val(data[0]["Spec"]);
                        $("#m10").val(data[0]["Material"]);
                        $("#m11").val(data[0]["UpperLimit"]);
                        $("#m12").val(data[0]["LowerLimit"]);
                        $("#m13").val(data[0]["BeginEnterDate"]);
                        $("#m14").val(data[0]["FinalEnterDate"]);
                        $("#m15").val(data[0]["LoadingDate"]);
                        $("#m16").val(data[0]["LatelyOFSDate"]);
                        $("#m17").val(data[0]["UnshelveDate"]);
                        $("#m18").val(data[0]["Description"]);
                    }
                })
            }
            function Productsshanchu(id) {
                $.ajax({
                    data: { "id": id },
                    type: "post",
                    dataType: "Text",
                    url: "handler/ProductsDelete.ashx",
                    success: function (data) {
                        if (data == "True") {
                            $.messager.alert("提示", "删除成功！");
                        } else {
                            $.messager.alert("提示", "删除失败！");
                        }
                        $("#tab").datagrid("reload");
                    }
                })
            }
            $(function () {
                $("#m19").click(function () {
                    var obj = {
                        ProductsName: $("#m1").val(),
                        TypeID: $("#m2").combobox("getValue"),
                        BrandID: $("#m3").combobox("getValue"),
                        Color: $("#m4").val(),
                        ProductsUints: $("#m5").val(),
                        Cost: $("#m6").val(),
                        Weight: $("#m7").val(),
                        Price: $("#m8").val(),
                        Spec: $("#m9").val(),
                        Material: $("#m10").val(),
                        UpperLimit: $("#m11").val(),
                        LowerLimit: $("#m12").val(),
                        BeginEnterDate: $("#m13").val(),
                        FinalEnterDate: $("#m14").val(),
                        LoadingDate: $("#m15").val(),
                        LatelyOFSDate: $("#m16").val(),
                        UnshelveDate: $("#m17").val(),
                        Description: $("#m18").val()
                    }
                    if (mm == 3) {
                        if ($("#m1").val() != "" && $("#m2").combobox("getValue") != "" && $("#m3").combobox("getValue") != "" && $("#m6").val() != "") {
                            $.ajax({
                                data: obj,
                                type: "post",
                                dataType: "Text",
                                url: "handler/ProductsInsert.ashx",
                                success: function (data) {
                                    if (data == "True") {
                                        $.messager.alert("提示", "添加成功！");
                                        $("#you").css("display", "block");
                                        $("#you1").css("display", "none");
                                    } else {
                                        $.messager.alert("提示", "添加失败！");
                                    }
                                    $("#tab").datagrid("reload");
                                }
                            })
                        } else {
                            $.messager.alert("商品名称、品牌、类型和成本不能为空！");
                        }
                    } else if (mm == 2) {
                        if ($("#m1").val() != "" && $("#m2").combobox("getValue") != "" && $("#m3").combobox("getValue") != "" && $("#m6").val() != "") {
                            $.ajax({
                                data: obj,
                                type: "post",
                                dataType: "Text",
                                url: "handler/ProductsUpdate.ashx?id=" + $("#bianhao").text(),
                                success: function (data) {
                                    if (data == "True") {
                                        $.messager.alert("提示", "修改成功！");
                                        $("#you").css("display", "block");
                                        $("#you1").css("display", "none");
                                        $("#zheid").css("display", "none");
                                    } else {
                                        $.messager.alert("提示", "修改失败！");
                                    }
                                    $("#tab").datagrid("reload");
                                }
                            })
                        } else {
                            $.messager.alert("商品名称、品牌、类型和成本不能为空！");
                        }
                    }
                })
                $("#Button2").click(function () {
                    mm = 3;
                    $("#you").css("display", "none");
                    $("#you1").css("display", "block");
                    $("#zheid").css("display", "none");
                    $("#m1").val("");
                    $("#m2").val("");
                    $("#m3").val("");
                    $("#m4").val("");
                    $("#m5").val("");
                    $("#m6").val("");
                    $("#m7").val("");
                    $("#m8").val("");
                    $("#m9").val("");
                    $("#m10").val("");
                    $("#m11").val("");
                    $("#m12").val("");
                    $("#m13").val("");
                    $("#m14").val("");
                    $("#m15").val("");
                    $("#m16").val("");
                    $("#m17").val("");
                    $("#m18").val("");
                })
                $("#you1").css("display", "none");
                $("#you2").css("display", "none");
                $("#zheid").css("display", "none");
                $("#m2").combobox({
                    url: 'handler/ProductsTypeDrop.ashx',
                    valueField: 'TypeID',
                    textField: 'TypeName',
                    width: 100,
                    editable: false,
                    onLoadSuccess: function () {
                        $("#m2").combobox("select", 2)
                    }
                })
                $("#m3").combobox({
                    url: 'handler/ProductsBrandDrop.ashx',
                    valueField: 'BrandID',
                    textField: 'BrandName',
                    width: 100,
                    editable: false,
                    onLoadSuccess: function () {
                        $("#m3").combobox("select", 2)
                    }
                })

                $("#Button1").click(function () {
                    var xuanze = 0;
                    //var c1 = 0;
                    //var c2 = 0;
                    //var t = "";
                    var obj;
                    if ($("#CheckBox1").prop("checked") == true && $("#CheckBox2").prop("checked") == true && $("#TextBox1").val() != "") {
                        //alert($("#DropDownList1").val());
                        //alert($("#DropDownList2").val());
                        //alert($("#TextBox1").val());
                        //obj = {
                        //xuanze : 1,
                        //c1 : $("#DropDownList1").val(),
                        //c2 : $("#DropDownList2").val(),
                        //t : $("#TextBox1").val(),
                        //}
                        obj = "xuanze=1&c1=" + $("#DropDownList2").val() + "&c2=" + $("#DropDownList1").val() + "&t=" + $("#TextBox1").val();
                        //alert(obj);

                    } else if ($("#CheckBox1").prop("checked") == true && $("#CheckBox2").prop("checked") == true && $("#TextBox1").val() == "") {
                        //obj = {
                        //    xuanze: 2,
                        //    c1: $("#DropDownList1").val(),
                        //    c2: $("#DropDownList2").val(),
                        //}
                        obj = "xuanze=2&c1=" + $("#DropDownList2").val() + "&c2=" + $("#DropDownList1").val();
                    } else if ($("#CheckBox1").prop("checked") == true && $("#CheckBox2").prop("checked") == false && $("#TextBox1").val() != "") {
                        //obj = {
                        //    xuanze: 3,
                        //    c1: $("#DropDownList1").val(),
                        //    t: $("#TextBox1").val(),
                        //}
                        obj = "xuanze=3&c1=" + $("#DropDownList1").val() + "&t=" + $("#TextBox1").val();
                    } else if ($("#CheckBox1").prop("checked") == true && $("#CheckBox2").prop("checked") == false && $("#TextBox1").val() == "") {
                        //obj = {
                        //    xuanze: 4,
                        //    c1: $("#DropDownList1").val(),
                        //}
                        obj = "xuanze=4&c1=" + $("#DropDownList1").val();
                    } else if ($("#CheckBox1").prop("checked") == false && $("#CheckBox2").prop("checked") == true && $("#TextBox1").val() != "") {
                        //obj = {
                        //    xuanze: 5,
                        //    c2: $("#DropDownList2").val(),
                        //    t: $("#TextBox1").val(),
                        //}
                        obj = "xuanze=5&c2=" + $("#DropDownList2").val() + "&t=" + $("#TextBox1").val();
                    } else if ($("#CheckBox1").prop("checked") == false && $("#CheckBox2").prop("checked") == true && $("#TextBox1").val() == "") {
                        //obj = {
                        //    xuanze: 6,
                        //    c2: $("#DropDownList2").val(),
                        //}
                        obj = "xuanze=6&c2=" + $("#DropDownList2").val();
                    } else if ($("#CheckBox1").prop("checked") == false && $("#CheckBox2").prop("checked") == false && $("#TextBox1").val() != "") {
                        //obj = {
                        //    xuanze: 7,
                        //    t: $("#TextBox1").val(),
                        //}
                        obj = "xuanze=7&t=" + $("#TextBox1").val();
                    } else if ($("#CheckBox1").prop("checked") == false && $("#CheckBox2").prop("checked") == false && $("#TextBox1").val() == "") {
                        obj = "xuanze=7";
                    }
                    //$.ajax({
                    //    data: obj,
                    //    dataType: "json",
                    //    type: "post",
                    //    url: "handler/Productschaxun.ashx",
                    //    success: function (da) {
                    //        $("#tab").datagrid({
                    //            data: da,
                    //        })
                    //    }
                    //})
                    $("#tab").datagrid({
                        url: "handler/Productschaxun.ashx?"+obj,
                        columns: [[
                        { "title": "查看", "field": "pp", width: 20, "align": "center" },
                    { "title": "商品编号", "field": "ProductsID", width: 20, "align": "center" },
                    { "title": "商品名称", "field": "ProductsName", width: 40, "align": "center" },
                    { "title": "入库时间", "field": "BeginEnterDate", width: 40, "align": "center" },
                    { "title": "库存上限", "field": "UpperLimit", width: 20, "align": "center" },
                    { "title": "库存下限", "field": "LowerLimit", width: 20, "align": "center" },
                    { "title": "成本", "field": "Cost", width: 20, "align": "center" },
                     {
                         "title": "调价", "field": "nu1", width: 20, "align": "center", formatter: function (value, row, index) {
                             return "<a href='javascript:Productstiaojia(" + row.ProductsID + ")'>调价</a>"
                         }
                     }, {
                         "title": "上传图片", "field": "nu2", width: 20, "align": "center", formatter: function (value, row, index) {
                             return "<a href='ProductsFiledWeb.aspx?id=" + row.ProductsID + "'>上传图片</a>"
                         }
                     },
                    {
                        "title": "编辑", "field": "nu3", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<a href='javascript:Productsbianji(" + row.ProductsID + ")'>编辑</a>"
                        }
                    },
                    {
                        "title": "删除", "field": "num", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<a href='javascript:Productsshanchu(" + row.ProductsID + ")'>删除</a>"
                        }
                    }
                        ]],
                        width: 800,
                        pagination: true,
                        fitColumns: true,
                        pageList: [10, 20, 30],
                        pageSize: 10
                    })
                })
                $("#tab").datagrid({
                    url: "handler/ProductsALL.ashx",
                    columns: [[
                        {
                            "title": "查看", "field": "pp", width: 20, "align": "center", formatter: function (value, row, index) {
                                return "<a href='ProductsList.aspx?id=" + row.ProductsID + "'>查看</a>"
                            }
                        },
                    { "title": "商品编号", "field": "ProductsID", width: 20, "align": "center" },
                    { "title": "商品名称", "field": "ProductsName", width: 40, "align": "center" },
                    { "title": "入库时间", "field": "BeginEnterDate", width: 40, "align": "center" },
                    { "title": "库存上限", "field": "UpperLimit", width: 20, "align": "center" },
                    { "title": "库存下限", "field": "LowerLimit", width: 20, "align": "center" },
                    { "title": "成本", "field": "Cost", width: 20, "align": "center" },
                     {
                         "title": "调价", "field": "nu1", width: 20, "align": "center", formatter: function (value, row, index) {
                             return "<a href='javascript:Productstiaojia(" + row.ProductsID + ")'>调价</a>"
                         }
                     }, {
                         "title": "上传图片", "field": "nu2", width: 20, "align": "center", formatter: function (value, row, index) {
                             return "<a href='ProductsFiledWeb.aspx?id=" + row.ProductsID + "'>上传图片</a>"
                         }
                     },
                    {
                        "title": "编辑", "field": "nu3", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<a href='javascript:Productsbianji(" + row.ProductsID + ")'>编辑</a>"
                        }
                    },
                    {
                        "title": "删除", "field": "num", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<a href='javascript:Productsshanchu(" + row.ProductsID + ")'>删除</a>"
                        }
                    }
                    ]],
                    width: 800,
                    pagination: true,
                    fitColumns: true,
                    pageList: [10, 20, 30],
                    pageSize: 10
                })
                
            })
        </script>
    </form>
</body>
</html>
