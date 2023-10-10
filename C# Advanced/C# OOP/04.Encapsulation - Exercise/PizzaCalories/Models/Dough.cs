namespace PizzaCalories.Models
{
    public class Dough
    {
        private const double WhiteFlour = 1.5;
        private const double WholegrainFlour = 1.0;
        private const double CrispyTechnique = 0.9;
        private const double ChewyTechnique = 1.1;
        private const double HomemadeTechnique = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double grams;

        public string FlourType
        {
            get { return flourType; }
            set { flourType = value; }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            set { bakingTechnique = value; }
        }

        public double Grams
        {
            get { return grams; }
            set { grams = value; }
        }
        public double Calories => (Grams * 2);



    }
}
