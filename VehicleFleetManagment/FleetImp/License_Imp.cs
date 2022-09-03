using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetModel;
using System.Data.Entity;
namespace VehicleFleetManagment.FleetImp
{
    public class License_Imp : License_Interface
    {
        int msg;
        LICENSE L = new LICENSE();

        //ADD METHOD
        public int Add(License_Class Li)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                L.License_Number = Li.License_Number;
                L.International_License_Code = Li.International_License_Code;
                L.Exp_Date = Li.Exp_Date;
                L.Inter_License_Code_Exp_Date = Li.Inter_License_Code_Exp_Date;
                L.License_Code_Mission = Li.License_Code_Mission;
                L.Category_A = Li.Category_A;
                L.Category_B = Li.Category_B;
                L.Category_C = Li.Category_C;
                L.Category_D1 = Li.Category_D1;
                L.Category_D2 = Li.Category_D2;
                L.Category_E= Li.Category_E;
                L.Category_F = Li.Category_F;
                L.Issued_At = Li.Issued_At;
                L.Issued_Authority = Li.Issued_Authority;
                L.Issued_On = Li.Issued_On;
                L.Card_Number = Li.Card_Number;
                L.Scanned_Picture = Li.Scanned_Picture;
                L.License_State = Li.License_State;
                L.License_Code_Mission_Exp_Dte = Li.License_Code_Mission_Exp_Dte;
                L.MINISTRY_ID = Li.MINISTRY_ID;
                L.DRIVER_ID = Li.DRIVER_ID;
                L.Saved_Dte = Li.Saved_Dte;

                con.LICENSEs.Add(L);

                if (con.SaveChanges() > 0)
                {
                    msg = 1;
                }
                else
                {
                    msg = 0;
                }
            }


            return msg;
        }

        //UPDATE METHOD
        public int Update(License_Class Li, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                LICENSE L = new LICENSE();
                L = con.LICENSEs.Where(x => x.LICENSE_ID == id).FirstOrDefault();

                if (L != null)
                {

                    L.License_Number = Li.License_Number;
                    L.International_License_Code = Li.International_License_Code;
                    L.Exp_Date = Li.Exp_Date;
                    L.Inter_License_Code_Exp_Date = Li.Inter_License_Code_Exp_Date;
                    L.License_Code_Mission = Li.License_Code_Mission;
                    L.Category_A = Li.Category_A;
                    L.Category_B = Li.Category_B;
                    L.Category_C = Li.Category_C;
                    L.Category_D1 = Li.Category_D1;
                    L.Category_D2 = Li.Category_D2;
                    L.Category_E = Li.Category_E;
                    L.Category_F = Li.Category_F;
                    L.Issued_At = Li.Issued_At;
                    L.Issued_Authority = Li.Issued_Authority;
                    L.Issued_On = Li.Issued_On;
                    L.Card_Number = Li.Card_Number;
                    L.Scanned_Picture = Li.Scanned_Picture;
                    L.License_State = Li.License_State;
                    L.License_Code_Mission_Exp_Dte = Li.License_Code_Mission_Exp_Dte;
                    L.MINISTRY_ID = Li.MINISTRY_ID;
                    L.DRIVER_ID = Li.DRIVER_ID;
                    L.Saved_Dte = Li.Saved_Dte;

                    if (con.SaveChanges() > 0)
                    {
                        con.LICENSEs.Add(L);
                        con.Entry(L).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }

        //DELETE METHOD
        public int Delete(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = con.LICENSEs.Where(x => x.LICENSE_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.LICENSEs.Attach(obj);

                }
                con.LICENSEs.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //DISPLAY METHOD
        public void Display(GridView gd, string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.LICENSEs
                           where L.MINISTRY.Code_Min == codeMin
                           orderby L.LICENSE_ID descending

                           select new
                           {
                               LICENSE_ID = L.LICENSE_ID,
                               License_Number = L.License_Number,
                               International_License_Code = L.International_License_Code,
                               Exp_Date = L.Exp_Date,
                               Inter_License_Code_Exp_Date = L.Inter_License_Code_Exp_Date,
                               License_Code_Mission = L.License_Code_Mission,
                               License_State = L.License_State,
                               Category_A = L.Category_A +" "+ L.Category_B+ " " + L.Category_C + " " + L.Category_D1 + " " + L.Category_D2 + " " + L.Category_E + " " + L.Category_F,
                               Issued_At = L.Issued_At,
                               Issued_Authority = L.Issued_Authority,
                               Issued_On = L.Issued_On,
                               Card_Number = L.Card_Number,
                               Scanned_Picture = L.Scanned_Picture,
                               License_Code_Mission_Exp_Dte = L.License_Code_Mission_Exp_Dte,
                               DRIVER_ID = L.DRIVER.Full_Name,
                               Saved_Dte = L.Saved_Dte,
                               MINISTRY_ID = L.MINISTRY.Ministry_Name

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DISPLAY ALL METHOD
        public void DisplayAll(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.LICENSEs
                           orderby L.LICENSE_ID descending

                           select new
                           {
                               LICENSE_ID = L.LICENSE_ID,
                               License_Number = L.License_Number,
                               International_License_Code = L.International_License_Code,
                               Exp_Date = L.Exp_Date,
                               Inter_License_Code_Exp_Date = L.Inter_License_Code_Exp_Date,
                               License_Code_Mission = L.License_Code_Mission,
                               License_State = L.License_State,
                               Category_A = L.Category_A + " " + L.Category_B + " " + L.Category_C + " " + L.Category_D1 + " " + L.Category_D2 + " " + L.Category_E + " " + L.Category_F,
                               Issued_At = L.Issued_At,
                               Issued_Authority = L.Issued_Authority,
                               Issued_On = L.Issued_On,
                               Card_Number = L.Card_Number,
                               Scanned_Picture = L.Scanned_Picture,
                               License_Code_Mission_Exp_Dte = L.License_Code_Mission_Exp_Dte,
                               DRIVER_ID = L.DRIVER.Full_Name,
                               Saved_Dte = L.Saved_Dte,
                               MINISTRY_ID = L.MINISTRY.Ministry_Name
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(License_Class Li, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                L = con.LICENSEs.Where(x => x.LICENSE_ID == id).FirstOrDefault();

                Li.License_Number = L.License_Number;
                Li.International_License_Code = L.International_License_Code;
                Li.Exp_Date = L.Exp_Date;
                Li.Inter_License_Code_Exp_Date = L.Inter_License_Code_Exp_Date;
                Li.License_Code_Mission_Exp_Dte = L.License_Code_Mission_Exp_Dte;
                Li.License_Code_Mission = L.License_Code_Mission;
                Li.Category_A = L.Category_A;
                Li.Category_B = L.Category_B;
                Li.Category_C = L.Category_C;
                Li.Category_D1 = L.Category_D1;
                Li.Category_D2 = L.Category_D2;
                Li.Category_E = L.Category_E;
                Li.Category_F = L.Category_F;
                Li.Issued_At = L.Issued_At;
                Li.Issued_Authority = L.Issued_Authority;
                Li.Issued_On = L.Issued_On;
                Li.Card_Number = L.Card_Number;
                Li.Scanned_Picture = L.Scanned_Picture;
                Li.License_State = L.License_State;
                Li.MINISTRY_ID = L.MINISTRY_ID;
                Li.DRIVER_ID = L.DRIVER_ID;

              
            }
        }

        //COUNT METHOD
        public int count(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var L = (from l in con.LICENSEs
                         where l.MINISTRY.Code_Min == codeMin
                         select l).Count();
                n = L;
            }
            return n;
        }

        //COUNT ALL METHOD
        public int countAll()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var L = (from l in con.LICENSEs
                         select l).Count();
                n = L;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd, string codeMin, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.LICENSEs
                           where L.MINISTRY.Code_Min == codeMin &&
                       L.License_Code_Mission.StartsWith(SearchText) ||
                       L.License_Number.StartsWith(SearchText) ||
                       L.DRIVER.Full_Name.StartsWith(SearchText) ||
                       L.Exp_Date.StartsWith(SearchText) 
                           select new
                           {
                               LICENSE_ID = L.LICENSE_ID,
                               License_Number = L.License_Number,
                               International_License_Code = L.International_License_Code,
                               Exp_Date = L.Exp_Date,
                               Inter_License_Code_Exp_Date = L.Inter_License_Code_Exp_Date,
                               License_Code_Mission = L.License_Code_Mission,
                               License_State = L.License_State,
                               Category = L.Category_A + " " + L.Category_B + " " + L.Category_C + " " + L.Category_D1 + " " + L.Category_D2 + " " + L.Category_E + " " + L.Category_F,
                               Issued_At = L.Issued_At,
                               Issued_Authority = L.Issued_Authority,
                               Issued_On = L.Issued_On,
                               Card_Number = L.Card_Number,
                               Scanned_Picture = L.Scanned_Picture,
                               License_Code_Mission_Exp_Dte = L.License_Code_Mission_Exp_Dte,
                               DRIVER_ID = L.DRIVER.Full_Name,
                               Saved_Dte = L.Saved_Dte,
                               MINISTRY_ID = L.MINISTRY.Ministry_Name

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //REASEARCH ALL METHOD
        public void ResearchAll(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.LICENSEs
                           where
                       L.License_Code_Mission.StartsWith(SearchText) ||
                       L.License_Number.StartsWith(SearchText) ||
                       L.DRIVER.Full_Name.StartsWith(SearchText) ||
                        L.MINISTRY.Ministry_Name.StartsWith(SearchText) ||
                       L.Exp_Date.StartsWith(SearchText) ||
                       L.Category_C.StartsWith(SearchText)

                           select new
                           {
                               LICENSE_ID = L.LICENSE_ID,
                               License_Number = L.License_Number,
                               International_License_Code = L.International_License_Code,
                               Exp_Date = L.Exp_Date,
                               Inter_License_Code_Exp_Date = L.Inter_License_Code_Exp_Date,
                               License_Code_Mission = L.License_Code_Mission,
                               License_State = L.License_State,
                               Category_A = L.Category_A + " " + L.Category_B + " " + L.Category_C + " " + L.Category_D1 + " " + L.Category_D2 + " " + L.Category_E + " " + L.Category_F,
                               Issued_At = L.Issued_At,
                               Issued_Authority = L.Issued_Authority,
                               Issued_On = L.Issued_On,
                               Card_Number = L.Card_Number,
                               Scanned_Picture = L.Scanned_Picture,
                               License_Code_Mission_Exp_Dte = L.License_Code_Mission_Exp_Dte,
                               DRIVER_ID = L.DRIVER.Full_Name,
                               Saved_Dte = L.Saved_Dte,
                               MINISTRY_ID = L.MINISTRY.Ministry_Name
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DISPLAY METHOD ALL Driver
        public void DisplayAllDriver(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from D in con.DRIVERs

                           select new
                           {
                               DRIVER_ID = D.DRIVER_ID,
                               Full_Name = D.Full_Name,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Full_Name";
                drop.DataValueField = "DRIVER_ID";
                drop.DataBind();
            }

        }
        //DISPLAY METHOD Driver
        public void DisplayDriver(DropDownList drop, string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from D in con.DRIVERs where D.Ministry_Work==codeMin

                           select new
                           {
                               DRIVER_ID = D.DRIVER_ID,
                               Full_Name = D.Full_Name,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Full_Name";
                drop.DataValueField = "DRIVER_ID";
                drop.DataBind();
            }

        }

        //DISPLAY METHOD MINISTRY
        public void DisplayMinistry(DropDownList drop, string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.MINISTRies
                           where L.Code_Min == codeMin

                           select new
                           {
                               MINISTRY_ID = L.MINISTRY_ID,
                               Ministry_Name = L.Ministry_Name,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "MINISTRY_ID";
                drop.DataTextField = "Ministry_Name";
                drop.DataBind();
            }

        }

        //DISPLAY METHOD ALL MINISTRY
        public void DisplayMinistryAll(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.MINISTRies

                           select new
                           {
                               MINISTRY_ID = L.MINISTRY_ID,
                               Ministry_Name = L.Ministry_Name,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "MINISTRY_ID";
                drop.DataTextField = "Ministry_Name";
                drop.DataBind();
            }

        }


    }
}