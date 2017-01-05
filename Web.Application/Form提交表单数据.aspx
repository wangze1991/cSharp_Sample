<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form提交表单数据.aspx.cs" Inherits="Web.Application.Form提交表单数据" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form method="post" action="Form提交表单数据" enctype="multipart/form-data">
    <div>
        <input type="text" value="测试" name="txt1"/>
        <input type="text" value="测试2" name="txt2"/>
        <input type="submit" value="提交"/>
    </div>
    </form>
</body>
</html>
