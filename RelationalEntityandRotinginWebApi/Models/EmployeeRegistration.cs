using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalEntityandRotinginWebApi.Models
{
    public class EmployeeRegistration
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string EmployeeName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Occupitaion { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Imagepath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
