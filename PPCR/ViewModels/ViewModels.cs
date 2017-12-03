using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PPCR.Models;

namespace PPCR.ViewModels
{
    public class ViewModel
    {
        public List<DISTRICT> zDistricts { get; set; }
        public List<PROPERTY> zProperties { get; set; }
        public List<STREET> zStreets { get; set; }
        public List<WARD> zWards { get; set; }
    }
}