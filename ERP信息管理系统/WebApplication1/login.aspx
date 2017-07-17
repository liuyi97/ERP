<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="UI.backdengllu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        * {
            padding:0px;
            margin:0px;
            list-style:none;
            font-family:'微软雅黑';
            text-decoration:none;
        }
        #middle {
             height:700px;
             width: 100%;
             background-image: url(images/back.jpg);
             background-repeat:repeat;
        }
        #login {
            width:350px;
            height:400px;
            opacity:0.8;
            background:hsla(0,0%,100%,0.1);  
            margin-left:400px;
            border:1px solid #ffffff;
            border-radius:4%;
            color:#ffffff;
            float:left;
            margin-top:120px;
        }
        .textbox {
            height:30px;
            width:195px;
            border:1px solid #ffffff;
            opacity:0.7;
            /*background:hsla(0,0%,100%,0.1);*/
            color:#000000;
            font-size:15px;
        }
        .dda
        {
            margin-left:60px;
            width:305px;
            height:30px;
            margin-top:80px
        }
     
      .ddb {
            margin-left:60px;
            width:305px;
            height:30px;
            margin-top:30px
        }
        .ddc {
            margin-top:20px;
            width:305px;
            height:30px;

        }
        .ddc li {
               float:left;
               margin-left:50px;
               font-size:12px;
              color:#000000;
        }
            .dda li ,.ddb li {
                float:left;
            }
        /*#Button1 {
            width:228px;
            height:30px;
            background-color:#12a3a8;
            border:none;
            color:#ffffff;
            font-size:15px;
            margin-top:30px;

        }*/
            .btn:hover {
                background-color:#4ee8d0;
            }
        .pass {
            background-image: url(images/b.png);
            width:40px;
            height:30px;
        }
        .cs {
              height:32px;
              width:32px;
              background-color:#ffffff;
               opacity:0.7;          
        }
        .title {
            margin-top:50px;
            margin-left:56px;
            float:left;

        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div id="middle">
          <h2 class ="title"> 
               
             管理系统登录界面 


          </h2>
       <div id="login">         
           <ul class="dda">
            <li class="cs">
                <img src="images/backa.png"  style="width:24px; height:24px; background-color:#ffffff; opacity:0.7; float:left; margin-left:4px; margin-top:4px;" />
            </li>
               <li>
                   <asp:TextBox ID="TextBox1" CssClass="textbox" placeholder=" 请输入账号"  runat="server">
                   </asp:TextBox>
               </li>
                  </ul>
               <ul class="ddb">
                       <li  class="cs">
                <img src="images/backb.png" style="width:24px ; height:24px; background-color:#ffffff; opacity:0.7;  text-align:center;line-height:32px; float:left; margin-left:4px; margin-top:4px;"   />
                       </li>
              <li>
               <asp:TextBox ID="TextBox2"  Class="textbox"  placeholder=" 请输入密码" runat="server" TextMode="Password" ></asp:TextBox></li>   
             <li>
                 <asp:Button ID="Button1"  Style="width:228px;height:30px;  background-color:#12a3a8;  border:none;  color:#ffffff;     font-size:15px;                                                      
                                                                                             margin-top:30px;"  runat="server" Text="登录" OnClick="Button1_Click"/>
             </li>
           </ul>
                          <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#FF0066" Visible="False"></asp:Label>
            
       </div>
       </div>
    </form>
</body>

</html>
