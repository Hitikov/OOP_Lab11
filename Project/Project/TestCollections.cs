using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintingLibrary;

namespace Project
{
    public class TestCollections
    {
        private static int collectionLen = 1000;

        private List<Book> bookList;
        private List<string> bookListStr;
        private Dictionary<Printing, Book> bookDictionary;
        private Dictionary<string, Book> bookDictionaryStr;

        public TestCollections()
        {
            bookList = new List<Book>(collectionLen);
            bookListStr = new List<string>(collectionLen);
            bookDictionary = new Dictionary<Printing, Book>(collectionLen);
            bookDictionaryStr = new Dictionary<string, Book>(collectionLen);
        }
        
        public Book Init()
        {
            bookList.Clear();
            bookListStr.Clear();
            bookDictionary.Clear();
            bookDictionaryStr.Clear();

            Book book = new Book();

            for (int i = 0; i < collectionLen; i++)
            {
                Book newObj = new Book();

                do
                {
                    newObj.RandomInit();
                } while (bookDictionary.ContainsKey(newObj.BasePrinting));

                bookList.Add(newObj);
                bookListStr.Add(newObj.ToString());

                bookDictionary[newObj.BasePrinting] = newObj;
                bookDictionaryStr[newObj.BasePrinting.ToString()] = newObj;

                if (i == collectionLen / 2)
                {
                    book = newObj.ShallowCopy();
                }
            }

            return book;
        }

        public void PushBack(Book book)
        {
            bookList.Add(book);
            bookListStr.Add(book.ToString());
            bookDictionary[book.BasePrinting] = book;
            bookDictionaryStr[book.BasePrinting.ToString()] = book;
        }

        public void DeleteFirstFromList()
        {
            bookList.RemoveAt(0);
            bookListStr.RemoveAt(0);
        }

        public void DeleteLastFromList()
        {
            bookList.RemoveAt(bookList.Count - 1);
            bookListStr.RemoveAt(bookListStr.Count - 1);
        }

        public void DeleteByKeyFromDict(Printing printing)
        {
            bookDictionary.Remove(printing);
            bookDictionaryStr.Remove(printing.ToString());
        }
        
        public Book GetFirstFromList()
        {
            return bookList[0];
        }

        public Book GetLastFromList()
        {
            return bookList[bookList.Count - 1];
        }

        
        public void ShowLenghts()
        {
            Console.WriteLine("Размер List<Book>: " + bookList.Count);
            Console.WriteLine("Размер List<string>" + bookListStr.Count);
            Console.WriteLine("Размер Dictionary<Printing, Book>" + bookDictionary.Count);
            Console.WriteLine("Размер Dictionary<string, Book>" + bookDictionaryStr.Count);
            Console.WriteLine();
        }

        public void FindElement (Book targetbook)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            
            if (bookList.Contains(targetbook))
            {
                Console.WriteLine("Элемент в List<Book> найден");
            }
            else
            {
                Console.WriteLine("Элемент в List<Book> не найден");
            }
            
            stopWatch.Stop();
            Console.WriteLine("Время поиска: " + stopWatch.ElapsedTicks + " тиков");


            stopWatch.Restart();
            
            if (bookListStr.Contains(targetbook.ToString()))
            {
                Console.WriteLine("Элемент в List<string> найден");
            }
            else
            {
                Console.WriteLine("Элемент в List<string> не найден");
            }
            
            stopWatch.Stop();
            Console.WriteLine("Время поиска: " + stopWatch.ElapsedTicks + " тиков");


            stopWatch.Restart(); 
            
            //Ошибка здесь
            if (bookDictionary.ContainsValue(targetbook))
            {
                Console.WriteLine("Элемент в Dictionary<Printing, Book> найден");
            }
            else
            {
                Console.WriteLine("Элемент в Dictionary<Printing, Book> не найден");
            }

            stopWatch.Stop();
            Console.WriteLine("Время поиска: " + stopWatch.ElapsedTicks + " тиков");


            stopWatch.Restart();
            
            if (bookDictionaryStr.ContainsKey(targetbook.BasePrinting.ToString()))
            {
                Console.WriteLine("Элемент в Dictionary<string, Book> найден");
            }
            else
            {
                Console.WriteLine("Элемент в Dictionary<string, Book> не найден");
            }

            stopWatch.Stop();
            Console.WriteLine("Время поиска: " + stopWatch.ElapsedTicks + " тиков");

            Console.WriteLine();
        }
    }
}
