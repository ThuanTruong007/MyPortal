using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataManagement.Entities
{
    [Table("User",Schema = "Security")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId           {get; set;}
        public string UserName      {get; set;}
        public string UserMobile    {get; set;}
        public string UserEmail     {get; set;}
        public string FaceBookUrl   {get; set;}
        public string LinkedInUrl   {get; set;}
        public string TwitterUrl    {get; set;}
        public string PersonalWebUrl{get; set;}
        public bool IsDeleted       {get; set;}
        public bool IsActive        {get; set;}
    }
}
