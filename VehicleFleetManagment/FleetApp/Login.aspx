<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vehicle fleet Managment</title>
    <!-- Meta -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- Favicon icon -->

    <%--<link rel="icon" href="assets/images/favicon.ico" type="image/x-icon">--%>
    <!-- Google font-->
    <%--<link href="https://fonts.googleapis.com/css?family=Roboto:400,500" rel="stylesheet">--%>
    <!-- Required Fremwork -->
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap/css/bootstrap.min.css"/>
    <!-- waves.css -->
    <%--<link rel="stylesheet" href="assets/pages/waves/css/waves.min.css" type="text/css" media="all">--%>
    <!-- themify-icons line icon -->
    <link rel="stylesheet" type="text/css" href="assets/icon/themify-icons/themify-icons.css"/>
    <!-- ico font -->
    <link rel="stylesheet" type="text/css" href="assets/icon/icofont/css/icofont.css"/>
    <!-- Font Awesome -->
    <link rel="stylesheet" type="text/css" href="assets/icon/font-awesome/css/font-awesome.min.css"/>
    <!-- Style.css -->
    <link rel="stylesheet" type="text/css" href="assets/css/loginstyle.css"/>
</head>
<body >
    <!-- Pre-loader start -->
   <%-- <div class="theme-loader">
        <div class="loader-track">
            <div class="preloader-wrapper">
                <div class="spinner-layer spinner-blue">
                    <div class="circle-clipper left">
                        <div class="circle"></div>
                    </div>
                    <div class="gap-patch">
                        <div class="circle"></div>
                    </div>
                    <div class="circle-clipper right">
                        <div class="circle"></div>
                    </div>
                </div>
                <div class="spinner-layer spinner-red">
                    <div class="circle-clipper left">
                        <div class="circle"></div>
                    </div>
                    <div class="gap-patch">
                        <div class="circle"></div>
                    </div>
                    <div class="circle-clipper right">
                        <div class="circle"></div>
                    </div>
                </div>

                <div class="spinner-layer spinner-yellow">
                    <div class="circle-clipper left">
                        <div class="circle"></div>
                    </div>
                    <div class="gap-patch">
                        <div class="circle"></div>
                    </div>
                    <div class="circle-clipper right">
                        <div class="circle"></div>
                    </div>
                </div>

                <div class="spinner-layer spinner-green">
                    <div class="circle-clipper left">
                        <div class="circle"></div>
                    </div>
                    <div class="gap-patch">
                        <div class="circle"></div>
                    </div>
                    <div class="circle-clipper right">
                        <div class="circle"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <!-- Pre-loader end -->

    <section class="login-block">
        <!-- Container-fluid starts -->
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <!-- Authentication card start -->

                    <form class="md-float-material form-material" runat="server" method="post" >
                               <div class="col-sm-6 mx-auto" id="msg">
                                    <div class="alert alert-success alert-dismissible fade show" runat="server" id="SuccessMsg">
                                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                                        <strong>Success!  <i class="fa fa-check-square"></i></strong>
                                    </div>
                                    <div class="alert alert-danger alert-dismissible fade show" runat="server" id="FailMsg">
                                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                                        <strong>Wrong username or password  <i class="fa fa-warning"></i></strong>
                                    </div>

                                   <div class="alert alert-danger alert-dismissible fade show" runat="server" id="AdmMsg">
                                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                                        <strong>Something goes wrong <br/> contact the administrator  <i class="fa fa-phone"></i></strong>
                                    </div>
                                </div>
                        
                        <div class="auth-box card">
                            <div class="card-block ">
                                <div class="row m-b-20">
                                    <div class="col-md-12">
                                        <h3 class="text-center">Authenticate</h3>
                                    </div>
                                </div>
                                    <div class="form-group form-primary">
                                        <input type="text" name="email" class="form-control"  id="txtUserName" runat="server" required="required"/>
                                        <span class="form-bar"></span>
                                        <label class="float-label">Your username</label>
                                    </div>
                                    <div class="form-group form-primary">
                                        <input type="password" name="password" class="form-control"  id="txtPassWord" runat="server" required="required" />
                                        <i class=" fa fa-eye" id="togglePassword" style="margin-left: -30px; cursor: pointer;" onclick="myFunction()"></i>
                                        <span class="form-bar"></span>
                                        <label class="float-label">Password</label>
                                    </div>                                                             
                                    <div class="row m-t-25 text-left">
                                        <div class="col-12">
                                            <div class="checkbox-fade fade-in-primary d-">
                                                <label>
                                                    <input type="checkbox" value="" runat="server" id="CheckRemember" />
                                                    <span class="cr"><i class="cr-icon icofont icofont-ui-check txt-primary"></i></span>
                                                    <span class="text-inverse">Remember me</span>
                                                </label>
                                            </div>
                                            <div class="forgot-phone text-right f-right">
                                                <a href="#" class="text-right f-w-600">Forgot Password?</a>
                                            </div>
                                        </div>
                                    </div>
                                     
                                    <div class="row m-t-30">
                                        <div class="col-md-12 form-group form-primary">
                                           <button type="submit" class="btn btn-primary btn-md btn-block waves-effect waves-light text-center m-b-20" runat="server" id="btnconnexion"  onserverclick="btn_connexion_ServerClick" >Sign in</button>                      
                                        </div>
                                    </div>
                            </div>
                        </div>
                    </form>
                    <!-- end of form -->
                </div>
                <!-- end of col-sm-12 -->"
            </div>
            <!-- end of row -->
        </div>
        <!-- end of container-fluid -->
    </section>
    <!-- Required Jquery -->
    <script type="text/javascript" src="assets/js/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="assets/js/jquery-ui/jquery-ui.min.js "></script>
    <script type="text/javascript" src="assets/js/popper.js/popper.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap/js/bootstrap.min.js "></script>
    <!-- waves js -->
    <script src="assets/pages/waves/js/waves.min.js"></script>
    <!-- jquery slimscroll js -->
    <script type="text/javascript" src="assets/js/jquery-slimscroll/jquery.slimscroll.js "></script>
    <!-- modernizr js -->
    <script type="text/javascript" src="assets/js/SmoothScroll.js"></script>
    <script src="assets/js/jquery.mCustomScrollbar.concat.min.js "></script>
    <!-- i18next.min.js -->
    <script type="text/javascript" src="bower_components/i18next/js/i18next.min.js"></script>
    <script type="text/javascript" src="bower_components/i18next-xhr-backend/js/i18nextXHRBackend.min.js"></script>
    <script type="text/javascript" src="bower_components/i18next-browser-languagedetector/js/i18nextBrowserLanguageDetector.min.js"></script>
    <script type="text/javascript" src="bower_components/jquery-i18next/js/jquery-i18next.min.js"></script>
    <script type="text/javascript" src="assets/js/common-pages.js"></script>

    <script>
        function myFunction() {
            var x = document.getElementById("txtPassWord");
            var y = document.getElementById("togglePassword");
            if (x.type === "password") {
                x.type = "text";
                
            } else {
                x.type = "password";               
            }
            y.classList.toggle('fa-eye-slash');
        }
    </script>
</body>
</html>
