using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleFleetManagment.FleetImp
{
    public class Users_Imp: Users_Interface
    {

        public int Connect(Agence_Class pr, string usernm, string pwsd)
        {
            using (BeauDecorConnection con = new BeauDecorConnection())
            {
                p = con.AGENCEs.Where(x => x.USERNM == usernm && x.PSWD == pwsd && x.STATUS == "ouvert").FirstOrDefault();

                if (p != null)
                {
                    pr.IDANGC = p.IDANGC;
                    pr.id_CMN = p.id_CMN;
                    pr.CDANGC = p.CDANGC;
                    pr.CDANGC = p.CDANGC;
                    pr.system_name = p.system_name;
                    pr.email_system = p.email_system;
                    pr.PSWD = p.PSWD;
                    pr.USERNM = p.USERNM;
                    pr.titre_system = p.titre_system;
                    pr.tel = p.tel;
                    pr.logo = p.logo;
                    pr.Footer_text = p.Footer_text;
                    pr.STATUS = p.STATUS;
                    pr.DTECREATION = p.DTECREATION;
                    pr.TYPEANGC = p.TYPEANGC;
                    cm = con.CMNs.Where(x => x.id_CMN == p.id_CMN).FirstOrDefault();
                    pr.id_PVC = (int)cm.id_PVC;
                    return msg = 1;
                }
                else return msg = 0;

            }
        }

    }
}