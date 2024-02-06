using System.ComponentModel.DataAnnotations.Schema;

namespace Stefan_Jesenko_LBM295API.Models
{
    public class PizzaZutaten
    {
        public int Id { get; set; }

        [ForeignKey("PizzaId")]
        public int PizzaId { get; set; }
        [ForeignKey("ZutatenId")]
        public int ZutatenId { get; set; }
      
    }
}
