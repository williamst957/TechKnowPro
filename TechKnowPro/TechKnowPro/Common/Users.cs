using System;
using System.Linq;
using System.Web;
using TechKnowPro.Models;

namespace TechKnowPro.Common
{
    public class Users
    {
        public static bool IsInRole(int userid, int userlevel)
        {
            Techknowprocontext db = new Techknowprocontext();

            var rec = db.Registers.Where(x => x.Id == userid && x.UserLevel == userlevel).FirstOrDefault();
          
            if (rec == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int? LoginLevel(int userid)
        {
            Techknowprocontext db = new Techknowprocontext();
            int? userlevel = 0;
            var rec = db.Registers.Where(x => x.Id == userid).FirstOrDefault();
            if(rec != null)
            {
                userlevel = rec.UserLevel;
            }
            return userlevel;
        }
    }
}
