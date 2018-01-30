<%@ Page Title="" Language="C#" MasterPageFile="~/Dormuss.Master" AutoEventWireup="true" CodeBehind="WebAdministrator.aspx.cs" Inherits="Dormikktoryss.WebAdministrator" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <table style="margin:auto; border-spacing:5px; border-collapse:separate; height: 276px; width: 309px;">
        <caption style="font-size:x-large">管理员信息</caption>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td style="text-align:right">姓&nbsp;&nbsp;名：</td>
            <td style="text-align:left">
                <asp:TextBox ID="txtName" Width="180px" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td style="text-align: right"  valign="top">
                说&nbsp;&nbsp;明：
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtExplains" Width="280px" Height="100px" TextMode="MultiLine"  runat="server" ></asp:TextBox>
            </td>
        </tr>
        
      
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Button ID="btnSaveBasic" Width="80px" Height="30px" runat="server" Text="保存" OnClick="btnSaveBasic_Click" />
                <br /><asp:Label ID="lblMsg" ForeColor="Red" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
