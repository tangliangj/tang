<%@ Page Title="" Language="C#" MasterPageFile="~/Dormuss.Master" AutoEventWireup="true" CodeBehind="WebSushejianjie.aspx.cs" Inherits="Dormikktoryss.WebSushejianjie" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width:100%;padding:5px; height: 221px;" >
        <tr>
            <td  colspan="2" style="text-align:center;">
                <asp:Image ID="imgCover" Width="500px" Height="300px" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center; ">宿舍号：
            
                <asp:Label ID="lbldormitoryID" runat="server"  Text=""></asp:Label>
            </td>
        </tr>
       <tr >
            <td colspan="2" style="text-align:center;">宿舍等级：
            
                <asp:Label ID="lbldormitoryGrade" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr >
            <td  colspan="2" style="text-align:center;">价格：
            
                <asp:Label ID="lbldormitoryPrice" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr >
            <td colspan="2" style="text-align:center;">宿舍人数：
            
                <asp:Label ID="lbldormitoryPerso" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr >
            <td colspan="2" style="text-align:center;">床位：
            
                <asp:Label ID="lblbeds" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr >
            <td colspan="2" style="text-align:center;">宿舍长：
            
                <asp:Label ID="lblDormitoryBoos" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

