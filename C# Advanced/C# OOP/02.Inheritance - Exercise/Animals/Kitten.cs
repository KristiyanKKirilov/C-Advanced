namespace Animals
{
    public class Kitten : Cat
    {
        private const string KittenGender = "Female";
        private const string DefaultSound = "Meow";
        public Kitten(string name, int age) : base(name, age, KittenGender)
        {
        }
        public override string Sound => DefaultSound;
    }
}
