<%@ Page Title="" Language="C#" MasterPageFile="~/Dormuss.Master" AutoEventWireup="true" CodeBehind="WebInsertManagement.aspx.cs" Inherits="Dormikktoryss.WebInsertManagement" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>无标题页</title>
   	<link href="css/Forum_admin.css" rel="stylesheet" type="text/css"/>
   	
    <style type="text/css">
        #imgPhoto
        {
            height: 150px;
            width: 119px;
        }
        .auto-style1 {
            height: 21px;
        }
    </style>
</head>
<body>
    <div>
        &nbsp;
        <br />

	<table border="0"  class="tableBorder1">
		<tr> 
			<th  colspan="3">
            <strong><span style="font-size: 22px; color:black">
                新 增 日 常 管 理 信 息
                </span></strong></th>
		</tr>

		<tr>
			<td class="forumRow"  style="font-size:15px; height: 21px;" ><b>&nbsp;&nbsp;检查时间：</b></td>
			<td colspan="2" class="auto-style1">
                <asp:TextBox ID="txtManagementTime" runat="server" Width="120px"  MaxLength="20"></asp:TextBox>
                (yyyy-MM-dd 或 yyyy/MM/dd)<asp:RequiredFieldValidator ForeColor="Red" 
                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtManagementTime" 
                    ErrorMessage="请输入检查时间" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ForeColor="Red"  runat="server" 
                    ControlToValidate="txtManagementTime" Display="Dynamic" ErrorMessage="日期格式不正确" 
                    
                    ValidationExpression="^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))(\s(((0?[1-9])|(1[0-2]))\:([0-5][0-9])((\s)|(\:([0-5][0-9])\s))([AM|PM|am|pm]{2,2})))?$"></asp:RegularExpressionValidator>
                    </td>
		</tr>

		<tr>
			<td class="forumRow"  style="font-size:15px" >&nbsp;&nbsp;<b>宿舍号：</b></td>
			<td colspan="2">
                <asp:DropDownList ID="drtxtDorID" runat="server"></asp:DropDownList>
                
                &nbsp;&nbsp;</td>
		</tr>	
        

		<tr>
			<td class="forumRow"  style="font-size:15px" ><b>&nbsp;&nbsp;检查人员：</b></td>
			<td colspan="2">
                
                <asp:Label ID="lblAdminID" runat="server" Text="lbladmin"></asp:Label></td>
		</tr>

        <tr>
			<td class="forumRow"  style="font-size:15px" ><b>&nbsp;&nbsp;卫生情况：</b></td>
			<td colspan="2">
                
                <asp:DropDownList ID="droHygiene" runat="server"></asp:DropDownList></td>
		</tr>

	
		<tr>
			<td class="forumRow"  style="font-size:15px" valign="top" ><b>&nbsp;&nbsp;说明：</b></td>
			<td colspan="2">
                <asp:TextBox ID="txtExplains" runat="server" Width="524px" 
                    Height="129px" TextMode="MultiLine" CssClass="none"></asp:TextBox>
                    </td>
		</tr>
	</table>
        </div>
	        <br />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	<asp:Button ID="btnAdd"  style="font-size:15px" Width="80px" Height="30px" runat="server" Text="确定增加" onclick="btnAdd_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="bntchongzhi" style="font-size:15px"  Width="80px" Height="30px" runat="server" Text="重置" OnClick="bntchongzhi_Click" />
    <br />
</body>
</html>
</asp:Content>

