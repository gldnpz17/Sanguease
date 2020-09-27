using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueaseDataAccess.Models
{
    public class BDEvent
    {
        public int Id { get; set; }
        [Required][MaxLength(512)]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Latitude { get; set; }
        [Required]
        public decimal Longitude { get; set; }
        [Required][MaxLength(2048)]
        public string Description { get; set; }
        [Required]
        public byte[] Image { get; set; }
    }
}
