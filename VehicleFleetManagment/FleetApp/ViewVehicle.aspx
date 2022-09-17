<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="ViewVehicle.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.ViewVehicle" %>

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
                            <a href="index.html"><i class="fa fa-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="AddVehicle.aspx">Add-Vehicle</a>
                        </li>
                        <li class="breadcrumb-item"><a href="ViewVehicle.aspx">List-Vehicle</a>
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
                    <!-- Hover table card start -->
                    <div class="card">
                        <div class="card-header">
                            <h5 class="font-weight-bold">All Vehicles Records</h5>
                            <div class="card-header-right">
                                <ul class="list-unstyled card-option">
                                    <li><i class="fa fa fa-wrench open-card-option"></i></li>
                                    <li><i class="fa fa-window-maximize full-card"></i></li>
                                    <li><i class="fa fa-minus minimize-card"></i></li>
                                    <li><a onserverclick="btnReload_click" runat="server" class="reload-card btn-out"><i class="fa fa-refresh"></i></a></li>                                   
                                    <li><a onserverclick="DeleteCheck_Click" runat="server" class="reload-card btn-out"><i class="fa fa-trash"></i></a></li>
                                </ul>
                            </div>

                            <!-- Start Search  -->
                             <div class="row">                                    
                                    <div class="col-md-6 d-flex mx-auto mb-0 mt-0">
                                        <div class="col-md ">
                                            <div class="form-material">
                                                <div class="form-group form-primary">
                                                    <input name="footer-email" class="form-control"  id="txt_Search" runat="server" placeholder="search" OnTextChanged="txt_Search_TextChanged"/>
                                                    <span class="form-bar"></span>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md">
                                            <button class="btn btn-default" runat="server" onserverclick="btn_srch_Click"><i class="fa fa-search m-r-10"></i>search</button>

                                        </div>
                                    </div>
                            </div>  
                            <!-- end Search  -->

                           <div class="float-right mt-0 d-flex mb-0" runat="server" id="records">
                                <span runat="server" class="font-weight-bold mr-1">Records: </span>
                                <asp:Label ID="nbr" runat="server" Text="" class="text-danger font-weight-bold mr-1"> </asp:Label>
                            </div>

                            <div class="float-right mt-0 d-flex mb-0" runat="server" id="CountserchResult" visible="false">
                                <span runat="server" class="font-weight-bold mr-1">Search result: </span>
                                <asp:Label ID="txtSearchResult" runat="server" Text="" class="text-danger font-weight-bold mr-1"> </asp:Label>
                            </div>

                        </div>
                        <div class="card-block table-border-style">
                            <div class="table-responsive">
                                 <div class=" ml-5  mb-2 mr-5" runat="server" id="DeleteAllVisibility" visible="false">
                                            <button  runat="server"  class="btn btn-default ml-5" onserverclick="DeleteCheck_Click">
                                                <i class="fa fa-trash"></i>
                                            </button>
                                    </div>
                                <table class="">
                                    <asp:GridView ID="gdv" DataKeyNames="VEHICLE_ID" ShowHeaderWhenEmpty="true" EmptyDataText="No Records" HeaderStyle-HorizontalAlign="Center"
                                        class="table  table-striped  table-borderless text-center gdv" HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                        AutoGenerateColumns="false" EmptyDataRowStyle-Font-Size="X-Large" AllowPaging="true" PageSize="10" OnPreRender="gdv_PreRender"
                                        GridLines="None" EmptyDataRowStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#448aff" HeaderStyle-ForeColor="White"
                                        runat="server" Width="100%" OnRowCommand="gdv_RowCommand" OnPageIndexChanging="gdv_PageIndexChanging">

                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkSelHeader" runat="server" Text="Select All" AutoPostBack="true" OnCheckedChanged="checkSelHeader_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="checkSel" runat="server" OnCheckedChanged="checkSel_CheckedChanged" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:BoundField DataField="VEHICLE_ID" HeaderText="#" Visible="false" />
                                           
                                            <asp:TemplateField HeaderText="Vehicle Code " Visible="false" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Veh_Code ") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Name" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("NameVeh ") %>'></asp:Label>
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

                                            <asp:TemplateField HeaderText="Body">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("BODY_ID ") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                                                      
                                            <asp:TemplateField HeaderText=" Ministry"  Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("MINISTRY_ID") %>'></asp:Label>
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

                                            <asp:TemplateField HeaderText="Tank Type 1 " Visible="false">
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
                                            <asp:TemplateField HeaderText="State " Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label157" runat="server" Text='<%# Eval("Stat") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Picture">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" Width="50px" Height="40px" ImageUrl='<%# string.Concat("~/FleetApp/assets/images/Vehicles/",Eval("Picture")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_Edit" class="btn btn-sm btn-primary mr-4" runat="server" Text="Edit" CommandName="edit" CommandArgument='<%# Eval("VEHICLE_ID") %>' />
                                                    <asp:Button ID="Btn_Delete" class="btn btn-sm btn-danger " runat="server" Text="Delete" CommandName="delet" CommandArgument='<%# Eval("VEHICLE_ID") %>' OnClientClick="return confirm('Do you want to delete It?')" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

                                </table>
                            </div>
                        </div>

                        <div class="card-footer">
                            <asp:Label ID="indexFooter" runat="server"></asp:Label>
                        </div>
                    </div>
                    <!-- Hover table card end -->
                </div>
                <!-- Page body end -->
            </div>
        </div>
        <!-- Main-body end -->
        <div id="styleSelector">
        </div>
    </div>
</asp:Content>
