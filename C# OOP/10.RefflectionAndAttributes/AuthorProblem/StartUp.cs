using System;

namespace AuthorProblem
{
    [Author("Victor")]
    public class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            new Tracker().PrintMethodsByAuthor();
        }


        [Author("Dimito")]
        static void Add()
        {

        }
    }
}