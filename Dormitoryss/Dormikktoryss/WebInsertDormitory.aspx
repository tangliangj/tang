<%@ Page Title="" Language="C#" MasterPageFile="~/Dormuss.Master" AutoEventWireup="true" CodeBehind="WebInsertDormitory.aspx.cs" Inherits="Dormikktoryss.WebInsertDormitory" %>

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
                新 增 宿 舍 信 息
                </span></strong></th>
		</tr>

		

	<!--	<tr>
			<td class="forumRow"  style="font-size:15px" >&nbsp;&nbsp;<b>宿舍号：</b></td>
			<td colspan="2">
                <asp:TextBox ID="txtdormitoryID" Width="180px"  runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" 
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdormitoryID" 
                    ErrorMessage="请输入宿舍号" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;</td>

		</tr>	-->

        <tr>
			<td class="forumRow"  style="font-size:15px; height: 21px;" ><b>&nbsp;&nbsp;宿舍长：</b></td>
			<td colspan="2" class="auto-style1">
                <asp:TextBox ID="txtBossName" runat="server" Width="120px"></asp:TextBox>
                （十个汉字以内）<asp:RequiredFieldValidator ForeColor="Red" 
                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBossName" 
                    ErrorMessage="请输入宿舍长姓名" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
		</tr>
       
        
        <tr>
			<td class="forumRow"  style="font-size:15px" ><b>&nbsp;&nbsp;图片名：</b></td>
			<td colspan="2">
                <asp:TextBox ID="txtISBN" runat="server" Width="120px"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" 
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtISBN" 
                    ErrorMessage="请输入图片名称" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
		</tr>

        <tr>
			<td class="forumRow"  style="font-size:15px"><b>&nbsp;宿舍名称：</b></td>
			<td colspan="2">
                
                 <asp:TextBox ID="txtdormitoryGrade" runat="server" Width="120px"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" 
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdormitoryGrade" 
                    ErrorMessage="请输入宿舍姓名" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>

                    </td>
		</tr>	

        <tr>
			<td class="forumRow"  style="font-size:15px"><b>&nbsp;宿舍人数：</b></td>
			<td colspan="2">
                <asp:TextBox ID="txtPerso" runat="server" Width="120px" MaxLength="11"></asp:TextBox>
                （11个字符以内）<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red"  runat="server" 
                    ControlToValidate="txtPerso" Display="Dynamic" ErrorMessage="只能使用数字" 
                    ValidationExpression="(\d)*"></asp:RegularExpressionValidator>
                    </td>
		</tr>
        
        <tr>
			<td class="forumRow"  style="font-size:15px"><b>&nbsp;&nbsp;价格：</b></td>
			<td colspan="2">
                <asp:TextBox ID="txtPrice" runat="server" Width="120px" MaxLength="11"></asp:TextBox>
                （11个字符以内）<asp:RegularExpressionValidator ID="RegularExpressionValidator4" ForeColor="Red"  runat="server" 
                    ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="只能使用数字" 
                    ValidationExpression="(\d)*"></asp:RegularExpressionValidator>
                    </td>
		</tr>	

         

         <tr>
			<td class="forumRow"  style="font-size:15px"><b>&nbsp;&nbsp;床位：</b></td>
			<td colspan="2">
                <asp:TextBox ID="txtbeds" runat="server" Width="120px" MaxLength="11"></asp:TextBox>
                （11个字符以内）<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red"  runat="server" 
                    ControlToValidate="txtbeds" Display="Dynamic" ErrorMessage="只能使用数字" 
                    ValidationExpression="(\d)*"></asp:RegularExpressionValidator>
                    </td>
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

