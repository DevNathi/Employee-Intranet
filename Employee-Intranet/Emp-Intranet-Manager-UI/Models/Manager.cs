using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Intranet_Manager_UI.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string manager_jobtitle { get; set; }
        public string manager_department { get; set; }
        public string manager_contract { get; set; }
        public DateTime manager_startdate { get; set; }

    }
    public class ManagerProfile
    {
        public int Id { get; set; }
        public string profile_name { get; set; }
        public string profile_surname { get; set; }
        public int employee { get; set; }
        public int manager { get; set; }
    }

}