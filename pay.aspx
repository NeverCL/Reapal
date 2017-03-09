<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pay.aspx.cs" Inherits="ReapalFastApiDemo.pay" %>
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
                <caption>支付<span class="back"><a href="index.aspx">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;返回目录</a></span></caption>
                <tbody>
                    <tr>
						<th><span class="red">*</span>会员id：</th><td><asp:TextBox id="member_id" Text="" runat="server" /></td>
					</tr>
                    <tr>
						<th><span class="red">*</span>商品名称：</th><td><asp:TextBox id="title" Text="" runat="server" /></td>
					</tr>
                    <tr>
						<th><span class="red">*</span>商品描述：</th><td><asp:TextBox id="body" Text="" runat="server" /></td>
					</tr>
                    <tr>
						<th><span class="red">*</span>付款金额：</th><td><asp:TextBox id="Rongmoney" Text="" CssClass="input" runat="server" />(单位：元)</td>
					</tr>
                    <tr>
						<th><span class="red">*</span>是否直连银行：</th>
                        <td>
                              <input type="radio"   name="defaultbank2" value="1" onclick="on_hide();"  />是&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <input type="radio"   name="defaultbank2" value="0" checked="checked" onclick="on_hide();"/>否
                        </td>
					</tr>
                </tbody>
                <tfoot><tr><td colspan="2"><asp:Button id="btnOK" Text="提交" runat="server" OnClientClick="return checkForm();" OnClick="btnOK_Click" /></td></tr></tfoot>
			</table>

           <div id="bank" style="display:none;">
               <table>
                <tr>
                            <td><input type="radio" name="defaultbank" value="CMB"/></td>
                            <td><img src="images/cmb.png"/></td>
                            <td ><input type="radio" name="defaultbank" value="ICBC"/></td>
                            <td ><img src="images/icbc.png"/></td>
                            <td><input type="radio" name="defaultbank" value="CCB"/></td>
                            <td><img src="images/ccb.png"/></td>
                           </tr>
                          <tr>
                            <td ><input type="radio" name="defaultbank" value="BOC"/></td>
                            <td><img src="images/boc.png"/></td>
                            <td ><input type="radio" name="defaultbank" value="ABC"/></td>
                            <td ><img src="images/abc.png"/></td>
                            <td><input type="radio" name="defaultbank" value="BOCM"/></td>
                            <td ><img src="images/bankcomm.png"/></td>
                           </tr>
                          <tr>
                            <td><input type="radio" name="defaultbank" value="SPDB"/></td>
                            <td><img src="images/spdb.png"/></td>
                            <td><input type="radio" name="defaultbank" value="CGB"/></td>
                            <td><img src="images/gdb.png"/></td>
                            <td><input type="radio" name="defaultbank" value="CITIC"/></td>
                            <td><img src="images/ecitic.png"/></td>
                          </tr>
                            <tr>
                            <td><input type="radio" name="defaultbank" value="CEB"/></td>
                            <td><img src="images/ceb.png"/></td>
                            <td><input type="radio" name="defaultbank" value="CIB"/></td>
                            <td><img src="images/cib.png"/></td>
                            <td><input type="radio" name="defaultbank" value="LITEPAY"/></td>
                            <td><img src="images/LITEPAY.png"/></td>
                           </tr>
                          <tr>
                            <td><input type="radio" name="defaultbank" value="CMBC"/></td>
                            <td><img src="images/cmbc.png"/></td>
                            <td><input type="radio" name="defaultbank" value="HXB"/></td>
                            <td><img src="images/hxb.png"/></td>
                            <td><input type="radio" name="defaultbank" value="SPA"/></td>
                            <td><img src="images/pingan.png"/></td>
                           </tr>
                   </table>
           </div>
           
        </div>
    </form>

    <script type="text/javascript">
        var radValue = 0;
        function on_hide() {

            var a = document.getElementsByName("defaultbank2");

            for (var i = 0; i < a.length; i++) {
                if (a[i].checked) {
                    radValue = a[i].value;
                }
            }
            if (radValue == 1) {
                document.getElementById("bank").style.display = "block";
            } else {
                document.getElementById("bank").style.display = "none";
            }
        }
</script>
</body>
</html>
