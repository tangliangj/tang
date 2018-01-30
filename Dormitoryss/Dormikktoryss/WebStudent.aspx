<%@ Page Title="" Language="C#" MasterPageFile="~/Dormuss.Master" AutoEventWireup="true" CodeBehind="WebStudent.aspx.cs" Inherits="Dormikktoryss.WebStudent" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>学生名单查看</title>
        <link href="css/Forum_admin.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
        <div style="text-align: center">
            <strong><span style="font-size: 18px; color: Maroon">
                <br />
                <asp:Label ID="Label1" runat="server" Text="学生信息查询"></asp:Label>
                <br />
                <br />
            </span></strong>
            <asp:Panel ID="pnlSearch" runat="server">
                <table style="text-align: center; height: 80px; margin: 0 auto;" border="0" class="tableBorder1">
                    <tr>
                        <td style="text-align: right;">学　号：</td>
                        <td>
                            <asp:TextBox ID="txtStuID" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td style="text-align: right">姓　　名：</td>
                        <td>
                            <asp:TextBox ID="txtStuName" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td style="text-align: right">性　  别：</td>
                        <td>
                            <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">

                                <asp:ListItem Selected="True" Value="male">男</asp:ListItem>
                                <asp:ListItem Value="female">女</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">手机号：</td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td style="text-align: right">入住时间：</td>
                        <td colspan="2" style="text-align: left">从<asp:TextBox ID="txtAccommodationtime" runat="server"
                            Width="80px"></asp:TextBox>
                            到<asp:TextBox ID="txtleavetime" runat="server" Width="80px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="查  询"
                                OnClick="btnSearch_Click" />&nbsp;
        <asp:Button ID="btnListAll" runat="server" Text="显示全部"
            OnClick="btnListAll_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            学生名单 (共有 
        <asp:Label ID="lblStuNum" runat="server" ForeColor="Blue" Text="0"></asp:Label>
            名学生，符合查询条件的有
            <asp:Label ID="lblStuFilterNum" runat="server" ForeColor="Blue" Text="0"></asp:Label>
            名)
            <br /><br /><br />
            <input type="button" value="新增学生" onclick="window.open('WebInsertStudent.aspx', '_self');" />&nbsp;&nbsp;&nbsp;&nbsp;
            <br /><br /><br /><br />
                <div style="width:80%;margin-left:17%">
                    <asp:ListView ID="ListView1" runat="server">
                        
                        <ItemTemplate>
                            <tr style="background-color: #E0FFFF; color: #333333;">
                                <td>
                                    <asp:Label ID="StudentIDLabel" runat="server" Text='<%# Eval("StudentID") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="StudentNameLabel" runat="server" Text='<%# Eval("StudentName") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("Age") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="dormitoryIDLabel" runat="server" Text='<%# Eval("dormitoryID") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="PlaceLabel" runat="server" Text='<%# Eval("Place") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="AccommodationtimeLabel" runat="server" Text='<%# Eval("Accommodationtime") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="leavetimeLabel" runat="server" Text='<%# Eval("leavetime") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ExplainsLabel" runat="server" Text='<%# Eval("Explains") %>' />
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
                                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                            <tr runat="server" style="background-color: #E0FFFF; color: #333333;">
                                                <th runat="server" style="color: black;">学号</th>
                                                <th runat="server" style="color: black;">姓名</th>
                                                <th runat="server" style="color: black;">年龄</th>
                                                <th runat="server" style="color: black;">性别</th>
                                                <th runat="server" style="color: black;">宿舍号</th>
                                                <th runat="server" style="color: black;">籍贯</th>
                                                <th runat="server" style="color: black;">入住时间</th>
                                                <th runat="server" style="color: black;">离开时间</th>
                                                <th runat="server" style="color: black;">手机号</th>
                                                <th runat="server" style="color: black;">说明</th>
                                                <th runat="server" style="color: black;">状态</th>
                                            </tr>
                                            <tr id="itemPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
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
    <table style="width:80%;margin-left:30%">
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

