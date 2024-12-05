using PrintingLibrary;

namespace Project
{
    internal class Program
    {

        static void SearchAll(TestCollections testCollections, Book middle)
        {
            Book first = testCollections.GetFirstFromList().ShallowCopy();
            Book last = testCollections.GetLastFromList().ShallowCopy();
            
            Book nonExist = new Book("Ни о чем", 0, "Никто");

            Console.WriteLine("Поиск первого элемента");
            testCollections.FindElement(first);

            Console.WriteLine("Поиск первого элемента");
            testCollections.FindElement(first);

            Console.WriteLine("Поиск последнего элемента");
            testCollections.FindElement(last);

            Console.WriteLine("Поиск среднего элемента");
            testCollections.FindElement(middle);

            Console.WriteLine("Поиск не существующего элемента");
            testCollections.FindElement(nonExist);

        }

        static void Main(string[] args)
        {
            TestCollections testCollections = new TestCollections();

            Book centralBook = testCollections.Init();

            SearchAll(testCollections, centralBook);

            testCollections.ShowLenghts();

            testCollections.PushBack(centralBook);

            testCollections.ShowLenghts();

            testCollections.DeleteFirstFromList();
            testCollections.DeleteLastFromList();
            testCollections.DeleteByKeyFromDict(centralBook.BasePrinting);

            testCollections.ShowLenghts();

        }
    }
}
