
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UI.index" %>

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
    <link href="../css/StockStatus.css" rel="stylesheet" />
    <style type="text/css">
        * {
            font-family:"微软雅黑";
            list-style:none;
            padding:0px ;
            margin:0px;
            color:#ffffff;
        }
        p {
            height:60px;
            width:150px;
            background-color:#0094ff;
        }
        .user, .contorl, .stock, .buy {
            /*width:20%;*/
            height:38px;
            background-color:#a82020;
            font-size:23px;
            text-align:center;
            line-height:38px;
        }
        .repa a, .repb a, .repc a, .repd a {
               text-decoration:none;
        }
        .repa,.repb,.repc,.repd {
            height:38px;
             text-align:center;
            line-height:38px;
            background-color:#3e3c3f;
            font-size:20px;
        }
            .repa:hover {
            background-color:#8d887f ;
            }
              .repb:hover {
            background-color:#8d887f;
            }
                .repc:hover {
            background-color:#8d887f;
            }
                  .repd:hover {
            background-color:#8d887f;
            }
        .liling {
            display:none;
        }
        #left {
       width:18%;
       float:left;
 
        }
        #mid {

        }
        #top {
            width:100%;
            margin:0px auto;
            height:100px;
            background-color:#3e3c3f;
        }

        #right {
            width:82%;
            height:900px;
    
            float:right;
            background-color:#d1caca;
        }
        #asdasd {
            margin-left:100px;
        }
        .uuu {
            float:right;
         
              margin-right:140px;
           margin-top:20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="top">
           <ul>
               <li class="uuu">
                   <img src="../images/fff.png""  style="width:40px; height:40px; margin-right:10px; margin-top:10px; " />
                   管理员: <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                   <asp:Button ID="Button1" runat="server" Text="注销" BackColor="Black" BorderColor="Black" BorderStyle="None" ForeColor="White" OnClick="Button1_Click" />
               </li>
                         </ul>
        </div>
        <div id="middle" style="background-color:black">
             <div id="mid">
        <div id="left">
           <ul>
            <li  class="contorl">管理流程</li>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                      <li class="repa">
                               <a href="#" class="lsur" data-url="<%# Eval("WebUrl") %>"><%# Eval("AuthorityName") %></a>
                      </li>
            </ItemTemplate>
        </asp:Repeater>
      </ul>
           <ul>
                 <li  class="stock">库存开单</li>
        <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
                    <li class="repb">
                        <a href="#" class="lsur" data-url="<%# Eval("WebUrl") %>"><%# Eval("AuthorityName") %></a>
               </li>
            </ItemTemplate>
        </asp:Repeater>
        </ul>
           <ul>
                 <li class="buy">采购开单</li>
        <asp:Repeater ID="Repeater3" runat="server">
            <ItemTemplate>
                          <li class="repc">
                             <a href="#" class="lsur" data-url="<%# Eval("WebUrl") %>"><%# Eval("AuthorityName") %></a>
                      </li>

            </ItemTemplate>
        </asp:Repeater>
        </ul>
           <ul>
          <li class="user">用户管理</li>
        <asp:Repeater ID="Repeater4" runat="server">
            <ItemTemplate>
                      <li class="repd">
                           <a href="#" class="lsur" data-url="<%# Eval("WebUrl") %>"><%# Eval("AuthorityName") %></a>
                      </li>
            </ItemTemplate>
        </asp:Repeater>
        </ul>
        </div>
                </div>
                 </div>
         <div id="right">
            
             <iframe src="Main_Right.aspx" id="asdasd"  align="left"  title="test" frameborder="0" width="1150" height="800"  scrolling="no"></iframe>   
        </div>
         
        <script type="text/javascript">
            $(".lsur").click(function () {
                ChangeIframe($(this).attr('data-url'));
            })
            function ChangeIframe(url) {
                $('#asdasd').attr('src', url);
            }
            var indexa = 1;
            var indexb = 1;
            var indexc = 1;
            var indexd = 1;
            $(function () {
               $(".contorl").click(function () {
                   indexa++;
                   if (indexa % 2 == 0) {
                       $(".repa").css({
                           "display": "none"
                       })
                   }
                   else {
                       $(".repa").css({
                           "display": "block"
                       })
                   }
                }                  
                )
               $(".repb").css({
                   "display": "none"
               });
               $(".repd").css({
                   "display": "none"
               });
               $(".stock").click(function () {
                   indexb++;
                   if (indexb % 2 == 0) {
                       $(".repb").css({
                           "display": "none"
                       })
                   }
                   else {
                       $(".repb").css({
                           "display": "block"
                       })
                   }
               }
              )
               $(".buy").click(function () {
                   indexc++;
                   if (indexc % 2 == 0) {
                       $(".repc").css({
                           "display": "none"
                       })
                   }
                   else {
                       $(".repc").css({
                           "display": "block"
                       })
                   }
               }
             )
               $(".user").click(function () {
                   indexd++;
                   if (indexd % 2 == 0) {
                       $(".repd").css({
                           "display": "none"
                       })
                   }
                   else {
                       $(".repd").css({
                           "display": "block" 
                       })
  
                   }
               }
          )
            })
        </script>
    </form>
</body>
</html>
