<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #chartdiv1 {
            width: 100%;
            height: 400px;
        }
    </style>
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
                <%--<div class="col-md-4">
                    <ul class="breadcrumb-title">
                        <li class="breadcrumb-item">
                            <a href="index.html"><i class="fa fa-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="#!">Dashboard</a>
                        </li>
                    </ul>
                </div>--%>
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

                        <!--  Leave donut chart start -->
                        <div class="col-xl-8 col-md-12 col-sm-4">
                            <div class="card ">
                                <div class="card-header">
                                    <h5>Leave Statistics and Analytics</h5>
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
                                <div class="card-block tab-icon">                                                                                                        
                                    <!-- Nav tabs -->
                                    <ul class="nav nav-tabs md-tabs " role="tablist">
                                        <li class="nav-item">
                                            <a class="nav-link active" role="tab" runat="server" id="tabAnalysis" onserverclick="ActiveAnalys_click"><i class="icofont icofont-ui-settings"></i>Leave analysis with Donut Pie</a>
                                            <div class="slide"></div>
                                        </li>

                                        <li class="nav-item">
                                            <a class="nav-link " role="tab" runat="server" id="tabStat" onserverclick="ActiveStat_click"><i class="icofont icofont-home"></i>Leave Statistic table</a>
                                            <div class="slide"></div>
                                        </li>
                                                                                
                                    </ul>
                                    <!-- Tab panes -->
                                    <div class="tab-content card-block">
                                        <!-- MULTIVIEW  -->
                                        <asp:MultiView ID="MultiView" runat="server">

                                             <!--  Analysis Tab  -->
                                            <asp:View ID="ViewAnalysis" runat="server">
                                                <div class="row card-block">

                                                    <div  id="chartdiv" class="" ></div>  

                                                </div>

                                            </asp:View>
                                            <!-- Analysis Tab  -->

                                            <!--Statistics  info Tab  -->
                                            <asp:View ID="ViewStatistic" runat="server">
                                                <div class="row card-block">
                                                    <div class="table">
                                                        <asp:GridView ID="gdv" ShowHeaderWhenEmpty="true" EmptyDataText="No Records" 
                                                            class="table  table-striped  table-borderless  " HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                                            AutoGenerateColumns="false" EmptyDataRowStyle-Font-Size="X-Large"
                                                            GridLines="None" EmptyDataRowStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#448aff" HeaderStyle-ForeColor="White"
                                                            runat="server" Width="100%">

                                                            <Columns>

                                                                <asp:TemplateField HeaderText="Month">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label98" runat="server" Text='<%# Eval("Start_Dte") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Number">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="LblState" runat="server" Text='<%# Eval("count") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>

                                                        <div> <span runat="server" class="font-weight-bold mr-1">Total Number: </span> <asp:Label runat="server" Text="" ID="totalFinishedLeave" class="txt-muted"></asp:Label></div>
                                                    </div>
                                                    
                                                </div>
                                                
                                            </asp:View>
                                            <!-- end Statistics Tab  -->
                                          
                                           
                                        </asp:MultiView>
                                        <!-- END MULTIVIEW  -->
                                    </div>

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

                                <div class="card-block tab-icon">                                                                                                        
                                    <!-- Nav tabs -->
                                    <ul class="nav nav-tabs md-tabs " role="tablist">
                                        <li class="nav-item">
                                            <a class="nav-link active" role="tab" runat="server" id="tabCrashAnaly" onserverclick="ActiveCrashAnalys_click"><i class="icofont icofont-ui-settings"></i>Crash analysis with Donut Pie</a>
                                            <div class="slide"></div>
                                        </li>

                                        <li class="nav-item">
                                            <a class="nav-link " role="tab" runat="server" id="tabCrashStat" onserverclick="ActiveCrashStat_click"><i class="icofont icofont-home"></i>Crash Statistic table</a>
                                            <div class="slide"></div>
                                        </li>
                                                                                
                                    </ul>
                                    <!-- Tab panes -->
                                    <div class="tab-content card-block">
                                        <!-- MULTIVIEW  -->
                                        <asp:MultiView ID="MultiView1" runat="server">

                                             <!--  Analysis Tab  -->
                                            <asp:View ID="View1" runat="server">
                                                <div class="row card-block">

                                                    <div  id="chartdiv1" class="" ></div>  

                                                </div>

                                            </asp:View>
                                            <!-- Analysis Tab  -->

                                            <!--Statistics  info Tab  -->
                                            <asp:View ID="View2" runat="server">
                                                <div class=" card-block">
                                                    <div class="table">
                                                        <asp:GridView ID="gdvCrash" ShowHeaderWhenEmpty="true" EmptyDataText="No Records" 
                                                            class="table  table-striped  table-borderless  " HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                                            AutoGenerateColumns="false" EmptyDataRowStyle-Font-Size="X-Large"
                                                            GridLines="None" EmptyDataRowStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#448aff" HeaderStyle-ForeColor="White"
                                                            runat="server" Width="100%">

                                                            <Columns>

                                                                <asp:TemplateField HeaderText="Month">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label98" runat="server" Text='<%# Eval("Crash_Date") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Number">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="LblState" runat="server" Text='<%# Eval("count") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>

                                                        <div> <span runat="server" class="font-weight-bold mr-1">Total Number: </span> <asp:Label runat="server" Text="" ID="TotalNumberCrash" class="txt-muted"></asp:Label></div>
                                                    </div>
                                                    
                                                </div>
                                                
                                            </asp:View>
                                            <!-- end Statistics Tab  -->
                                          
                                           
                                        </asp:MultiView>
                                        <!-- END MULTIVIEW  -->
                                    </div>

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


     <!-- Donut chart js file -->
    <script src="https://localhost:44339/FleetApp/assets/js/Donut-Chart/index.js"></script>
    <script src="https://localhost:44339/FleetApp/assets/js/Donut-Chart/percent.js"></script>
    <script src="https://localhost:44339/FleetApp/assets/js/Donut-Chart/Animated.js"></script>

      <%-- Donut chart js code for Crash Analyse   --%>
    <script>
        am5.ready(function () {

            // Create root element
            // https://www.amcharts.com/docs/v5/getting-started/#Root_element
            var root = am5.Root.new("chartdiv1");


            // Set themes
            // https://www.amcharts.com/docs/v5/concepts/themes/
            root.setThemes([
                am5themes_Animated.new(root)
            ]);


            // Create chart
            // https://www.amcharts.com/docs/v5/charts/percent-charts/pie-chart/
            var chart = root.container.children.push(am5percent.PieChart.new(root, {
                layout: root.verticalLayout,
                innerRadius: am5.percent(50)
            }));


            // Create series
            // https://www.amcharts.com/docs/v5/charts/percent-charts/pie-chart/#Series
            var series = chart.series.push(am5percent.PieSeries.new(root, {
                valueField: "count",
                categoryField: "Crash_Date",
                alignLabels: false
            }));

            series.labels.template.setAll({
                textType: "circular",
                centerX: 0,
                centerY: 0
            });


            // Set data
            // https://www.amcharts.com/docs/v5/charts/percent-charts/pie-chart/#Setting_data
            series.data.setAll(<%= CrashAnalys %>);


            // Create legend
            // https://www.amcharts.com/docs/v5/charts/percent-charts/legend-percent-series/
            var legend = chart.children.push(am5.Legend.new(root, {
                centerX: am5.percent(50),
                x: am5.percent(50),
                marginTop: 15,
                marginBottom: 15,
            }));

            legend.data.setAll(series.dataItems);


            // Play initial series animation
            // https://www.amcharts.com/docs/v5/concepts/animations/#Animation_of_series
            series.appear(1000, 100);

        }); // end am5.ready()
    </script>
<!-- HTML -->
</asp:Content>
