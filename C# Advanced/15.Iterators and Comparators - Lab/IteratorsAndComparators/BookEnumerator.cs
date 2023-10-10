using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class BookEnumerator : IEnumerator<Book>
    {
        private List<Book> books;
        private int index = -1;

        public BookEnumerator(List<Book> books)
        {
            this.books = books;
        }
        public Book Current => books[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
           
        }

        public bool MoveNext()
        {
            index++;
            return index < books.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
