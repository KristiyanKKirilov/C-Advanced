namespace PizzaCalories.Models
{
    public class Topping
    {
        private string meat;
        private string veggies;
        private string cheese;
        private string sauce;


        private int grams;
        public int Grams 
        {
            get => grams;
            set => grams = value;           
        }
    }
}
