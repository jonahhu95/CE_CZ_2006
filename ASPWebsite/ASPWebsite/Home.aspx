<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ASPWebsite.Home" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html lang="en">

<head id="head1" runat="server">

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


    <!-- Custom styles for this template -->
    <link href="css/freelancer.min.css" rel="stylesheet" />

    <style type="text/css">
        ::-webkit-scrollbar {
            display: none;
        }

        .validatestyle {
            font-size: 10px;
            font-family: sans-serif;
            color: red;
            font-style: italic;
        }

        .radiocss input[type="radio"] {
            margin-left: 10px;
            margin-right: 1px;
        }
    </style>
    <script>
        function openModal() {
            $('#Sign').modal({ show: true });
        }
        function openLoginModal() {
            $('#Login').modal({ show: true });
        }
    </script>

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
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="modal" style="margin-right: 10px;" href="#Login">Login</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="modal" href="#Sign">Sign Up</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <!-- Modal -->
        <div class="modal fade" id="Login" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Login</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="exampleInputEmail1" runat="server" Text="Email address"></asp:Label>
                        <asp:TextBox ID="tbEmail" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server"
                            ControlToValidate="tbEmail"
                            ErrorMessage="Email is required." CssClass="help-block text-danger" Font-Size="12px" ValidationGroup="group1"> Email is required
                        </asp:RequiredFieldValidator>

                        <br />
                        <asp:Label ID="exampleInputPassword1" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="tbPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server"
                            ControlToValidate="tbPassword"
                            ErrorMessage="Password is required." CssClass="help-block text-danger" Font-Size="12px" ValidationGroup="group1"> Password is required
                        </asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lblLoginWarning" runat="server"></asp:Label><br />
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="loginBtn" class="btn btn-primary" runat="server" Text="Login" OnClick="loginBtn_Click1" ValidationGroup="group1" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="Sign" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Register</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="Label1" runat="server" Text="Email address"></asp:Label>
                        <asp:TextBox ID="tbEmail2" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server"
                            ControlToValidate="tbEmail2"
                            ErrorMessage="Email is required." CssClass="help-block text-danger" Font-Size="12px" ValidationGroup="group2"> Email is required
                        </asp:RequiredFieldValidator>

                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="tbPassword2" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server"
                            ControlToValidate="tbPassword2"
                            ErrorMessage="Password is required." CssClass="help-block text-danger" Font-Size="12px" ValidationGroup="group2"> Password is required
                        </asp:RequiredFieldValidator>

                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
                        <asp:TextBox ID="tbConfirmPW" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server"
                            ControlToValidate="tbConfirmPW"
                            ErrorMessage="Confirm password is required." CssClass="help-block text-danger" Font-Size="12px" ValidationGroup="group2"> Please enter confirm password
                        </asp:RequiredFieldValidator><br />

                        <asp:Label ID="LabelWarning" runat="server"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <%--<asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Login" OnClick="loginBtn_Click1" />--%>
                        <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Confirm" OnClick="Button1_Click" ValidationGroup="group2" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>




        <%--<img src="img/scrolldown.gif" style="position: fixed; bottom: 20px; height: 50px; width: 50px; right: 20px; background-color: black; opacity: 0.7; border-radius: 50%; border: 3px solid white;"></img>--%>
        <!-- Header -->
        <header class="masthead">
            <div class="container">
                <div class="intro-text">
                </div>
                <img class="img-fluid" src="img/landing.png" alt="" height="300" width="300">
                <div class="intro-text">
                    <span class="name" style="font-size: 50px;">Is the job worth it?</span>
                    <h1 style="font-size: 20px;">Based on your Job Interest, Salary & Commute</h1>
                    <hr class="star-light">
                    <span class="skills">Find your answers here!</span><br />
                    <br />
                    <%--<a class="btn btn-primary js-scroll-trigger" href="#desc">Find out more</a>--%>
                    <%--<a class="btn btn-primary js-scroll-trigger" href="#JSI">Calculate Job Satisfaction Index</a>--%>
                    <div style="margin-top: 50px; margin-bottom: -70px;">
                        <a href="#JSI" class="js-scroll-trigger">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/scrolldown.gif" Width="30" /></a>
                    </div>


                </div>
            </div>
        </header>

        <section id="JSI">
            <div class="container">
                <h2 class="text-center">Calculate Job Satisfaction Index</h2>
                <hr class="star-primary">
                <div class="row">
                    <div class="col-lg-8 mx-auto">
                        <div id="success"></div>
                        <div class="form-group">
                            <label>
                                <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false&libraries=places&key=AIzaSyC7PqtJwkmY1fKaO0RE3qj7JWhA7m36jfk"></script>
                                <script type="text/javascript">
                                    var source, destination;

                                    var directionsService = new google.maps.DirectionsService();
                                    google.maps.event.addDomListener(window, 'load', function () {
                                        new google.maps.places.SearchBox(document.getElementById('txt_Source'));
                                        new google.maps.places.SearchBox(document.getElementById('txt_Destination'));


                                    });

                                    function getdistance() {
                                        source = document.getElementById("txt_Source").value;
                                        destination = document.getElementById("txt_Destination").value;
                                        var service = new google.maps.DistanceMatrixService();
                                        service.getDistanceMatrix({
                                            origins: [source],
                                            destinations: [destination],
                                            travelMode: google.maps.TravelMode.DRIVING,
                                            unitSystem: google.maps.UnitSystem.METRIC,
                                            avoidHighways: false,
                                            avoidTolls: false
                                        }, function (response, status) {
                                            if (status == google.maps.DistanceMatrixStatus.OK && response.rows[0].elements[0].status != "ZERO_RESULTS") {
                                                var distance = response.rows[0].elements[0].distance.text;
                                                // var duration = response.rows[0].elements[0].duration.text;  
                                                var lbl_distance = "Distance: " + distance;
                                                document.getElementById('lbl_distance').innerHTML = lbl_distance;


                                            }
                                            else {
                                                alert("Unable to calculate distance.");
                                            }
                                        });
                                    }
                                </script>
                                <asp:Label ID="Label4" runat="server" Text="Home Location"></asp:Label></label>
                            <asp:TextBox ID="txt_Source" class="form-control" runat="server"></asp:TextBox><br />

                            <label>
                                <asp:Label ID="Label5" runat="server" Text="Job Location"></asp:Label></label>
                            <asp:TextBox ID="txt_Destination" class="form-control" runat="server"></asp:TextBox><br />

                            <label>
                                <asp:Label ID="Label6" runat="server" Text="Salary"></asp:Label></label>
                            <asp:TextBox ID="txt_Salary" class="form-control" runat="server"></asp:TextBox><br />

                            <asp:Label ID="Label7" runat="server" Text="Salary Satisfaction Rating "></asp:Label>
                            <asp:RadioButtonList ID="rbSalary" runat="server" RepeatDirection="Horizontal" CssClass="radiocss">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />

                            <asp:Label ID="Label8" runat="server" Text="Job Interest Rating "></asp:Label>
                            <asp:RadioButtonList ID="rbInterest" runat="server" RepeatDirection="Horizontal" CssClass="radiocss">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                            </asp:RadioButtonList><br />

                            <asp:Button ID="sendMessage" class="btn btn-success btn-lg" runat="server" Text="Submit" OnClick="sendMessage_Click" /><br />


                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- About Section -->
        <section class="success" id="desc">
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
                                        <img src="img/time.png" class="round" />
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
                                        <img src="img/dist.png" class="round" />
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
                                        <img src="img/sal.png" class="round" />
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
                                        <img src="img/thumbs.png" class="round" />
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
        <%--        <footer class="text-center">
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
        </div>--%>
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
</body>

</html>

