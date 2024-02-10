using System.ComponentModel.DataAnnotations;

namespace Stefan_Jesenko_LBM295API.Models
{
    public class Zutaten
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Der Name der Zutat ist erforderlich.")]
        [StringLength(100, ErrorMessage = "Der Name der Zutat darf nicht länger als 100 Zeichen sein.")]
        public string Zutat { get; set; }


        [Required(ErrorMessage = "Das Herkunftsland ist erforderlich.")]
        [StringLength(100, ErrorMessage = "Der Name des Herkunftslands darf nicht länger als 100 Zeichen sein.")]
        public string Herkunftsland { get; set; }
    }   
}
