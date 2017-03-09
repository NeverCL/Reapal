<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ReapalFastApiDemo.index" %>
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
    <form id="form1" runat="server">
        <div align="center">			
			<div align="center"><img src="images/reapal.png" /></div>
			<table class="base list">
                <caption>网关支付接口列表</caption>
                <tbody>
					<tr>
						<th><a href="pay.aspx">支付</a></th><td>参考balanceQuery.aspx</td><td>【http://testapi.reapal.com/account/portal/】</td>
					</tr>
					<tr>
						<th><a href="payQuery.aspx">查询</a></th><td>参考payQuery.aspx</td><td>【http://testapi.reapal.com/fast/search/】</td>
					</tr>
					<tr>
						<th><a href="refund.aspx">退款</a></th><td>参考refund.aspx</td><td>【http://testapi.reapal.com/fast/refund/】</td>
					</tr>
                </tbody>
			</table>
            <div class="copyright">融宝支付©版权所有</div>		
        </div>  
    </form>
</body>
</html>
