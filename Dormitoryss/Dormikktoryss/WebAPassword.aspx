<%@ Page Title="" Language="C#" MasterPageFile="~/Dormuss.Master" AutoEventWireup="true" CodeBehind="WebAPassword.aspx.cs" Inherits="Dormikktoryss.WebAPassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <table style="margin: auto; border-spacing: 5px; border-collapse: separate;">
        <caption style="font-size: x-large">
            修改密码</caption>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style1">
                旧密码：
            </td>
            <td style="text-align: left" class="auto-style2">
                <asp:TextBox ID="txtOldPwd" TextMode="Password" Width="180px" runat="server"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                新密码：
            </td>
            <td style="text-align: left" class="auto-style3">
                <asp:TextBox ID="txtNewPwd" TextMode="Password" Width="180px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                重复新密码：
            </td>
            <td style="text-align: left" class="auto-style3">
                <asp:TextBox ID="txtReNewPwd" TextMode="Password" Width="180px" runat="server"></asp:TextBox><asp:CompareValidator
                    ID="CompareValidator1" runat="server" ErrorMessage="两次输入的密码不一致！" ControlToCompare="txtNewPwd"
                    ControlToValidate="txtReNewPwd">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Button ID="btnSavePwd" Width="80px" Height="30px" runat="server" Text="保存" OnClick="btnSavePwd_Click"/><br />
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="" />
                <asp:ValidationSummary ID="ValidationSummary1" HeaderText="发现以下错误：" ShowMessageBox="true"
                    ShowSummary="false" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
        .auto-style2 {
            height: 22px;
            width: 252px;
        }
        .auto-style3 {
            width: 252px;
        }
    </style>
</asp:Content>


