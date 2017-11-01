using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vlandr.Entity
{
    public class User
    {
        [Key,ForeignKey("")]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 200)]
        public string Login { get; set; }
        [Required,StringLength(maximumLength:200)]
        public string Password { get; set; }

    }
}
