using System.ComponentModel.DataAnnotations;

namespace Stefan_Jesenko_LBM295API.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Der Name der Pizza ist erforderlich.")]
        [StringLength(100, ErrorMessage = "Der Name der Pizza darf nicht länger als 100 Zeichen sein.")]
        public string PizzaName { get; set; }
        [Required(ErrorMessage = "Die Herkunftsregion ist erforderlich.")]
        [StringLength(100, ErrorMessage = "Der Name des Herkunftsorts darf nicht länger als 100 Zeichen sein.")]
        public string Herkunftsregion { get; set; }
        


    }
}
