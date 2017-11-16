<%@ Page Title="" Language="C#" MasterPageFile="~/Anonymous.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ASPWebsite.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .radiocss td {
            /*display: inline-block;
                                width: 200px;
                                padding: 10px;
                                border: solid 2px #ccc;
                                transition: all 0.3s;*/
        }
        .radiocss td input[type="radio"]:checked {
            visibility: hidden;
        }
        .radiocss td input[type="radio"] {
            visibility: hidden;
        }

        .radiocss td input[type="radio"] {
            /*display: none;*/
            -webkit-appearance: none;
            -moz-appearance: none;
            -ms-appearance: none;
            -o-appearance: none;
            display: none;
            position: relative;
            top: 13.33333px;
            right: 0;
            bottom: 0;
            left: 0;
            height: 40px;
            width: 40px;
            transition: all 0.15s ease-out 0s;
            /*background: #cbd1d8;*/
            border: none;
            /*color: #fff;*/
            cursor: pointer;
            display: inline-block;
            margin-right: 0.5rem;
            outline: none;
            position: relative;
            z-index: 1000;
        }

            .radiocss td input[type="radio"]:checked + label {
                font-weight: bolder;
                border: 2px solid black;
                padding: 10px;
                border-radius: 50%;
            }

        .radiocss td label {
            position: relative;
            left: -13px;
            top: -3px;
            font-size: 10pt;
            opacity: .5;
            color: black;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("[id$='rbSalary']").css("-webkit-appearance", "none");
        });

        var source, destination;
        var options = {
            componentRestrictions: { country: 'sg' }
        };
        var directionsService = new google.maps.DirectionsService();
        google.maps.event.addDomListener(window, 'load', function () {
            new google.maps.places.Autocomplete(document.getElementById('txt_Source'), options);
            new google.maps.places.Autocomplete(document.getElementById('txt_Destination'), options);


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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            <asp:Label ID="Label4" runat="server" Text="Home Location"></asp:Label></label>
                        <asp:TextBox ID="txt_Source" class="form-control" runat="server" ClientIDMode="Static" Text=""></asp:TextBox><br />

                        <label>
                            <asp:Label ID="Label5" runat="server" Text="Job Location"></asp:Label></label>
                        <asp:TextBox ID="txt_Destination" class="form-control" runat="server" ClientIDMode="Static" Text=""></asp:TextBox><br />

                        <label>
                            <asp:Label ID="Label6" runat="server" Text="Salary"></asp:Label></label>
                        <asp:TextBox ID="txt_Salary" class="form-control" runat="server"></asp:TextBox><br />

                        <asp:Label ID="Label7" runat="server" Text="Salary Satisfaction Rating "></asp:Label>
                        <asp:RadioButtonList ID="rbSalary" runat="server" RepeatDirection="Horizontal" CssClass="radiocss">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem Selected="True">5</asp:ListItem>
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
                            <asp:ListItem Selected="True">5</asp:ListItem>
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
