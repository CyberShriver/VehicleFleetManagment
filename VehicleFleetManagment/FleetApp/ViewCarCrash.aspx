<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="ViewCarCrash.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.ViewCarCrash" %>

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
                        <li class="breadcrumb-item"><a href="AddCarCrash.aspx">Add-Crash</a>
                        </li>
                        <li class="breadcrumb-item"><a href="ViewCarCrash.aspx">List-Crash</a>
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
                            <h5 class="font-weight-bold">All Crash Records</h5>
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
                                                    <input  name="footer-email" class="form-control"  id="txt_Search" runat="server" placeholder="search" OnTextChanged="txt_Search_TextChanged"/>
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
                                    <asp:GridView ID="gdv" DataKeyNames="CAR_CRASH_ID" ShowHeaderWhenEmpty="true" EmptyDataText="No Records" HeaderStyle-HorizontalAlign="Center"
                                        class="table  table-striped  table-borderless text-center gdv" HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                        AutoGenerateColumns="false" EmptyDataRowStyle-Font-Size="X-Large" AllowPaging="true" PageSize="10" OnPreRender="gdv_PreRender"
                                        GridLines="None" EmptyDataRowStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#448aff" HeaderStyle-ForeColor="White"
                                        runat="server" Width="100%" OnRowCommand="gdv_RowCommand" OnPageIndexChanging="gdv_PageIndexChanging">

                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkSelHeader" runat="server" Text=" Select All" AutoPostBack="true" OnCheckedChanged="checkSelHeader_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="checkSel" runat="server" OnCheckedChanged="checkSel_CheckedChanged"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="CAR_CRASH_ID" HeaderText="#" Visible="false" />
                                          
                                            <asp:TemplateField HeaderText="Ministry" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("MINISTRY_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Vehicle">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Local_Plate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Driver" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("MIN_DRIVER_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Crash code" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Crash_Code") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Crash Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Crash_Date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Crash Time ">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Crash_Time") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Crash Mileage" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("Crash_Mileage") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField HeaderText="Compensation Rule Dte " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("Compensation_Rule_Dte") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Circumstance " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("Circumstance") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Passenger Comment" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("Passenger_Comment") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Crash Place" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("Crash_Place") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Full Crash Address" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("Full_Crash_Address") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Crash Info" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("Crash_Info") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Responsible" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("Responsible") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Crash_Reason" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("Crash_Reason") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Weather" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lab" runat="server" Text='<%# Eval("Weather") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Estimated Speed" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="gen" runat="server" Text='<%# Eval("Estimated_Speed") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Condition After Crash" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="tra" runat="server" Text='<%# Eval("Condition_After_Crash") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                           
                                            <asp:TemplateField HeaderText="Total passengers" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="rhd" runat="server" Text='<%# Eval("Tot_Number_Driver_drives") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Crash_Damage" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="saf" runat="server" Text='<%# Eval("Crash_Damage") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Insurance Declaration Date" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="gea" runat="server" Text='<%# Eval("Insurance_Declaration_Dte") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Report Date" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="opt" runat="server" Text='<%# Eval("Report_Dte") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Final Report Date " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="locking" runat="server" Text='<%# Eval("Final_Report_Dte") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Damage Description" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="rear" runat="server" Text='<%# Eval("Damage_Description") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Damage Third Party" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="series" runat="server" Text='<%# Eval("Damage_Third_Party") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Claim Compensation Amount" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lock" runat="server" Text='<%# Eval("Claim_Compensation_Amount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Damaged Vehicle" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="cyllndr" runat="server" Text='<%# Eval("Damaged_Vehicle") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Legal Cost" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="cc" runat="server" Text='<%# Eval("Legal_Cost") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Third_Party Injures " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("Third_Party_Injures") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Injures Employee" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("Injures_Employee") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Local Insurance Compensation Amount " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label31" runat="server" Text='<%# Eval("Local_Insurance_Compensation_Amount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Payed Employee " Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label51" runat="server" Text='<%# Eval("Payed_Employee") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Amount Recovered" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label62" runat="server" Text='<%# Eval("Employee_Amount_Recovered") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ThirdParty Amount Recovered" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label71" runat="server" Text='<%# Eval("ThirdParty_Amount_Recovered") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="State" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label83" runat="server" Text='<%# Eval("Stat") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Picture">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" Width="50px" Height="40px" ImageUrl='<%# string.Concat("~/FleetApp/assets/images/Crash/",Eval("Crash_Pic")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Saved Date " Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label91" runat="server" Text='<%# Eval("Saved_Date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_Edit" class="btn btn-sm btn-primary mr-4" runat="server" Text="Edit" CommandName="edit" CommandArgument='<%# Eval("CAR_CRASH_ID") %>' />
                                                    <asp:Button ID="Btn_Delete" class="btn btn-sm btn-danger " runat="server" Text="Delete" CommandName="delet" CommandArgument='<%# Eval("CAR_CRASH_ID") %>' OnClientClick="return confirm('Do you want to delete It?')" />
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
