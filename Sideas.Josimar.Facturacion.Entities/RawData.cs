using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sideas.Josimar.Facturacion.Entities
{
    [Table("RAW_Data", Schema = "dbo")]
    public class RawData

       {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public string? EntityName { get; set; }
        public string? Payload { get; set; }
        public DateTime ImportTimestamp_UTC { get; set; }
    }
}
