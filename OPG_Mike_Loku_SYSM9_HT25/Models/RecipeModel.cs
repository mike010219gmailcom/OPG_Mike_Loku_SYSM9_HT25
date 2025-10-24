using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPG_Mike_Loku_SYSM9_HT25.Models
{
    public class RecipeModel
    {
        public string Title {  get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public string CreatedBy { get; set; }

    }
}
