<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page-header start -->
    <div class="page-header">
        <div class="page-block">
            <div class="row align-items-center">
                <div class="col-md-8">
                    <div class="page-header-title">
                        <asp:Label class="m-b-10 h5" ID="txtSystemTitle" runat="server" Text=""></asp:Label>
                        <p>
                            <asp:Label class="m-b-0 p" ID="txtSlogan" runat="server" Text=""></asp:Label></p>
                    </div>
                </div>
                <div class="col-md-4">
                    <ul class="breadcrumb-title">
                        <li class="breadcrumb-item">
                            <a href="index.html"><i class="fa fa-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="#!">Dashboard</a>
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
                <!-- Page-body start -->
                <div class="page-body">
                    <div class="row">
                        <!-- task, page, download counter  start -->
                        <div class="col-xl-3 col-md-6">
                            <div class="card">
                                <div class="card-block">
                                    <div class="row align-items-center">
                                        <div class="col-8">
                                            <asp:Label class="text-c-purple h4" ID="driverNumber" runat="server" Text=""></asp:Label>
                                            <h6 class="text-muted m-b-0">Drivers</h6>
                                        </div>
                                        <div class="col-4 text-right">
                                            <i class="fa fa-users f-28"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer bg-c-blue">
                                    <div class="row align-items-center">
                                        <div class="col-9">
                                            <p class="text-white m-b-0">All Drivers</p>
                                        </div>
                                        <div class="col-3 text-right">
                                            <i class="fa fa-line-chart text-white f-16"></i>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="col-xl-3 col-md-6">
                            <div class="card">
                                <div class="card-block">
                                    <div class="row align-items-center">
                                        <div class="col-8">
                                            <asp:Label class="text-c-orenge h4" ID="ActiveLeave" runat="server" Text=""></asp:Label>
                                            <h6 class="text-muted m-b-0">Leaves</h6>
                                        </div>
                                        <div class="col-4 text-right">
                                            <i class="fa fa-male f-28"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer bg-c-orenge">
                                    <div class="row align-items-center">
                                        <div class="col-9">
                                            <p class="text-white m-b-0">The actives Leaves</p>
                                        </div>
                                        <div class="col-3 text-right">
                                            <i class="fa fa-line-chart text-white f-16"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-3 col-md-6">
                            <div class="card">
                                <div class="card-block">
                                    <div class="row align-items-center">
                                        <div class="col-8">
                                            <asp:Label class="text-c-purple h4" ID="VehicleNumber" runat="server" Text=""></asp:Label>
                                            <h6 class="text-muted m-b-0">Vehicles</h6>
                                        </div>
                                        <div class="col-4 text-right">
                                            <i class="fa fa-bus f-28"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer bg-c-purple">
                                    <div class="row align-items-center">
                                        <div class="col-9">
                                            <p class="text-white m-b-0">all actives vehicles</p>
                                        </div>
                                        <div class="col-3 text-right">
                                            <i class="fa fa-line-chart text-white f-16"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-3 col-md-6">
                            <div class="card">
                                <div class="card-block">
                                    <div class="row align-items-center">
                                        <div class="col-8">
                                            <asp:Label class="text-c-lite-green h4" ID="CrashNumber" runat="server" Text=""></asp:Label>
                                            <h6 class="text-muted m-b-0">Crashes</h6>
                                        </div>
                                        <div class="col-4 text-right">
                                            <i class="fa fa-fighter-jet f-28"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer bg-c-lite-green">
                                    <div class="row align-items-center">
                                        <div class="col-9">
                                            <p class="text-white m-b-0">Crash</p>
                                        </div>
                                        <div class="col-3 text-right">
                                            <i class="fa fa-line-chart text-white f-16"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- task, page, download counter  end -->

                        <!--  sale analytics start -->
                        <div class="col-xl-8 col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h5>Leave Analytics</h5>
                                    <span class="text-muted">Statistics of leaves per month</span>
                                    <div class="card-header-right">
                                        <ul class="list-unstyled card-option">
                                            <li><i class="fa fa fa-wrench open-card-option"></i></li>
                                            <li><i class="fa fa-window-maximize full-card"></i></li>
                                            <li><i class="fa fa-minus minimize-card"></i></li>
                                            <li><i class="fa fa-refresh reload-card"></i></li>
                                            <li><i class="fa fa-trash close-card"></i></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="card-block">
                                    <div id="sales-analytics" style="height: 400px;"></div>
                                </div>
                            </div>
                        </div>

                        <!--  Vehicle & driver start -->
                        <div class="col-xl-4 col-md-12">

                            <!--  Vehicle Start  -->
                            <div class="card table-card">
                                <div class="card-header">
                                    <h5>Vehicle</h5>                                 
                                </div>
                                <div class="card-block ml-3">
                                    <div class="row mb-4 mt-3">
                                        <div class="col">
                                            <div>Available</div>
                                        </div>
                                        <div class="col-auto">
                                            <asp:Label class="label label-success mr-5" Text="" ID="countVehAvail" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col">
                                            <div>Unavailable</div>
                                        </div>
                                        <div class="col-auto">
                                            <asp:Label class="label label-danger mr-5" Text="" ID="countVehUnvail" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--  Vehicle end -->
                            <!--  Driver start -->
                            <div class="card table-card">
                                <div class="card-header">
                                    <h5>Drivers</h5>                                 
                                </div>
                                <div class="card-block ml-3">
                                    <div class="row mb-4 mt-3">
                                        <div class="col">
                                            <div>On Post</div>
                                        </div>
                                        <div class="col-auto">
                                            <asp:Label class="label label-success mr-5" Text="" ID="countDriverOnPost" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col">
                                            <div>Leave</div>
                                        </div>
                                        <div class="col-auto">
                                            <asp:Label class="label label-danger mr-5" Text="" ID="countDrivLeave" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                             <!--  Driver end -->

                            <!--  Maintenance start -->
                            <div class="card table-card">
                                <div class="card-header">
                                    <h5>Leave notification</h5>                                 
                                </div>
                                <div class="card-block ml-3">
                                    <div class="row mb-3 mt-3">
                                        <div class="col">
                                            <div>Pending</div>
                                        </div>
                                        <div class="col-auto">
                                            <asp:Label class="label label-info mr-5" Text="" ID="countLeavePending" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row mb-3">
                                        <div class="col">
                                            <div>Due soon</div>
                                        </div>
                                        <div class="col-auto">
                                            <asp:Label class="label label-primary mr-5" Text="" ID="countLeaveDueSoon" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row ">
                                        <div class="col">
                                            <div>Soon finish</div>
                                        </div>
                                        <div class="col-auto">
                                           <asp:Label class="label label-danger mr-5" Text="0" ID="countLeaveSoonFinish" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                             <!--  Maintenance end -->
                        </div>
                        <!-- Maintenance & Vehicle & driver end -->

                        <!--  Crash line chart start -->
                        <div class="col-xl-8 col-md-12">
                            <div class="card table-card">
                                <div class="card-header">
                                    <h5>Crash line chart</h5>
                                    <div class="card-header-right">
                                        <ul class="list-unstyled card-option">
                                            <li><i class="fa fa fa-wrench open-card-option"></i></li>
                                            <li><i class="fa fa-window-maximize full-card"></i></li>
                                            <li><i class="fa fa-minus minimize-card"></i></li>
                                            <li><i class="fa fa-refresh reload-card"></i></li>
                                            <li><i class="fa fa-trash close-card"></i></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="card-block">
                                    <div id="line-example"></div>
                                </div>
                            </div>
                        </div>
                        <!--  Crash line chart end -->

                        <!--  Driver employees start -->
                        <div class="col-xl-4 col-md-12">
                            <div class="card ">
                                <div class="card-header">
                                    <h5>Employees</h5>
                                    <div class="card-header-right">
                                        <ul class="list-unstyled card-option">
                                            <li><i class="fa fa fa-wrench open-card-option"></i></li>
                                            <li><i class="fa fa-window-maximize full-card"></i></li>
                                            <li><i class="fa fa-minus minimize-card"></i></li>
                                            <li><i class="fa fa-refresh reload-card"></i></li>
                                            <li><i class="fa fa-trash close-card"></i></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="card-block">

                                    <asp:ListView ID="ListView1" runat="server" >
                                        <ItemTemplate>                                          
                                            <div class="align-middle m-b-30">
                                                 <asp:Image ID="Image2" class="img-radius img-40 align-top m-r-15" runat="server"  ImageUrl='<%# string.Concat("~/FleetApp/assets/images/Drivers/",Eval("Picture")) %>' />
                                                <div class="d-inline-block">
                                                    <h6><%# Eval("Full_Name") %></h6>
                                                    <p class="text-muted m-b-0">Phone: <%# Eval("Personnal_Phone") %></p>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                    <div class="text-center">
                                        <a href="ViewMinistryDriver.aspx" class="b-b-primary text-primary">View all Drivers</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--  Driver employees end  -->
                    </div>
                </div>
                <!-- Page-body end -->
            </div>
            <div id="styleSelector"></div>
        </div>
    </div>
</asp:Content>
