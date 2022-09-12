<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="AllMinistries.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.AllMinistries" %>
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
                    <div class="form-material">
                            <div class="form-group form-default" id="DMinistry" runat="server">
                                <asp:DropDownList class="form-control font-weight-bold" name="footer-email" Style="width: 100%;" OnSelectedIndexChanged="dropDown_Ministry_SelectedIndexChanged" AutoPostBack="true" ID="DropDown_Ministry" required="" runat="server"></asp:DropDownList>
                                <label class="float-label">Ministry</label>
                            </div>
                        </div>
                    <div class="row">
                        
                        <!--  counter  start -->
                      
                        <div class="col-xl-4 col-md-6">
                            <div class="card">
                                <div class="card-block">
                                    <div class="row align-items-center">
                                        <div class="col-8">
                                            <asp:Label class="text-c-orenge h4" ID="RealEstateNumber" runat="server" Text=""></asp:Label>
                                            <h6 class="text-muted m-b-0">Real Estate</h6>
                                        </div>
                                        <div class="col-4 text-right">
                                            <i class="fa fa-table f-28"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer bg-c-blue">
                                    <div class="row align-items-center">
                                        <div class="col-9">
                                            <p class="text-white m-b-0">Total number of Real Estate they have</p>
                                        </div>
                                        <div class="col-3 text-right">
                                            <i class="fa fa-line-chart text-white f-16"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-4 col-md-6">
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
                                <div class="card-footer bg-c-blue">
                                    <div class="row align-items-center">
                                        <div class="col-9">
                                            <p class="text-white m-b-0">Total number of vehicles they have</p>
                                        </div>
                                        <div class="col-3 text-right">
                                            <i class="fa fa-line-chart text-white f-16"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-4 col-md-6">
                            <div class="card">
                                <div class="card-block">
                                    <div class="row align-items-center">
                                        <div class="col-8">
                                            <asp:Label class="text-c-lite-green h4" ID="CrashNumber" runat="server" Text=""></asp:Label>
                                            <h6 class="text-muted m-b-0">Crashes</h6>
                                        </div>
                                        <div class="col-4 text-right">
                                            <i class="fa fa-warning f-28"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer bg-c-blue">
                                    <div class="row align-items-center">
                                        <div class="col-9">
                                            <p class="text-white m-b-0 text-dribbble">Total number of Crashes acquired</p>
                                        </div>
                                        <div class="col-3 text-right">
                                            <i class="fa fa-line-chart text-white f-16"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- counter  end -->

                        

                        <!--  Vehicle start -->
                        <div class="col-xl-12 col-md-12 col-sm-4">
                            <div class="text-center font-weight-bold">Vehicles</div>
                            <div class="card ">
                                <div class="card-header">
                                    <h5>Vehicles</h5>
                                    <span class="text-muted">The vehicle that ownes by this ministry</span>
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
                                <div class="card-block ">                                                                                                        
                                  
                                    <table class="table-responsive">
                                    <asp:GridView ID="gdv" DataKeyNames="VEHICLE_ID" ShowHeaderWhenEmpty="true" EmptyDataText="No Records" HeaderStyle-HorizontalAlign="Center"
                                        class="table  table-striped  table-borderless text-center " HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                        AutoGenerateColumns="false" EmptyDataRowStyle-Font-Size="X-Large" AllowPaging="true" PageSize="10" OnPreRender="gdv_PreRender"
                                        GridLines="None" EmptyDataRowStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#448aff" HeaderStyle-ForeColor="White"
                                        runat="server" Width="100%"  OnPageIndexChanging="gdv_PageIndexChanging">

                                        <Columns>
<%--                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkSelHeader" runat="server" Text="Select All" AutoPostBack="true" OnCheckedChanged="checkSelHeader_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="checkSel" runat="server" OnCheckedChanged="checkSel_CheckedChanged" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                             <asp:BoundField DataField="VEHICLE_ID" HeaderText="#" Visible="false" />
                                           
                                            <asp:TemplateField HeaderText="Vehicle Code " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Veh_Code ") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Name" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("NameVeh ") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Body">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("BODY_ID ") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Plate" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Local_Plate ") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Model & Mark">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("MODEL_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                         
                                            
                                            <asp:TemplateField HeaderText="Color " Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("Color ") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Condition " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("Condition ") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Chassis Num">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("Chassis_Num") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Engine Num" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("Engine_Num") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Engine Manufacturer " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("Engine_Manufacturer") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Engine Type" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("Engine_Type") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Alternator Engine Manufacturer " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("Alternator_Engine_Manufacturer") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Alternator Engine Type " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("Alternator_Engine_Type ") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Kva " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("Kva ") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Volt" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lab" runat="server" Text='<%# Eval("Volt") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Generato Weight " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="gen" runat="server" Text='<%# Eval("Generator_Weight") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Trailer " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="tra" runat="server" Text='<%# Eval("Trailer") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Assembly Num" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="ass" runat="server" Text='<%# Eval("Assembly_Num") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="lhd or rhd " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="rhd" runat="server" Text='<%# Eval("lhd_rhd") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Safety_Belt" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="saf" runat="server" Text='<%# Eval("Safety_Belt") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gearbox_Type" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="gea" runat="server" Text='<%# Eval("Gearbox_Type") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Opt Four Wheel " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="opt" runat="server" Text='<%# Eval("Opt_Four_Wheel") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Central Locking " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="locking" runat="server" Text='<%# Eval("Central_Locking") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Rear Lock " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="rear" runat="server" Text='<%# Eval("Rear_Lock") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Engine Series Num " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="series" runat="server" Text='<%# Eval("Engine_Series_Num") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Forward Lock" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lock" runat="server" Text='<%# Eval("Forward_Lock") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Engine cylinder Number" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="cyllndr" runat="server" Text='<%# Eval("Engine_cylinder_Number") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Engine cc" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="cc" runat="server" Text='<%# Eval("Engine_cc") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Engine Power " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("Engine_Power") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Fuel Fype " >
                                                <ItemTemplate>
                                                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("Fuel_Fype ") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Tank Type 1 ">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label31" runat="server" Text='<%# Eval("Tank_Type1") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tank Size 1 " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label51" runat="server" Text='<%# Eval("Tank_Size1") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tank Type 2" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label62" runat="server" Text='<%# Eval("Tank_Type2") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tank Capacity 2 " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label71" runat="server" Text='<%# Eval("Tank_Capacity2") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Front Seats Number" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label83" runat="server" Text='<%# Eval("Front_Seats_Number") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Battery Voltage " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label91" runat="server" Text='<%# Eval("Battery_Voltage") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Air Conditioner" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label101" runat="server" Text='<%# Eval("Air_Conditioner") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Additional Heating " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label111" runat="server" Text='<%# Eval("Additional_Heating") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Veh Weight" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label121" runat="server" Text='<%# Eval("Veh_Weight") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Gross Veh Weigth" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label131" runat="server" Text='<%# Eval("Gross_Veh_Weigth") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Empty Pod " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label141" runat="server" Text='<%# Eval("Empty_Pod") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Key Code  " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label151" runat="server" Text='<%# Eval("Key_Code") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rear Blake " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label161" runat="server" Text='<%# Eval("Rear_Blake") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Electronic Logbook " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label171" runat="server" Text='<%# Eval("Electronic_Logbook") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Radio Code  " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label172" runat="server" Text='<%# Eval("Radio_Code") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Guaranteed Expiration Date " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label175" runat="server" Text='<%# Eval("Guaranteed_Expiration_Date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Guaranteed Certificate Num  " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label147" runat="server" Text='<%# Eval("Guaranteed_Certificate_Num") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Circulation Expiration Date" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label137" runat="server" Text='<%# Eval("Circulation_Expiration_Date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="State " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label157" runat="server" Text='<%# Eval("Stat") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Picture">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" Width="50px" Height="40px" ImageUrl='<%# string.Concat("~/FleetApp/assets/images/Vehicles/",Eval("Picture")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        
                                        </Columns>
                                    </asp:GridView>

                                </table>

                                    <div class="card-footer">
                                        <asp:Label ID="indexFooter" runat="server"></asp:Label>
                                    </div>
                                </div>
                                
                            </div>
                        </div>

                         <!-- Vehicle end -->

                        <div class="text-center font-weight-bold">real estate</div>

                        <!--  Ministry Real Estate start -->
                        <div class="col-xl-12 col-md-12">
                            <div class="card table-card">
                                <div class="card-header">
                                    <h5>Real Estate</h5>
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
                                    
                                    <table class="">
                                    <asp:GridView ID="GridViewReal" DataKeyNames="MIN_REAL_ESTATE_ID" ShowHeaderWhenEmpty="true" EmptyDataText="No Records" HeaderStyle-HorizontalAlign="Center"
                                        class="table  table-striped  table-borderless text-center gdv" HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                        AutoGenerateColumns="false" EmptyDataRowStyle-Font-Size="X-Large" AllowPaging="true" PageSize="10" OnPreRender="gdv_PreRenderRealEstate"
                                        GridLines="None" EmptyDataRowStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#448aff" HeaderStyle-ForeColor="White"
                                        runat="server" Width="100%"  OnPageIndexChanging="gdv_PageIndexChangingRealEstate">

                                        <Columns>
                                            <%--<asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkSelHeader" runat="server" Text="Select All" AutoPostBack="true" OnCheckedChanged="checkSelHeader_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="checkSel" runat="server" OnCheckedChanged="checkSel_CheckedChanged" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                             <asp:BoundField DataField="MIN_REAL_ESTATE_ID" HeaderText="#" Visible="false" />

                                            <asp:TemplateField HeaderText="Real Estate">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5po" runat="server" Text='<%# Eval("REAL_ESTATE_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Quantity ">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3fre" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Comment">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4vde" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

                                </table>

                                    <div class="card-footer">
                                        <asp:Label ID="indexFooterReal" runat="server"></asp:Label>
                                    </div>
                                </div>

                                
                            </div>
                        </div>
                        <!-- Ministry Real Estate end -->


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
            series.data.setAll(<%= CrashAnalyse %>));


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