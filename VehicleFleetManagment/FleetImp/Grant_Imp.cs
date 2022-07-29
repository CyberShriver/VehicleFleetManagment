using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetImp
{
    public class Grant_Imp: Grant_Interface
    {

        int msg;
        GRANT_RIGHT G = new GRANT_RIGHT();

        //ADD METHOD
        public int Add(Grant_Class Gr)
        {
            GRANT_RIGHT G = new GRANT_RIGHT();
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                G.Menu_Code = Gr.Menu_Code;
                G.Access = Gr.Access;
                G.MINISTRY_ID = Gr.MINISTRY_ID;
                G.ROLE_ID = Gr.ROLE_ID;

                con.GRANT_RIGHT.Add(G);

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
        public int UPDATE(int code, long menu, int IdMin, Grant_Class Gr)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                G = con.GRANT_RIGHT.Where(x => x.ROLE_ID == code && x.Menu_Code == menu && x.MINISTRY_ID == IdMin).FirstOrDefault();


                G.Access = Gr.Access;

                if (con.SaveChanges() == 1)
                {
                    con.GRANT_RIGHT.Add(G);
                    con.Entry(G).State = EntityState.Modified;
                    return msg = 1;
                }
                else
                    return msg = 0;

            }
        }

        //DELETE METHOD
        public int DELETE(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                G = con.GRANT_RIGHT.Where(x => x.RowId == id).First();

                if (con.Entry(G).State == EntityState.Detached)
                    con.GRANT_RIGHT.Attach(G);

                con.GRANT_RIGHT.Remove(G);
                con.SaveChanges();

                return msg = 1;
            }
        }

        //DISPLAY METHOD
        public void Display(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {

                var obj = (from Gr in con.GRANT_RIGHT
                           join M in con.MENUs on Gr.Menu_Code equals M.Menu_Code
                           join R in con.ROLEs on Gr.ROLE_ID equals R.ROLE_ID
                           select new
                           {
                               RowId = Gr.RowId,
                               ROLE_ID = Gr.ROLE_ID,
                               Menu_Code = Gr.Menu_Code,
                               Access = Gr.Access,
                               MINISTRY_ID = Gr.MINISTRY_ID,
                               Role_Name = R.Role_Name,
                               Title_Menu = M.Title_Menu,
                           }).ToList();

                gd.DataSource = obj;
                gd.DataBind();

            }

        }

        //DISPLAY DETAILS METHOD OF ROLE
        public void DisplayDetails(int code, Grant_Class Gr)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                G = con.GRANT_RIGHT.Where(x => x.RowId == code).FirstOrDefault();
                if (G != null)
                {
                    Gr.ROLE_ID = G.ROLE_ID;
                    Gr.RowId = G.RowId;
                    Gr.Menu_Code = G.Menu_Code;
                    Gr.Access = G.Access;
                    Gr.MINISTRY_ID = G.MINISTRY_ID;
                }


            }
        }

        //DISPLAY DETAILS METHOD  OF FULL ROLE AND MENU
        public void DisplayDetails(int code, long menu, int idMin, Grant_Class Gr)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                G = con.GRANT_RIGHT.Where(x => x.ROLE_ID == code && x.Menu_Code == menu && x.MINISTRY_ID == idMin).FirstOrDefault();
                if (G != null)
                {
                    Gr.ROLE_ID = G.ROLE_ID;
                    Gr.RowId = G.RowId;
                    Gr.Menu_Code = G.Menu_Code;
                    Gr.Access = G.Access;
                    Gr.MINISTRY_ID = G.MINISTRY_ID;
                }


            }
        }

        //DISPLAY ROLE IN DROPDOWN
        public void ChargeGrant(DropDownList ddw, int code)
        {
            ddw.Items.Clear();
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = con.GRANT_RIGHT.Where(x => x.ROLE_ID == code && x.Access == "ON").ToList();

                if (obj != null && obj.Count() > 0)
                {
                    ListItem item0 = new ListItem();
                    item0.Value = "-1";
                    item0.Text = "Select Permission";
                    ddw.Items.Add(item0);

                    foreach (var data in obj)
                    {
                        ListItem item = new ListItem();
                        item.Value = data.RowId.ToString();
                        item.Text = data.RowId.ToString();
                        ddw.Items.Add(item);
                    }

                }
                else
                {
                    ddw.Items.Clear();

                    ListItem item0 = new ListItem();
                    item0.Value = "-1";
                    item0.Text = "No Data";
                    ddw.Items.Add(item0);
                }

            }
        }

        //COUNT ALL PERMISSION(GRANT)
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var c = (from l in con.GRANT_RIGHT
                         select l).Count();
                n = c;
            }
            return n;
        }

        //CHECK IF PERMISSION(GRANT) ALREADY GRANTED
        public int count(int role, string menu, int CodeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var b = (from l in con.GRANT_RIGHT
                         join M in con.MENUs on l.Menu_Code equals G.Menu_Code
                         join r in con.ROLEs on l.ROLE_ID equals r.ROLE_ID
                         join Min in con.MINISTRies on l.MINISTRY_ID equals Min.MINISTRY_ID
                         where (l.ROLE_ID == role && M.Title_Menu == menu && l.MINISTRY_ID == CodeMin && l.Access == "ON")
                         select l).Count();
                n = b;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {

                var obj = (from Gr in con.GRANT_RIGHT
                           join M in con.MENUs on Gr.Menu_Code equals M.Menu_Code
                           join r in con.ROLEs on Gr.ROLE_ID equals r.ROLE_ID
                           where (M.Title_Menu.Contains(SearchText) || r.Role_Name.Contains(SearchText))
                           select new
                           {
                              
                               RowId = Gr.RowId,
                               ROLE_ID = Gr.ROLE_ID,
                               Menu_Code = Gr.Menu_Code,
                               Access = Gr.Access,
                               MINISTRY_ID = Gr.MINISTRY_ID,
                               Role_Name = r.Role_Name,
                               Title_Menu = M.Title_Menu,

                           }).ToList();

                gd.DataSource = obj;
                gd.DataBind();

            }

        }

   

    }
}