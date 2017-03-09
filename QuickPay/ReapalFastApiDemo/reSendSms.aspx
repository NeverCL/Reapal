<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reSendSms.aspx.cs" Inherits="ReapalFastApiDemo.reSendSms" %>
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
			<div class="logo"><img src="images/reapal.png" /></div>
			<table class="base input">
                <caption>融宝快捷重发短信验证码接口<span class="back"><a href="index.aspx">返回目录</a></span></caption>
                <tbody>
					<tr>
						<th><span class="red">*</span>商户号：</th><td><asp:TextBox id="merchant_id" Text="" runat="server" /></td>
					</tr>
                    <tr>
						<th><span class="red">*</span>商户订单号：</th><td><asp:TextBox id="order_no" Text="" runat="server" /></td>
					</tr>
                    
					
                </tbody>
                <tfoot><tr><td colspan="2"><asp:Button id="btnOK" Text="提交" runat="server" OnClientClick="return checkForm();" OnClick="btnOK_Click" /></td></tr></tfoot>
			</table>
            <asp:TextBox id="result" rows="5" TextMode="multiline" runat="server" Columns="110" />
            <div class="copyright">融宝支付@版权所有</div>
        </div>
    </form>

    <script type="text/javascript">
        function checkForm()//验证手机 
        {
            var merchant_id = document.getElementById("merchant_id");
            if (merchant_id.value == "") {
                alert("商户号不能为空！");
                merchant_id.focus();
                return false;
            }

            var order_no = document.getElementById("order_no");
            if (order_no.value == "") {
                alert("商户订单号不能为空！");
                order_no.focus();
                return false;
            }

            return true;
        }
</script>
</body>
</html>
