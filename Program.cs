using KpiCs;

class Program
{
    static void Main(string[] args)
    {
        CustomQueue<int> myQueue = new CustomQueue<int>();

        // Підписка на події
        myQueue.OnItemAdded += ItemAddedEventHandler;
        myQueue.OnItemRemoved += ItemRemovedEventHandler;
        myQueue.OnCollectionCleared += CollectionClearedEventHandler;
        myQueue.OnItemAddedToBeginning += ItemAddedToBeginningEventHandler;
        myQueue.OnItemAddedToEnd += ItemAddedToEndEventHandler;


        // Додавання елементів
        myQueue.Add(10);
        myQueue.Add(20);
        myQueue.Add(30);

        Console.WriteLine("Елементи черги до видалення :");
        myQueue.PrintAll();

        // Видалення елемента
        myQueue.Remove(20);

        Console.WriteLine("Елементи черги після видалення :");
        myQueue.PrintAll();

        // Перегляд першого елемента
        Console.WriteLine("Перший елемент: " + myQueue.Peek());

        // Отримання елемента за індексом
        Console.WriteLine("Елемент за індексом 1: " + myQueue.ElementAt(1));
        try
        {
            myQueue.Remove(100);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Виникла помилка: " + ex.Message);
        }
    }

    private static void ItemAddedEventHandler(object sender, int e)
    {
        Console.WriteLine("Доданий елемент: " + e);
    }

    private static void ItemRemovedEventHandler(object sender, int e)
    {
        Console.WriteLine("Видалений елемент: " + e);
    }

    private static void CollectionClearedEventHandler(object sender, EventArgs e)
    {
        Console.WriteLine("Черга очищена.");
    }

    private static void ItemAddedToBeginningEventHandler(object sender, int e)
    {
        Console.WriteLine("Елемент " + e + " додано в початок черги.");
    }

    private static void ItemAddedToEndEventHandler(object sender, int e)
    {
        Console.WriteLine("Елемент " + e + " додано в кінець черги.");
    }
}