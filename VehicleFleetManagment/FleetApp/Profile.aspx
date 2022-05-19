<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Page-header start -->
    <div class="page-header">
        <div class="page-block">
            <div class="row align-items-center">
                <div class="col-md-8">
                    <div class="page-header-title">
                       <asp:Label class="m-b-10 h5" ID="txtSystemTitle" runat="server" Text="" ></asp:Label>
                        <p><asp:Label class="m-b-0 p" ID="txtSlogan" runat="server" Text="" ></asp:Label></p>
                    </div>
                </div>
                <div class="col-md-4">
                    <ul class="breadcrumb-title">
                        <li class="breadcrumb-item">
                            <a href="Home.aspx"><i class="fa fa-home"></i></a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page-header end -->
    <div class="pcoded-inner-content">
        <!-- Main-body start -->
        <div class="main-body">
            <div class="page-wrapper">

                <!-- Page body start -->
                <div class="page-body">
                    <!--Start Main Card -->

                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <h5>User Profile</h5>
                            </div>
                            <div class="card-block d-flex">

                                <div class="col-md-5 ">
                                    <div class="form-group form-default">
                                        <label class="float-label">Name:  </label>
                                        <asp:Label ID="txtName" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </div>

                                    <div class="form-group form-default">
                                        <label class="float-label">Telephone: </label>
                                        <asp:Label ID="txtTel" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="form-group form-default">
                                        <label class="float-label">Address: </label>
                                        <asp:Label ID="txtAddress" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </div>

                                    <div class="form-group form-default">
                                        <label class="float-label">Fax : </label>
                                        <asp:Label ID="txtFax" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="form-group form-default">
                                        <label class="float-label">Postal Code:</label>
                                        <asp:Label ID="txtPostal" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="form-group form-default">
                                        <label class="float-label">Ministry Code :</label>
                                        <asp:Label ID="txtCode" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="form-group form-default">
                                        <label class="float-label">User Name :</label>
                                        <asp:Label ID="txtUserName" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>

                                <div class="col-md-7">
                                    <div class="form-group form-default ">
                                        <asp:Image ID="Image1" runat="server" Width="170px" Height="190px" BorderStyle="Solid" BorderWidth="1px" BorderColor="BlueViolet" AlternateText="No Picture"/>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <%-- <div class="col-md-6">
                                <div class="card">                                   
                                    <div class="card-block">
                                        <div class="form-material">
                                            
                                            <div class="form-group form-default">
                                            <asp:Image ID="Image1" runat="server" Width="170px" Height="190px" />
                                            </div>
                                           
                                        </div>


                                    </div>
                                </div>
                            </div>--%>
                    </div>

                </div>
                <!--End Main Card -->

                <!-- Page body end -->
            </div>
        </div>
        <!-- Main-body end -->
        <div id="styleSelector"></div>
    </div>


</asp:Content>
