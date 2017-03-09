<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="return_url.aspx.cs" Inherits="ReapalFastApiDemo.return_url" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<meta name="renderer" content="webkit">
    <title>融宝支付</title>
    <link href="css/style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <div class="w">
        <header id="top" class="header">
	        <h2>荣程商城</h2>
	        <a class="back" onclick="window.history.back()">返回</a>
	    </header>
	        返回值：<td id="m1" runat="server" class="tc"></td>
            解密后：<td id="m2" runat="server" class="tc"></td>
	    <footer>
		    <div class="copyright">Copyright &copy; 2015 融宝支付</div>	
	    </footer>
    </div>
</body>
</html>
