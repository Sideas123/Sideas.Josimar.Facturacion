using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sideas.Josimar.Facturacion.Entities
{
    [Table("TransactionLogs")]
    public class TransactionLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProcessId { get; set; }

        public string ReferenceId { get; set; }

        public bool Success { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; } 
    }
}
