<%@ Page Title="" Language="C#" MasterPageFile="~/Dormuss.Master" AutoEventWireup="true" CodeBehind="WebManagement.aspx.cs" Inherits="Dormikktoryss.WebManagement" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>卫生名单查看</title>
        <link href="css/Forum_admin.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
        <div style="text-align: center">
            <strong><span style="font-size: 18px; color: Maroon">
                <br />
                <asp:Label ID="Label1" runat="server" Text="卫生信息查询"></asp:Label>
                <br />
                <br />
            </span></strong>
            <asp:Panel ID="pnlSearch"    runat="server">
                <table style="text-align: center; height: 80px; margin: 0 auto; width: 624px;" border="0" class="tableBorder1">
                    <tr>
                        

                        <td style="text-align: right;">宿舍号：</td>
                        <td>
                            <asp:TextBox ID="txtdormitoryID" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td style="text-align: right">卫生情况：</td>
                        <td>
                            <asp:TextBox ID="txtHygiene" runat="server" Width="150px"></asp:TextBox>
                        </td><td>
                        </td>
                        <td>
                            
                            <asp:Button ID="btnSearch" runat="server" Text="查  询"
                                OnClick="btnSearch_Click" />
                        </td>
                       
                    </tr>
                    <tr>
                        <td style="text-align: right">检查人员：</td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td style="text-align: right">检查时间：</td>
                        <td colspan="2"><asp:TextBox ID="txtManagementTime" runat="server"
                            Width="150px"></asp:TextBox>
                        </td>
                        <td>
        <asp:Button ID="btnListAll" runat="server" Text="显示全部"
            OnClick="btnListAll_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            卫生信息 (共有 
        <asp:Label ID="lblStuNum" runat="server" ForeColor="Blue" Text="0"></asp:Label>
            个宿舍，符合查询条件的有
            <asp:Label ID="lblStuFilterNum" runat="server" ForeColor="Blue" Text="0"></asp:Label>
            个)<br />
                
            <br />
            <br />
            <input type="button" value="新增卫生信息" onclick="window.open('WebInsertManagement.aspx', '_self');" />&nbsp;&nbsp;&nbsp;&nbsp;
            <br /><br /><br /><br />
            <div style="width:80%; margin-left:30%  ">
            <asp:ListView ID="ListView1" runat="server">
                
                <ItemTemplate>
                    <tr style="background-color: #E0FFFF;color: #333333;">
                        <td>
                            <asp:Label ID="ManagementIDLabel" runat="server" Text='<%# Eval("ManagementID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="dormitoryIDLabel" runat="server" Text='<%# Eval("dormitoryID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="HygieneLabel" runat="server" Text='<%# Eval("Hygiene") %>' />
                        </td>
                        <td>
                            <asp:Label ID="InspectorsLabel" runat="server" Text='<%# Eval("Inspectors") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ManagementTimeLabel" runat="server" Text='<%# Eval("ManagementTime") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ExplainLabel" runat="server" Text='<%# Eval("Explain") %>' />
                        </td>
                        <td>
                            <asp:Label ID="StateLabel" runat="server" Text='<%# Eval("State") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                        <th runat="server" style="color:black;">编号</th>
                                        <th runat="server" style="color:black;">宿舍号</th>
                                        <th runat="server" style="color:black;">卫生情况</th>
                                        <th runat="server" style="color:black;">检查人员</th>
                                        <th runat="server" style="color:black;">检查时间</th>
                                        <th runat="server" style="color:black;">说明</th>
                                        <th runat="server" style="color:black;">状态</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                                <asp:DataPager ID="DataPager1" runat="server">
                                   
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
                </div>
        </div>
    </body>
    </html>
    <table style="width:80%;margin-left:40%">
                   <tr>
                       <td>
                            <asp:Button ID="bntProc" runat="server" Text="上一页" OnClick="bntProc_Click" />
                           <asp:Label ID="lblPage" runat="server" Text="Label"></asp:Label>
                           <asp:Button ID="bntNext" runat="server" Text="下一页" OnClick="bntNext_Click" />
                       </td>
                       <td>
                           <asp:HiddenField ID="hdfIndex" runat="server" />
                       </td>
                   </tr>
               </table>
</asp:Content>
