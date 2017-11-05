<%@ Page Title="" Language="C#" MasterPageFile="~/Anonymous.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ASPWebsite.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        <asp:Label ID="lblWelcomeUser" runat="server" Text="Welcome User" Visible="False"></asp:Label>
                        <asp:HyperLink ID="LoginLink" class="nav-link" data-toggle="modal" Style="margin-right: 10px;" href="#Login" runat="server">Login</asp:HyperLink>
                        <%--<a class="nav-link" data-toggle="modal" style="margin-right: 10px;" href="#Login">Login</a>--%>
                    </li>
                    <li class="nav-item">
                        <asp:HyperLink ID="RegisterLink" class="nav-link" data-toggle="modal" href="#Sign" runat="server">Sign Up</asp:HyperLink>
                        <asp:HyperLink ID="SignOutLink" class="nav-link" data-toggle="modal" runat="server" Visible="False">Sign Out</asp:HyperLink>
                        <%--<a class="nav-link" data-toggle="modal" href="#Sign">Sign Up</a>--%>
                    </li>
                    <li>
                        <nav class="cd-stretchy-nav navbar-toggler-right" style="margin: 0; padding: 0px; border: 0; font-size: 100%; font: inherit; vertical-align: baseline; display: block;">
                            <a class="cd-nav-trigger" href="#0"><span aria-hidden="true"></span>
                            </a>

                            <ul>
                                <li><a href="#0" class="active"><span>Home</span></a></li>
                                <li><a href="#0"><span>Portfolio</span></a></li>
                                <li><a href="#0"><span>Services</span></a></li>
                                <li><a href="#0"><span>Store</span></a></li>
                                <li><a href="#0"><span>Contact</span></a></li>
                            </ul>

                            <span aria-hidden="true" class="stretchy-nav-bg"></span>
                        </nav>
                    </li>

                </ul>
            </div>
        </div>
    </nav>
    <nav>
        <asp:Label ID="Label9" runat="server" Text="Label">Hello</asp:Label>
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
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/scrolldown.gif" Width="30" />
                    </a>
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

                        <asp:Button ID="sendMessage" class="btn btn-success btn-lg" runat="server" Text="Submit" OnClick="sendMessage_Click" />
                        <br />


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
</asp:Content>
