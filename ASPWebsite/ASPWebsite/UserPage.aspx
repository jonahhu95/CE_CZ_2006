<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="ASPWebsite.UserPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <nav class="navbar navbar-expand-lg navbar-light fixed-top" id="mainNav">
                <div class="container">
                    <a class="navbar-brand js-scroll-trigger" href="#page-top">3° Burn</a>
                    <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                        Menu
          <i class="fa fa-bars"></i>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarResponsive">
                        <ul class="navbar-nav ml-auto">
                            <%-- <li class="nav-item">
              <a class="nav-link js-scroll-trigger" href="#about">About</a>
            </li>
            <li class="nav-item">
              <a class="nav-link js-scroll-trigger" href="#contact">Contact</a>
            </li>--%>
                        </ul>
                    </div>
                </div>
            </nav>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style>
        * {
            margin: 0;
            padding: 0;
        }

        .clear {
            clear: both;
        }


        .slide-toggle {
            display: none;
        }

        .slidemenu {
            font-family: arial, sans-serif;
            max-width: 600px;
            margin: 50px auto;
            overflow: hidden;
        }

            .slidemenu label {
                width: 25%;
                text-align: center;
                display: block;
                float: left;
                color: #333;
                opacity: 0.2;
            }

                .slidemenu label:hover {
                    cursor: pointer;
                    color: #666;
                }

                .slidemenu label span {
                    display: block;
                    padding: 10px;
                }

                .slidemenu label .icon {
                    font-size: 20px;
                    border: solid 2px #333;
                    text-align: center;
                    height: 50px;
                    width: 50px;
                    display: block;
                    margin: 0 auto;
                    line-height: 50px;
                    border-radius: 50%;
                }

        /*Bar Style*/

        .slider {
            width: 100%;
            height: 5px;
            display: block;
            background: #ccc;
            margin-top: 10px;
            border-radius: 5px;
        }

            .slider .bar {
                width: 25%;
                height: 5px;
                background: #333;
                border-radius: 5px;
            }

            /*Animations*/
            .slidemenu label, .slider .bar {
                transition: all 500ms ease-in-out;
                -webkit-transition: all 500ms ease-in-out;
                -moz-transition: all 500ms ease-in-out;
            }

        /*Toggle*/

        .slidemenu .slide-toggle:checked + label {
            opacity: 1;
        }



        .slidemenu #slide-item-1:checked ~ .slider .bar {
            margin-left: 0;
        }

        .slidemenu #slide-item-2:checked ~ .slider .bar {
            margin-left: 25%;
        }

        .slidemenu #slide-item-3:checked ~ .slider .bar {
            margin-left: 50%;
        }

        .slidemenu #slide-item-4:checked ~ .slider .bar {
            margin-left: 75%;
        }
    </style>
    <nav class="slidemenu">

        <!-- Item 1 -->
        <input type="radio" name="slideItem" id="slide-item-1" class="slide-toggle" checked />
        <label for="slide-item-1">
            <p class="icon">♬</p>
            <span>Home</span></label>

        <!-- Item 2 -->
        <input type="radio" name="slideItem" id="slide-item-2" class="slide-toggle" />
        <label for="slide-item-2">
            <p class="icon">★</p>
            <span>View Past Records</span></label>

        <!-- Item 3 -->
        <input type="radio" name="slideItem" id="slide-item-3" class="slide-toggle" />
        <label for="slide-item-3">
            <p class="icon">✈</p>
            <span>Provide Feedback</span></label>

        <!-- Item 4 -->
        <input type="radio" name="slideItem" id="slide-item-4" class="slide-toggle" />
        <label for="slide-item-4">
            <p class="icon">✎</p>
            <span>Contact</span></label>

        <div class="clear"></div>

        <!-- Bar -->
        <div class="slider">
            <div class="bar"></div>
        </div>

    </nav>
    <h1 style="font-size: 20px; font-family: 'ADAM.CG PRO'; text-transform: none !important; ">Welcome
        <asp:Label ID="lblUsername" runat="server"></asp:Label></h1>
    <br />

</asp:Content>
