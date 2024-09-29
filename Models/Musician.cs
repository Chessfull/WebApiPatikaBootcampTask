using System.ComponentModel.DataAnnotations;

namespace WebApiPatikaBootcampTask.Models
{
    public class Musician
    {
        public int MusicianId { get; set; }

        [Required(ErrorMessage = "Name required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be between 3 and 100 letter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proficiency required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Proficiency should be between 3 and 100 letter")]
        public string Proficiency { get; set; }

        public string ?FunFact { get; set; }

    }
}
