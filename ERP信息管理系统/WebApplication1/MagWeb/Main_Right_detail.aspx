<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_Right_detail.aspx.cs" Inherits="WebApplication1.MagWeb.Main_Right_detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<style type="text/css">
        * {
            font-family:"微软雅黑";
        }
        .top_ber {
           border-top:1px solid #808080;
         }
            .top_down {
           border-top:1px solid #808080;
        }
        .txt {
           width:800px;
            height:200px;
            border:1px solid #808080;
           
            text-align:center;
        }
        #ziti_txt {
            border-bottom:1px solid #808080;
        }
        .abc {
            color:#ff0000;
            font-size:15px;
        }
        .dddd {
            text-align:center;
        }
        .ziti_txt {
           text-align:center;
        }
        .abc {
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <h2 class="dddd">标题：<%# Eval("Title") %></h2>
             <p class="top_ber"></p>
              发布时间：<span class="abc"><%# Eval("Title") %></span>发布用户：<span class="abc"><%# Eval("UserName") %></span>
              <p class="top_down"></p>
                <div id="txt">
                    <span id="ziti_txt">
                        <span class="abc"><%# Eval("Info") %></span>
                    </span>

                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    </form>
</body>
</html>
