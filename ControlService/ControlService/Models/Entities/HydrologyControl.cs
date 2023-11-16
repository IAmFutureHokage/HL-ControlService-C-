using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlService.Models.Entities
{
    [Table("HydrologyControl")]
    public class HydrologyControl
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int PostCode { get; set; }

        [Required]
        public int Type { get; set; }
        [Required]
        public DateOnly Datestart { get; set; }

        public DateOnly Dateend { get; set; }

        [Required]
        public int Value { get; set; }
    }
}
