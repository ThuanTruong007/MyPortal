using DataManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataManagement.ApplicationService.Query
{
    public class GetUserByIdQuery : IQuery<User>
    {
        [Required]
        public int UserId { get; set; }
    }
}
