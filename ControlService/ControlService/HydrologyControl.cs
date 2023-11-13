using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ControlService
{
    [Table("HydrologyControl")]
    public class HydrologyControl
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public int post_code { get; set; }

        [Required]
        public int type { get; set; }
        [Required]
        public DateOnly datestart { get; set; }

        public DateOnly dateend { get; set; }

        [Required]
        public int value { get; set; }
    }
}
