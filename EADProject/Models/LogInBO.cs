using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADProject.Models
{
    public class LogInBO
    {
        public string email { get; set; }
        public string pass { get; set; }
        public string getpass()
        {
            return pass;
        }
        public string getemail()
        {
            return pass;
        }
        public void setpass(string p)
        {
           pass=p;
        }
        public void setemail(string e)
        {
            email = e;
        }
    }
}