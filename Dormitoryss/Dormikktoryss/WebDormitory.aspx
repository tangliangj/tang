<%@ Page Title="" Language="C#" MasterPageFile="~/Dormuss.Master" AutoEventWireup="true" CodeBehind="WebDormitory.aspx.cs" Inherits="Dormikktoryss.WebDormitory" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:Label ID="lblRead" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>&nbsp;
     <div style="text-align:right;">
      <a href="css/唐良杰.zip">下载</a>
  </div>
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="bntFileUpload" runat="server" Text="上传" OnClick="bntFileUpload_Click" />
    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblage" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:RadioButton ID="radRect" runat="server" GroupName="List" Text="列表显示" Checked="true" AutoPostBack="true" OnCheckedChanged="radRect_CheckedChanged" />
    <asp:RadioButton ID="radList" runat="server" GroupName="List" Text="方块显示" AutoPostBack="true" OnCheckedChanged="radList_CheckedChanged" />
    <br />
   
    <asp:DataList ID="dgdShowData" runat="server" RepeatColumns="5" >
        <ItemTemplate>
            <table style="width: 147px; text-align:center; background-color: #C8E2B1;" onmouseover="this.style.backgroundColor='#d7d7d7';" onmouseout="this.style.backgroundColor='#C8E2B1';">
                <tr>
                    <td style="text-align: center; vertical-align: top;">
                        <asp:Image ID="imgCover" Width="100" Height="120" ImageUrl='<%# "~/Image/"+Eval("ISBN") %>' runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href='<%# "Websushejianjie.aspx?ID="+Eval("dormitoryID") %>'>
                            <asp:Label ID="lbldormitoryGrade" runat="server" Text='<%# Eval ("dormitoryGrade").ToString().Length>9?Eval("dormitoryGrade").ToString().Substring(0,8)+"..":Eval("dormitoryGrade") %>'></asp:Label>
                        </a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbldormitoryPrice" runat="server" Text='<%# Eval("dormitoryPrice","{0:C}") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <asp:Repeater ID="dgdShowDormitory" runat="server" OnItemCommand="dgdShowDormitory_ItemCommand">
        <ItemTemplate>
            <table style="padding: 5px; width: 100%; background-color: #94AAD6;">
                <tr>
                    <td rowspan="4" style="width: 110px;">
                        <a href='<%# "Websushejianjie.aspx?ID="+Eval("dormitoryID") %>'>
                            <asp:Image ID="imgCover" Width="100" Height="120" ImageUrl='<%# "~/Image/"+Eval("ISBN") %>' runat="server" />
                        </a>
                    </td>
                    <td style="text-align: left;">宿舍号：<%# Eval("dormitoryID") %></a></td>
                </tr>
                <tr>
                    <td style="text-align: left;">宿舍等级：<%# Eval("dormitoryGrade") %></td>
                </tr>
                <tr>
                    <td style="text-align: left;">价格：<%# Eval("dormitoryPrice","{0:C}") %></td>
                </tr>
                <tr>
                    <td style="text-align: left;">宿舍人数：<%# Eval("dormitoryPerso") %></td>
                </tr>
                <tr>
                    <td style="text-align: left;">宿舍长：<%# Eval("DormitoryBoos") %></td>
                </tr>
            </table>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <table style="padding: 5px; width: 100%; background-color: #FCE0A6;">
                <tr>
                    <td rowspan="4" style="width: 110px;">
                    <a href='<%# "Websushejianjie.aspx?ID="+Eval("dormitoryID") %>'>
                        <asp:Image ID="imgCover" Width="100" Height="120" ImageUrl='<%# "~/Image/"+Eval("ISBN") %>' runat="server" />
                    </a>
                        </td>
                    <td style="text-align: left;">宿舍号：<%# Eval("dormitoryID") %></td>
                </tr>
                <tr>
                    <td style="text-align: left;">宿舍等级：<%# Eval("dormitoryGrade") %></td>
                </tr>
                <tr>
                    <td style="text-align: left;">价格：<%# Eval("dormitoryPrice","{0:C}") %></td>
                </tr>
                <tr>
                    <td style="text-align: left;">宿舍人数：<%# Eval("dormitoryPerso") %></td>
                </tr>
                <tr>
                    <td style="text-align: left;">宿舍长：<%# Eval("DormitoryBoos") %></td>
                </tr>
            </table>
        </AlternatingItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:Repeater>
     <table>
                   <tr>
                       <td>
                           <asp:Button ID="bntProc" runat="server" Text="上一页" OnClick="bntProc_Click" />
                       </td>
                       <td>
                           <asp:Label ID="lblPage" runat="server" Text="Label"></asp:Label>
                           <asp:Button ID="bntNext" runat="server" Text="下一页" OnClick="bntNext_Click" />
                       </td>
                       <td>
                           <asp:HiddenField ID="hdfIndex" runat="server" />
                       </td>
                   </tr>
               </table>
</asp:Content>
