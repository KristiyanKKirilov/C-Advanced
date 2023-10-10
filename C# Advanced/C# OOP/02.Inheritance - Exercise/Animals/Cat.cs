namespace Animals
{
    public class Cat : Animal
    {
        private const string DefaultSound = "Meow meow";
        public Cat(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }
        public override string Sound => DefaultSound;
    }
}
