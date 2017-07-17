<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_Right.aspx.cs" Inherits="WebApplication1.MagWeb.Main_Right" %>

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
    <style  type="text/css">
        #a, #b, #c, #d {
            float:left;
        }
        .pb {
            float:left;
            margin-left:20px;
            margin-top:30px;
        }
        .ziti {
            color:#ff0000;
        }
        .dd span {
          color:#ff0000;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="middle">
        <div class="pb">
   <div id="a" class="easyui-panel" title="我的问题"     
        style="width:500px;height:250px;padding:10px;background:#fafafa;"   
        data-options="iconCls:'icon-save',">            
        <ul>
               <asp:Repeater ID="Repeater2" runat="server">
                   <ItemTemplate>
                        <li> <span class="ziti"><a href="Main_Right_detail.aspx?id=<%# Eval("NoticeID") %>"><%# Eval("Title") %></a></span  class="dd">(<%# Eval("CreateDate") %>)</li>
                   </ItemTemplate>
               </asp:Repeater>
         
                       </ul> 
</div>  </div>
        <div class="pb">
           <div id="b" class="easyui-panel" title="公告管理"     
        style="width:350px;height:250px;padding:10px;background:#fafafa;"   
        data-options="iconCls:'icon-save',">      
               <ul>
               <asp:Repeater ID="Repeater1" runat="server">
                   <ItemTemplate>
                        <li> <span class="ziti"><a href="Main_Right_detail.aspx?id=<%# Eval("NoticeID") %>"><%# Eval("Title") %></a></span class="dd">(<%# Eval("CreateDate") %>)</li>
                   </ItemTemplate>
               </asp:Repeater>
                       </ul>
</div>  </div>
        <div class="pb">
           <div id="c" class="easyui-panel" title="最近热销"     
        style="width:500px;height:250px;padding:10px;background:#fafafa;"   
        data-options="iconCls:'icon-save'">    
           
         <ul>
               <asp:Repeater ID="Repeater3" runat="server">
                   <ItemTemplate>
                        <li> <span class="ziti"><a href="Main_Right_detail.aspx?id=<%# Eval("NoticeID") %>"><%# Eval("Title") %></a></span  class="dd">(<%# Eval("CreateDate") %>)</li>
                   </ItemTemplate>
               </asp:Repeater>
                       </ul> 
</div>  </div>
            </div>
        <div class="pb">
           <div id="d" class="easyui-panel" title="本周问题"     
        style="padding:10px;background:#fafafa;" >  
    
   
         <ul>
               <asp:Repeater ID="Repeater4" runat="server">
                   <ItemTemplate>
                        <li> <span class="ziti"><a href="Main_Right_detail.aspx?id=<%# Eval("NoticeID") %>"><%# Eval("Title") %></a></span  class="dd">(<%# Eval("CreateDate") %>)</li>
                   </ItemTemplate>
               </asp:Repeater>
                       </ul>  
</div>  </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#d").panel({
                iconCls: 'icon-save',
                width: 350,
                height: 250
            })
        })


    </script>
</body>
</html>
