﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Webregistered.aspx.cs" Inherits="Dormikktoryss.Webregistered" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link rel="stylesheet" href="css/pintuer.css" /><link rel="stylesheet" href="css/admin.css" />
    <script src="js/jquery.js"></script>
    <script src="js/pintuer.js"></script> 
</head>
<body>
   
<div class="aspNetHidden">
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="vYyjfkoIBpJqVPuHndix75ucptLT5WuIyJZC9184DsCXvYRxO5GJ81CQv1rp4V4iOuLQc6cWVWtZB/bfLgwRqmOrC59i2QB/Vwkzlnjxokk=" />
</div>

    <div class="bg"></div>
<div class="container">
    <div class="line bouncein">
        <div class="xs6 xm4 xs3-move xm4-move">
            <div style="height:150px;"></div>
            <div class="media media-y margin-big-bottom">           
            </div>         
            <form id="form1" runat="server" >
            <div class="panel loginbox">
                <div class="text-center margin-big padding-big-top"><h1>注册信息</h1></div>
                <div class="panel-body" style="padding:30px; padding-bottom:10px; padding-top:10px;">
                    <div class="form-group">
                        <div class="field field-icon-right">
                            <asp:TextBox CssClass="input text-big" ID="txtName" runat="server" placeholder="姓名" type="text" data-validate="required:请填写姓名" ></asp:TextBox>
                            
                            <span class="icon icon-user margin-small"></span>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="field field-icon-right">
                            <asp:TextBox CssClass="input text-big" ID="txtID" runat="server" placeholder="账号" type="text" data-validate="required:请填写账号" ></asp:TextBox>
                            
                            <span class="icon icon-user margin-small"></span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="field field-icon-right">
                             <asp:TextBox CssClass="input text-big" ID="txtpwd1" runat="server" placeholder="注册密码" type="text" data-validate="required:请填写密码" TextMode="Password" ></asp:TextBox>
                            <span class="icon icon-key margin-small"></span>
                        </div>
                    </div>
                   
                    <div class="form-group">
                        <div class="field field-icon-right">
                             <asp:TextBox CssClass="input text-big" ID="txtpwd2" runat="server" placeholder="重复密码" type="text" data-validate="required:请再次填写密码" TextMode="Password" ></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpwd1" ControlToValidate="txtpwd2" ErrorMessage="两次密码必须一致！">*</asp:CompareValidator>
                            <span class="icon icon-key margin-small"></span>
                        </div>
                    </div>
                </div>
                
                 <div  style="text-align:right;"   height: 230px; width :330px; border:1px solid #000;>
                <asp:HyperLink  ID="hyLogin"  Font-Size="20px" NavigateUrl="~/WebLogin.aspx"   runat="server">登录|</asp:HyperLink></div>
                <div style="padding:30px;"><asp:Button  CssClass="button button-block bg-main text-big button-big" Height="50px" ID="Button1" runat="server"  Text="注册" OnClick="Button1_Click"  /></div>
                
            </div>
                 <div  style="text-align:center;"   height: 230px; width :330px; border:1px solid #000; text-align:center;>
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="" />
                <asp:ValidationSummary ID="ValidationSummary1" HeaderText="发现以下错误：" ShowMessageBox="true" ShowSummary="false" runat="server" Height="61px" />
                     </div>
                </form>
        </div>

    </div>

</div>
        
</body>
</html>
