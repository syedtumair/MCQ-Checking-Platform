<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Oops.aspx.cs" Inherits="khwab.ErrorPages.Oops" %>

<!doctype html>
<!--[if lte IE 9]> <html class="lte-ie9" lang="en"> <![endif]-->
<!--[if gt IE 9]><!--> <html lang="en"> <!--<![endif]-->
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="initial-scale=1.0,maximum-scale=1.0,user-scalable=no">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <link rel="icon" type="image/png" href="../Content/assets/img/favicon-16x16.png" sizes="16x16">
    <link rel="icon" type="image/png" href="../Content/assets/img/favicon-32x32.png" sizes="32x32">

    <title>404 error</title>

    <link href='http://fonts.googleapis.com/css?family=Roboto:300,400,500' rel='stylesheet' type='text/css'>

    <!-- uikit -->
    <link rel="stylesheet" href="../Content/bower_components/uikit/css/uikit.almost-flat.min.css"/>

    <!-- altair admin error page -->
    <link rel="stylesheet" href="../Content/assets/css/error_page.min.css" />

</head>
<body class="error_page">

    <div class="error_page_header">
        <div class="uk-width-8-10 uk-container-center">
            404!
        </div>
    </div>
    <div class="error_page_content">
        <div class="uk-width-8-10 uk-container-center">
            <p class="heading_b">Page not found</p>
            <p class="uk-text-large">
                The requested URL <span class="uk-text-muted"></span> was not found on this server.
            </p>
            <a href="#" onclick="history.go(-1);return false;">Go back to previous page</a>
            <a href="~/Account/Login"  class="md-btn md-btn-success">Go back to Login page</a>
        </div>
    </div>

</body>
</html>
