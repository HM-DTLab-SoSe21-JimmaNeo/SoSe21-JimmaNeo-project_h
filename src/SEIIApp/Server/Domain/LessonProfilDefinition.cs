using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class LessonProfilDefinition
    {
        [Key]
        public int lessonProfilId { get; set; }
        public int Id { get; set; }
        public int lessonNumber { get; set; }

        public LessonDefinition LessonDefinition { get; set; }

        public ProfilDefinition ProfilDefinition { get; set; }
    }
}
