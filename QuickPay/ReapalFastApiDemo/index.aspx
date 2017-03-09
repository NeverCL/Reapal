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
                <caption>融宝快捷支付API接口列表</caption>
                <tbody>
					<tr>
						<th><a href="debit.aspx">储蓄卡同卡签约接口</a></th><td>参考debit.aspx</td><td>【api.reapal.com/fast/debit/portal】</td>
					</tr>
					<tr>
						<th><a href="bindListQuery.aspx">查询绑卡列表接口</a></th><td>参考bindListQuery.aspx</td><td>【api.reapal.com/fast/bindcard/list】</td>
					</tr>
					<tr>
						<th><a href="bindCard.aspx">绑卡签约接口</a></th><td>参考bindCard.aspx</td><td>【api.reapal.com/fast/bindcard/portal】</td>
					</tr>
					<tr>
						<th><a href="reSendSms.aspx">重发短信验证码接口</a></th><td>参考reSendSms.aspx</td><td>【api.reapal.com/fast/sms】</td>
					</tr>
					<tr>
						<th><a href="submit.aspx">确认支付接口</a></th><td>参考submit.aspxx</td><td>【api.reapal.com/fast/pay】</td>
					</tr>
					<tr>
						<th><a href="search.aspx">支付结果查询接口</a></th><td>参考search.aspx</td><td>【api.reapal.com/fast/search】</td>
					</tr>
					<tr>
						<th><a href="cannelCard.aspx">解绑卡接口</a></th><td>参考cannelCard.aspxx</td><td>【api.reapal.com/fast/cancle/bindcard】</td>
					</tr>
					<tr>
						<th><a href="refund.aspx">退款接口</a></th><td>参考refund.aspxx</td><td>【api.reapal.com/fast/refund】</td>
					</tr>
					<tr>
						<th><a href="queryBankCard.aspx">卡信息查询接口</a></th><td>参考queryBankCard.aspx</td><td>【api.reapal.com/fast/ bankcard/list】</td>
					</tr>
					<tr>
						<th><a href="certificate.aspx">卡密鉴权接口</a></th><td>参考certificate.aspx</td><td>【api.reapal.com/fast/certificate】</td>
					</tr>
                </tbody>
			</table>
            <div class="copyright">融宝支付©版权所有</div>		
        </div>  
    </form>
</body>
</html>
