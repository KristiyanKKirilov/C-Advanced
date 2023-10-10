namespace PizzaCalories.Models
{
    public class Pizza
    {
		private string name;
		private Dough dough;
		private List<string> toppings;	

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }
        public List<string> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }

    }
}
