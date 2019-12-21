using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataManagement.Entities
{
    [Table("AppConfig", Schema = "Application")]
    public class AppConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppConfigId { get; set; }
        public bool IsActive { get; set; }
    }
}
