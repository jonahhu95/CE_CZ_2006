﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ASPWebsite.Home" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>3° Burn - Is The Job Worth It?</title>
    <link rel="icon" href="img/icon.png">
    <!-- Bootstrap core CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom fonts for this template -->
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Lato:400,700,400italic,700italic" rel="stylesheet" type="text/css">

    <!-- Custom styles for this template -->
    <link href="css/freelancer.min.css" rel="stylesheet">

    <style>
        #map {
            width: 100%;
            height: 400px;
            background-color: grey;
        }
    </style>


</head>

<body id="page-top">
    <form id="form1" runat="server">
        <!-- Navigation -->
        <nav class="navbar navbar-expand-lg navbar-light fixed-top" id="mainNav">
            <div class="container">
                <a class="navbar-brand js-scroll-trigger" href="#page-top">3° Burn</a>
                <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                    Menu
                <i class="fa fa-bars"></i>
                </button>
                <div class="collapse navbar-collapse" id="navbarResponsive">
                    <ul class="navbar-nav ml-auto">
                        <!--<li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="#portfolio">Calculate Job Satisfaction Index</a>
                    </li>-->
                        <!--<li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="#about">About</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="#contact">Contact</a>
                    </li>-->
                        <li class="nav-item">
                            <a class="nav-link btn-info btn-lg" data-toggle="modal" style="" href="#Login">Login</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="modal fade" id="Login" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Login</h4>
                    </div>
                    <div class="modal-body">
                        <%--<div class="form-group">
                            <label for="exampleInputEmail1">Email address</label>
                            <asp:TextBox ID="tbEmail" class="form-control" runat="server"></asp:TextBox>
                            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">--%>
                        <%--  <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1">Password</label>
                            <asp:TextBox ID="tbPassword" class="form-control" runat="server"></asp:TextBox>
                            <%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">--%>
                        <%-- </div>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input type="checkbox" class="form-check-input">
                                Check me out
                            </label>
                        </div>--%>
                        <asp:Label ID="exampleInputEmail1" runat="server" Text="Email address"></asp:Label>
                        <asp:TextBox ID="tbEmail" class="form-control" runat="server"></asp:TextBox>
                        <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">--%>
                        <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>

                        <asp:Label ID="exampleInputPassword1" runat="server" Text="Password"></asp:Label>
                        <%--<label for="exampleInputPassword1">Password</label>--%>
                        <asp:TextBox ID="tbPassword" class="form-control" runat="server"></asp:TextBox><br />
                        <%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">--%>


                        <asp:Button ID="loginBtn" class="btn btn-primary" runat="server" Text="Login" OnClick="loginBtn_Click1" />

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>

        <image src="img/scrolldownbutton.gif" style="position: fixed; bottom: 10px; right: 10px; height: 90px; border-radius: 90px; background-color: black; opacity: 0.7;"></image>
        <!-- Header -->
        <header class="masthead">
            <div class="container">
                <img class="img-fluid" src="img/main.jpg" alt="" height="420" width="500">
                <div class="intro-text">
                    <span class="name">Is the job worth it?</span>
                    <hr class="star-light">
                    <span class="skills">Is the job offer worth the effort and time?<br />
                        Find your answers here!</span><br />
                    <br />
                    <a class="btn btn-primary js-scroll-trigger" href="#JSI">Calculate Job Satisfaction Index</a>

                </div>
            </div>
        </header>

        <section id="JSI">
            <div class="container">
                <h2 class="text-center">Calculate Job Satisfaction Index</h2>
                <hr class="star-primary">
                <div class="row">
                    <div class="col-lg-8 mx-auto">
                        <!-- To configure the contact form email address, go to mail/contact_me.php and update the email address in the PHP file on line 19. -->
                        <!-- The form should work on most web servers, but if the form is not working you may need to configure your web server differently. -->
                        <%--<form name="sentMessage" id="contactForm" novalidate>--%>
                        <%--<div class="control-group">
                            <div class="form-group floating-label-form-group controls">
                                <label>Home Location</label>
                                <input class="form-control" id="name" type="text" placeholder="Home Location" required data-validation-required-message="Please enter your home location.">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls">
                                <label>Job Location</label>
                                <input class="form-control" id="email" type="email" placeholder="Job Location" required data-validation-required-message="Please enter your job location.">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls">
                                <label>Salary</label>
                                <input class="form-control" id="phone" type="tel" placeholder="Salary" required data-validation-required-message="Please enter your salary.">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>--%>
                        <br>
                        <div id="success"></div>
                        <div class="form-group">
                            Home Location:
                            <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox><br />
                            Job Location:
                            <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox><br />
                            Salary:
                            <asp:TextBox ID="TextBox3" class="form-control" runat="server"></asp:TextBox><br />
                            <asp:Button ID="sendMessage" class="btn btn-success btn-lg" runat="server" Text="Submit" OnClick="sendMessage_Click" />
                            <asp:Label ID="Label1" runat="server" Text="Nothing"></asp:Label>
                            <%--<button type="submit" class="btn btn-success btn-lg" id="sendMessageButton" >Submit</button>--%>
                        </div>
                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </section>

        <!-- About Section -->
        <section class="success" id="Description">
            <div class="container">
                <h2 class="text-center">CRITERIA</h2>
                <hr class="star-light">
                <div class="row">
                    <div class="col-lg-4 ml-auto">
                        <!--<p>Freelancer is a free bootstrap theme created by Start Bootstrap. The download includes the complete source files including HTML, CSS, and JavaScript as well as optional LESS stylesheets for easy customization.</p>-->
                    </div>
                    <div class="col-lg-4 mr-auto">
                        <!--<p>Whether you're a student looking to showcase your work, a professional looking to attract clients, or a graphic artist looking to share your projects, this template is the perfect starting point!</p>-->
                    </div>
                    <div class="col-lg-8 mx-auto text-center">
                        <!-- <a href="calculator.html" class="btn btn-lg btn-outline">
                        <i class="fa fa-download"></i>
                       Download Theme -->


                        <hr class="small">
                        <div class="row">
                            <div class="col-md-3 col-sm-6">
                                <div class="service-item">
                                    <span class="fa-stack fa-4x">
                                        <!--<i class="fa fa-circle fa-stack-2x"></i>
                    <i class="fa fa-cloud fa-stack-1x text-primary"></i> -->
                                        <img src="img/time.jpg" class="round" />
                                    </span>
                                    <h4>
                                        <strong>COMMUTE TIME</strong>
                                    </h4>
                                    <p>Sense of time pressure, people who spend more time on the road feel more hurried and stress.</p>
                                    <!--<a href="#" class="btn btn-light">Learn More</a> -->
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-6">
                                <div class="service-item">
                                    <span class="fa-stack fa-4x">
                                        <!--<i class="fa fa-circle fa-stack-2x"></i>
                    <i class="fa fa-compass fa-stack-1x text-primary"></i> -->
                                        <img src="img/distance.jpg" class="round" />
                                    </span>
                                    <h4>
                                        <strong>COMMUTE DISTANCE</strong>
                                    </h4>
                                    <p>A shorter distance to work means a shorter distance home, improving person wellness.</p>
                                    <!-- <a href="#" class="btn btn-light">Learn More</a> -->
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-6">
                                <div class="service-item">
                                    <span class="fa-stack fa-4x">
                                        <!--<i class="fa fa-circle fa-stack-2x"></i>
                    <i class="fa fa-flask fa-stack-1x text-primary"></i>-->
                                        <img src="img/salary.jpg" class="round" />
                                    </span>
                                    <h4>
                                        <strong>SALARY</strong>
                                    </h4>
                                    <p>A job salary in proportion to its workload makes an employee feel appreciated.</p>
                                    <!--<a href="#" class="btn btn-light">Learn More</a> -->
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-6">
                                <div class="service-item">
                                    <span class="fa-stack fa-4x">
                                        <!--<i class="fa fa-circle fa-stack-2x"></i>
                    <i class="fa fa-shield fa-stack-1x text-primary"></i>-->
                                        <img src="img/interest.jpg" class="round" />
                                    </span>
                                    <h4>
                                        <strong>INTEREST</strong>
                                    </h4>
                                    <p>A strong desire to work in a particular Company is a powerful moltivator.</p>
                                    <!--<a href="#" class="btn btn-light">Learn More</a> -->
                                </div>
                            </div>
                        </div>
                        <!-- /.row (nested) -->
                    </div>


                    </a>
                </div>
            </div>
            </div>

        </section>

        <!-- Contact Section -->
        <!--<section id="contact">
        <div class="container">
            <h2 class="text-center">Feedback</h2><br>
				<p><font size="+2.5">  Your opinions are important to us. We appreciate your feedbacks and are committed in enhancing your job searching experiences. Kindly leave us your particulars and we would respond to you shortly&#x263A</p></center><br>
            <hr class="star-primary">
            <div class="row">
                <div class="col-lg-8 mx-auto">-->
        <!-- To configure the contact form email address, go to mail/contact_me.php and update the email address in the PHP file on line 19. -->
        <!-- The form should work on most web servers, but if the form is not working you may need to configure your web server differently. -->
        <!--<form name="sentMessage" id="contactForm" novalidate>
                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls">
                                <label>Name</label>
                                <input class="form-control" id="name" type="text" placeholder="Name" required data-validation-required-message="Please enter your name.">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls">
                                <label>Email Address</label>
                                <input class="form-control" id="email" type="email" placeholder="Email Address" required data-validation-required-message="Please enter your email address.">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls">
                                <label>Phone Number</label>
                                <input class="form-control" id="phone" type="tel" placeholder="Phone Number" required data-validation-required-message="Please enter your phone number.">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls">
                                <label>Message</label>
                                <textarea class="form-control" id="message" rows="5" placeholder="Message" required data-validation-required-message="Please enter a message."></textarea>
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>
                        <br>
                        <div id="success"></div>
                        <div class="form-group">
                            <button type="submit" class="btn btn-success btn-lg" id="sendMessageButton">Send</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>-->

        <!-- Footer -->
        <footer class="text-center">
            <div class="footer-above">
                <div class="container">
                    <div class="row">
                        <div class="footer-col col-md-4">
                            <h3>Location</h3>
                            <p>
                                3481 Melrose Place
                            <br>
                                Beverly Hills, CA 90210
                            </p>
                        </div>
                        <div class="footer-col col-md-4">
                            <h3>Around the Web</h3>
                            <ul class="list-inline">
                                <li class="list-inline-item">
                                    <a class="btn-social btn-outline" href="#">
                                        <i class="fa fa-fw fa-facebook"></i>
                                    </a>
                                </li>
                                <li class="list-inline-item">
                                    <a class="btn-social btn-outline" href="#">
                                        <i class="fa fa-fw fa-google-plus"></i>
                                    </a>
                                </li>
                                <li class="list-inline-item">
                                    <a class="btn-social btn-outline" href="#">
                                        <i class="fa fa-fw fa-twitter"></i>
                                    </a>
                                </li>
                                <li class="list-inline-item">
                                    <a class="btn-social btn-outline" href="#">
                                        <i class="fa fa-fw fa-linkedin"></i>
                                    </a>
                                </li>
                                <li class="list-inline-item">
                                    <a class="btn-social btn-outline" href="#">
                                        <i class="fa fa-fw fa-dribbble"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div class="footer-col col-md-4">
                            <h3>About Freelancer</h3>
                            <p>
                                Freelance is a free to use, open source Bootstrap theme created by
                            <a href="http://startbootstrap.com">Start Bootstrap</a>.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer-below">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                            Copyright &copy; Your Website 2017
                        </div>
                    </div>
                </div>
            </div>
        </footer>

        <!-- Scroll to Top Button (Only visible on small and extra-small screen sizes) -->
        <div class="scroll-top d-lg-none">
            <a class="btn btn-primary js-scroll-trigger" href="#page-top">
                <i class="fa fa-chevron-up"></i>
            </a>
        </div>

        <!-- Portfolio Modals -->
        <div class="portfolio-modal modal fade" id="portfolioModal1" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="close-modal" data-dismiss="modal">
                        <div class="lr">
                            <div class="rl"></div>
                        </div>
                    </div>
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-8 mx-auto">
                                <div class="modal-body">
                                    <h2>Project Title</h2>
                                    <hr class="star-primary">
                                    <img class="img-fluid img-centered" src="img/portfolio/cabin.png" alt="">
                                    <p>
                                        Use this area of the page to describe your project. The icon above is part of a free icon set by
                                    <a href="https://sellfy.com/p/8Q9P/jV3VZ/">Flat Icons</a>. On their website, you can download their free set with 16 icons, or you can purchase the entire set with 146 icons for only $12!
                                    </p>
                                    <ul class="list-inline item-details">
                                        <li>Client:
                                        <strong>
                                            <a href="http://startbootstrap.com">Start Bootstrap</a>
                                        </strong>
                                        </li>
                                        <li>Date:
                                        <strong>
                                            <a href="http://startbootstrap.com">April 2014</a>
                                        </strong>
                                        </li>
                                        <li>Service:
                                        <strong>
                                            <a href="http://startbootstrap.com">Web Development</a>
                                        </strong>
                                        </li>
                                    </ul>
                                    <button class="btn btn-success" type="button" data-dismiss="modal">
                                        <i class="fa fa-times"></i>
                                        Close
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="portfolio-modal modal fade" id="portfolioModal2" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="close-modal" data-dismiss="modal">
                        <div class="lr">
                            <div class="rl"></div>
                        </div>
                    </div>
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-8 mx-auto">
                                <div class="modal-body">
                                    <h2>Project Title</h2>
                                    <hr class="star-primary">
                                    <img class="img-fluid img-centered" src="img/portfolio/cake.png" alt="">
                                    <p>
                                        Use this area of the page to describe your project. The icon above is part of a free icon set by
                                    <a href="https://sellfy.com/p/8Q9P/jV3VZ/">Flat Icons</a>. On their website, you can download their free set with 16 icons, or you can purchase the entire set with 146 icons for only $12!
                                    </p>
                                    <ul class="list-inline item-details">
                                        <li>Client:
                                        <strong>
                                            <a href="http://startbootstrap.com">Start Bootstrap</a>
                                        </strong>
                                        </li>
                                        <li>Date:
                                        <strong>
                                            <a href="http://startbootstrap.com">April 2014</a>
                                        </strong>
                                        </li>
                                        <li>Service:
                                        <strong>
                                            <a href="http://startbootstrap.com">Web Development</a>
                                        </strong>
                                        </li>
                                    </ul>
                                    <button class="btn btn-success" type="button" data-dismiss="modal">
                                        <i class="fa fa-times"></i>
                                        Close
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="portfolio-modal modal fade" id="portfolioModal3" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="close-modal" data-dismiss="modal">
                        <div class="lr">
                            <div class="rl"></div>
                        </div>
                    </div>
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-8 mx-auto">
                                <div class="modal-body">
                                    <h2>Project Title</h2>
                                    <hr class="star-primary">
                                    <img class="img-fluid img-centered" src="img/portfolio/circus.png" alt="">
                                    <p>
                                        Use this area of the page to describe your project. The icon above is part of a free icon set by
                                    <a href="https://sellfy.com/p/8Q9P/jV3VZ/">Flat Icons</a>. On their website, you can download their free set with 16 icons, or you can purchase the entire set with 146 icons for only $12!
                                    </p>
                                    <ul class="list-inline item-details">
                                        <li>Client:
                                        <strong>
                                            <a href="http://startbootstrap.com">Start Bootstrap</a>
                                        </strong>
                                        </li>
                                        <li>Date:
                                        <strong>
                                            <a href="http://startbootstrap.com">April 2014</a>
                                        </strong>
                                        </li>
                                        <li>Service:
                                        <strong>
                                            <a href="http://startbootstrap.com">Web Development</a>
                                        </strong>
                                        </li>
                                    </ul>
                                    <button class="btn btn-success" type="button" data-dismiss="modal">
                                        <i class="fa fa-times"></i>
                                        Close
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="portfolio-modal modal fade" id="portfolioModal4" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="close-modal" data-dismiss="modal">
                        <div class="lr">
                            <div class="rl"></div>
                        </div>
                    </div>
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-8 mx-auto">
                                <div class="modal-body">
                                    <h2>Project Title</h2>
                                    <hr class="star-primary">
                                    <img class="img-fluid img-centered" src="img/portfolio/game.png" alt="">
                                    <p>
                                        Use this area of the page to describe your project. The icon above is part of a free icon set by
                                    <a href="https://sellfy.com/p/8Q9P/jV3VZ/">Flat Icons</a>. On their website, you can download their free set with 16 icons, or you can purchase the entire set with 146 icons for only $12!
                                    </p>
                                    <ul class="list-inline item-details">
                                        <li>Client:
                                        <strong>
                                            <a href="http://startbootstrap.com">Start Bootstrap</a>
                                        </strong>
                                        </li>
                                        <li>Date:
                                        <strong>
                                            <a href="http://startbootstrap.com">April 2014</a>
                                        </strong>
                                        </li>
                                        <li>Service:
                                        <strong>
                                            <a href="http://startbootstrap.com">Web Development</a>
                                        </strong>
                                        </li>
                                    </ul>
                                    <button class="btn btn-success" type="button" data-dismiss="modal">
                                        <i class="fa fa-times"></i>
                                        Close
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="portfolio-modal modal fade" id="portfolioModal5" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="close-modal" data-dismiss="modal">
                        <div class="lr">
                            <div class="rl"></div>
                        </div>
                    </div>
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-8 mx-auto">
                                <div class="modal-body">
                                    <h2>Project Title</h2>
                                    <hr class="star-primary">
                                    <img class="img-fluid img-centered" src="img/portfolio/safe.png" alt="">
                                    <p>
                                        Use this area of the page to describe your project. The icon above is part of a free icon set by
                                    <a href="https://sellfy.com/p/8Q9P/jV3VZ/">Flat Icons</a>. On their website, you can download their free set with 16 icons, or you can purchase the entire set with 146 icons for only $12!
                                    </p>
                                    <ul class="list-inline item-details">
                                        <li>Client:
                                        <strong>
                                            <a href="http://startbootstrap.com">Start Bootstrap</a>
                                        </strong>
                                        </li>
                                        <li>Date:
                                        <strong>
                                            <a href="http://startbootstrap.com">April 2014</a>
                                        </strong>
                                        </li>
                                        <li>Service:
                                        <strong>
                                            <a href="http://startbootstrap.com">Web Development</a>
                                        </strong>
                                        </li>
                                    </ul>
                                    <button class="btn btn-success" type="button" data-dismiss="modal">
                                        <i class="fa fa-times"></i>
                                        Close
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="portfolio-modal modal fade" id="portfolioModal6" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="close-modal" data-dismiss="modal">
                        <div class="lr">
                            <div class="rl"></div>
                        </div>
                    </div>
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-8 mx-auto">
                                <div class="modal-body">
                                    <h2>Project Title</h2>
                                    <hr class="star-primary">
                                    <img class="img-fluid img-centered" src="img/portfolio/submarine.png" alt="">
                                    <p>
                                        Use this area of the page to describe your project. The icon above is part of a free icon set by
                                    <a href="https://sellfy.com/p/8Q9P/jV3VZ/">Flat Icons</a>. On their website, you can download their free set with 16 icons, or you can purchase the entire set with 146 icons for only $12!
                                    </p>
                                    <ul class="list-inline item-details">
                                        <li>Client:
                                        <strong>
                                            <a href="http://startbootstrap.com">Start Bootstrap</a>
                                        </strong>
                                        </li>
                                        <li>Date:
                                        <strong>
                                            <a href="http://startbootstrap.com">April 2014</a>
                                        </strong>
                                        </li>
                                        <li>Service:
                                        <strong>
                                            <a href="http://startbootstrap.com">Web Development</a>
                                        </strong>
                                        </li>
                                    </ul>
                                    <button class="btn btn-success" type="button" data-dismiss="modal">
                                        <i class="fa fa-times"></i>
                                        Close
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap core JavaScript -->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/popper/popper.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Contact Form JavaScript -->
    <script src="js/jqBootstrapValidation.js"></script>
    <script src="js/contact_me.js"></script>

    <!-- Custom scripts for this template -->
    <script src="js/freelancer.min.js"></script>

    <!-- Optional JavaScript plugins, jQuery, and Popper.js -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>

</body>

</html>

