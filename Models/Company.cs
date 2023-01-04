using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class Company
    {
        public string CompanyID { get ; set; } =default!;
        public string CompanyName { get ; set; } =default!;
    }
}