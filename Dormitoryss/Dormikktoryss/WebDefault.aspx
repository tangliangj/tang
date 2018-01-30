<%@ Page Title="" Language="C#" MasterPageFile="~/Dormuss.Master" AutoEventWireup="true" CodeBehind="WebDefault.aspx.cs" Inherits="Dormikktoryss.WebDefault" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
<link rel="stylesheet" href="css/style.css"/>
    <script src="js/jquery.min.js"></script>
    <script src="js/YuxiSlider.jQuery.min.js"></script>

   
<div class="demo"  style="float:left;">
	<a class="control prev"></a><a class="control next abs"></a><!--自定义按钮，移动端可不写-->
	<div class="slider"><!--主体结构，请用此类名调用插件，此类名可自定义-->
		<ul style="text-align:center;">
			<li><a><img src="Image/101.jpg" /></a></li>
			<li><a><img src="Image/102.jpg"  /></a></li>
			<li><a><img src="Image/104.jpg"  /></a></li>
			<li><a><img src="Image/106.jpg"/></a></li>
			<li><a><img src="Image/107.jpg"  /></a></li>
			<li><a><img src="Image/108.jpg" /></a></li>
		</ul>

	</div>
</div>
    <br /><br /><br /><br /><br />
    <div style="text-align:center;">
        <h1><asp:Label ID="Label3" runat="server" Text="系统简介："></asp:Label></h1>
        <br />
        </div>
    <div>
       <h3> <asp:Label ID="Label1" runat="server" Text=" &nbsp;&nbsp;&nbsp;&nbsp; 学生宿舍管理系统对于一个学习来说是必不可少的组成部分。对于信息量比较庞大，需要记录存档的数据比较多的学校来说，人工记录是相当麻烦的为此我针对目前学习发展的实际状况，对本宿舍管理系统的设计开发做了一个概述。"></asp:Label></h3>
    </div>
   
<script>
    $(".slider").YuxiSlider({
        width: 800, //容器宽度
        height: 450, //容器高度
        control: $('.control'), //绑定控制按钮
        during: 4000, //间隔4秒自动滑动
        speed: 800, //移动速度0.8秒
        mousewheel: true, //是否开启鼠标滚轮控制
        direkey: true //是否开启左右箭头方向控制
    });
</script>
 

</asp:Content>
