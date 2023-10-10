namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TomcatGender = "Male";
        private const string DefaultSound = "MEOW";
        public Tomcat(string name, int age) : base(name, age, TomcatGender)
        {
        }
        public override string Sound => DefaultSound;
    }
}
