using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;

namespace VehicleFleetManagment.FleetApp
{
    public partial class AddProvider : System.Web.UI.Page
    {
        Provider_Class  Pr = new Provider_Class ();
        Provider_Interface I = new Provider_Imp();
        int msg;
        string id,code, sytemTitle,slogan;
        public string ImgView;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["PROVIDER_ID"];
            ChargeCookies();

            if (!IsPostBack)
            {
                MsgInit();
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;

                if (id == null)
                {
                    btnSave.InnerText = "Save";
                    displayContract.Visible = false;
                }
                else

                {
                    btnSave.InnerText = "Edit";
                    ChargeData();
                    displayContract.Visible = true;
                }

            }

        }

        void ChargeCookies()
        {
            if ( Request.Cookies["Slogan"] != null || Request.Cookies["System_Title"] != null)
            {
                sytemTitle = Request.Cookies["System_Title"].Value;
                slogan = Request.Cookies["Slogan"].Value;
            }

        }
        private void MsgInit()
        {
            SuccessMsg.Visible = false;
            FillMsg.Visible = false;
            ExistMsg.Visible = false;
            FailMsg.Visible = false;
        }

        //Add 
        void Add()
        {

            try
            {
                if (txtFullName.Value == "" || txtTel.Value == "" || dateBirth.Value == "" || txtCNI.Text == "" || txtAddress.Value == ""||txtMail.Value == "" || file_updContract.HasFile==false)
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    ExistMsg.Visible = false;
                    FailMsg.Visible = false;
                }
                else
                {
                    try
                    {

                        if (file_upd.HasFile && file_updContract.HasFile)
                        {
                            file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images/Providers/") + Path.GetFileName(file_upd.FileName));
                            file_updContract.SaveAs(Server.MapPath("~/FleetApp/assets/images/Providers/") + Path.GetFileName(file_updContract.FileName));
                            string img = Path.GetFileName(file_upd.FileName);
                            string img1 = Path.GetFileName(file_updContract.FileName);
                            FileInfo ext = new FileInfo(img);
                            FileInfo ext1 = new FileInfo(img1);
                            if (ext1.Extension == ".doc" || ext1.Extension == ".png" || ext1.Extension == ".jpg" || ext1.Extension == ".jpeg" || ext1.Extension == ".pdf" || ext1.Extension == ".docx" || ext1.Extension == ".txt" ||
                                ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                            {
                                if (file_upd.PostedFile.ContentLength < 104857600)
                                {

                                    Pr.CNI = txtCNI.Text;
                                    Pr.Address = txtAddress.Value;
                                    Pr.Provider_Type = DropDown_ProviderType.SelectedItem.Value;
                                    Pr.Provider_Code = ProviderCode();
                                    Pr.Full_Name = txtFullName.Value;
                                    Pr.Phone = txtTel.Value;
                                    Pr.Email = txtMail.Value;
                                    Pr.Stat = DropDown_Status.SelectedItem.Value;
                                    Pr.DOB = dateBirth.Value;
                                    Pr.Picture = img;
                                    Pr.Contract = img1;
                                    Pr.Saved_Date = DateTime.Now.ToString();
                                    msg = I.Add(Pr);
                                    if (msg > 0)
                                    {
                                        FillMsg.Visible = false;
                                        FailMsg.Visible = false;
                                        SuccessMsg.Visible = true;
                                        ExistMsg.Visible = false;

                                        txtCode.Value = "";
                                        txtFullName.Value = "";
                                        txtTel.Value = "";
                                        txtMail.Value = "";
                                    }
                                    else
                                    {
                                        SuccessMsg.Visible = false;
                                        FillMsg.Visible = false;
                                        FailMsg.Visible = true;
                                        ExistMsg.Visible = false;

                                    }
                                }
                                else
                                {
                                    SuccessMsg.Visible = false;
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = true;
                                    ExistMsg.Visible = false;
                                }
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;
                                ExistMsg.Visible = false;
                            }
                        }
                        else
                        {
                            Pr.CNI = txtCNI.Text;
                            Pr.Address = txtAddress.Value;
                            Pr.Provider_Type = DropDown_ProviderType.SelectedItem.Value;
                            Pr.Provider_Code = ProviderCode();
                            Pr.Full_Name = txtFullName.Value;
                            Pr.Phone = txtTel.Value;
                            Pr.Email = txtMail.Value;
                            Pr.Stat = DropDown_Status.SelectedItem.Value;
                            Pr.DOB = dateBirth.Value;
                            Pr.Picture = "unkownDriver.jpg";
                            Pr.Contract = "";
                            Pr.Saved_Date = DateTime.Now.ToString();
                            msg = I.Add(Pr);
                            if (msg > 0)
                            {
                                FillMsg.Visible = false;
                                FailMsg.Visible = false;
                                SuccessMsg.Visible = true;
                                ExistMsg.Visible = false;

                                txtCode.Value = "";
                                txtFullName.Value = "";
                                txtTel.Value = "";
                                txtMail.Value = "";
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                ExistMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;

                            }
                        }
                    }
                    catch (DirectoryNotFoundException)
                    {
                        FailMsg.Visible = true;
                    }
                }
            }
            catch (SqlException e)
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FailMsg.Visible = true;
            }
        }

        //update
        void Update()
        {
            try
            {
                if (txtFullName.Value == "" || txtTel.Value == "" || dateBirth.Value == "" || txtCNI.Text == "" || txtAddress.Value == "" || txtMail.Value == "" || file_updContract.HasFile == false)
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    ExistMsg.Visible = false;
                    FailMsg.Visible = false;
                }
                else
                {
                    try
                    {
                        if (file_upd.HasFile && file_updContract.HasFile)
                        {
                            file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images/Providers/") + Path.GetFileName(file_upd.FileName));
                            file_updContract.SaveAs(Server.MapPath("~/FleetApp/assets/images/Providers/") + Path.GetFileName(file_updContract.FileName));
                            string img = Path.GetFileName(file_upd.FileName);
                            string img1 = Path.GetFileName(file_updContract.FileName);
                            FileInfo ext = new FileInfo(img);
                            FileInfo ext1 = new FileInfo(img1);
                            if (ext1.Extension == ".doc" || ext1.Extension == ".png" || ext1.Extension == ".jpg" || ext1.Extension == ".jpeg" || ext1.Extension == ".pdf" || ext1.Extension == ".docx" || ext1.Extension == ".txt" ||
                                ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                            {
                                if (file_upd.PostedFile.ContentLength < 104857600)
                                {

                                    Pr.CNI = txtCNI.Text;
                                    Pr.Address = txtAddress.Value;
                                    Pr.Provider_Type = DropDown_ProviderType.SelectedItem.Value;
                                    Pr.Provider_Code = ProviderCode();
                                    Pr.Full_Name = txtFullName.Value;
                                    Pr.Phone = txtTel.Value;
                                    Pr.Email = txtMail.Value;
                                    Pr.Saved_Date = DateTime.Now.ToString();
                                    Pr.Stat = DropDown_Status.SelectedItem.Value;
                                    Pr.DOB = dateBirth.Value;
                                    Pr.Picture = img;
                                    Pr.Contract = img1;
                                    msg = I.Update(Pr, Convert.ToInt32(id));

                                    if (msg > 0)
                                    {
                                        Response.Redirect("~/FleetApp/ViewProvider.aspx");
                                    }
                                    else
                                    {
                                        SuccessMsg.Visible = false;
                                        FillMsg.Visible = false;
                                        FailMsg.Visible = true;
                                        ExistMsg.Visible = false;

                                    }
                                }
                                else
                                {
                                    SuccessMsg.Visible = false;
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = true;
                                    ExistMsg.Visible = false;
                                }
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;
                                ExistMsg.Visible = false;
                            }
                        }
                        else
                        {
                            Pr.CNI = txtCNI.Text;
                            Pr.Address = txtAddress.Value;
                            Pr.Provider_Type = DropDown_ProviderType.SelectedItem.Value;
                            Pr.Provider_Code = ProviderCode();
                            Pr.Full_Name = txtFullName.Value;
                            Pr.Phone = txtTel.Value;
                            Pr.Email = txtMail.Value;
                            Pr.Stat = DropDown_Status.SelectedItem.Value;
                            Pr.DOB = dateBirth.Value;
                            Pr.Picture = "unkownDriver.jpg";
                            Pr.Contract = "";
                            Pr.Saved_Date = DateTime.Now.ToString();
                            msg = I.Update(Pr, Convert.ToInt32(id));

                            if (msg > 0)
                            {
                                Response.Redirect("~/FleetApp/ViewProvider.aspx");
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                ExistMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;

                            }
                        }
                    }
                    catch (DirectoryNotFoundException)
                    {
                        FailMsg.Visible = true;
                    }
                }
            }
            catch (SqlException e)
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FailMsg.Visible = true;
            }
        }

        protected void ChargeData()
        {
            if (id != null)
            {
                I.provide(Pr, Convert.ToInt32(id));

                 DropDown_ProviderType.SelectedItem.Value= Pr.Provider_Type;
                 txtCode.Value = Pr.Provider_Code;
                 txtFullName.Value= Pr.Full_Name;
                 txtTel.Value = Pr.Phone;
                 txtMail.Value= Pr.Email;
                 DropDown_Status.SelectedItem.Value= Pr.Stat;
                txtCNI.Text = Pr.CNI;
                txtAddress.Value = Pr.Address;
                dateBirth.Value = Pr.DOB;
                ImgView = "assets/images/Providers/" + Pr.Contract;
            }
        }

        protected void OnTextChanged_txtCNI(object sender, EventArgs args)
        {
            msg = I.ProvideByCNI(Pr, txtCNI.Text);
            if (msg == 1)
            {
                ExistMsg.Visible = true;
                DropDown_ProviderType.SelectedItem.Value = Pr.Provider_Type;
                txtCode.Value = Pr.Provider_Code;
                txtFullName.Value = Pr.Full_Name;
                txtTel.Value = Pr.Phone;
                txtMail.Value = Pr.Email;
                DropDown_Status.SelectedItem.Value = Pr.Stat;
                txtCNI.Text = Pr.CNI;
                txtAddress.Value = Pr.Address;
                dateBirth.Value = Pr.DOB;
                ImgView = "assets/images/Providers/" + Pr.Contract;

                btnSave.Visible = false;
                btnEmpty.Visible = true;
                displayContract.Visible = true;

            }
            else
            {         
                btnSave.Visible = true;
                btnEmpty.Visible = false;
                ExistMsg.Visible = false;
            }

        }

        string ProviderCode()
        {
            return code = txtCNI.Text.Trim().Substring(0, 4) + (Convert.ToInt32(I.count() + 1)) + DateTime.Today.ToString("ddMMyyyy");

        }

        protected void btn_save_Click(object sender, EventArgs args)
        {
            if (id == null)
            {
                Add();
            }
            else
                Update();
        }

        protected void btn_Empty_Click(object sender, EventArgs args)
        {
            txtCode.Value = "";
            txtFullName.Value = "";
            txtTel.Value = "";
            txtAddress.Value = "";
            txtMail.Value = "";
            dateBirth.Value = "";
            txtCNI.Text = "";
            btnEmpty.Visible = false;
            btnSave.Visible = true;
            ExistMsg.Visible = false;
            displayContract.Visible = true;
        }

    }
}