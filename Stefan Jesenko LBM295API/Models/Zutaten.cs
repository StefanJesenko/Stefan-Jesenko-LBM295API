namespace Stefan_Jesenko_LBM295API.Models
{
    public class Zutaten
    {
        public int Id { get; set; }
        public string Zutat { get; set; }

        public List<Pizza> Pizza { get; set; } = new List<Pizza>();

    }   
}
