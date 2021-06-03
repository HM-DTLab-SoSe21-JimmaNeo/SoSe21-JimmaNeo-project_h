using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared.DomainTdo
{
    public class ProfilDefinitionDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Email { get; set; }
        public string Description { get; set; }

    }
}
