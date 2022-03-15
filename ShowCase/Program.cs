using DoublyLinkedListLibrary;

class Program
{
    static void Main(string[] args)
    {
        var newList = new DoublyLinkedList();

        newList.Push("First item");
        newList.Push("Second item");
        newList.Push("Third item");
        newList.Push("Fourth item");
        newList.Push("Fifth item");
        newList.Push("Sixth item");
        newList.Push("Seventh item");
        newList.Push("Eighth item");
        newList.Push("Ninth item");
        newList.Shift("Before first");
        
        Console.WriteLine($"Length: {newList.length}\n");

        newList.PrintList();

        Console.WriteLine("Sliced List");
    }
}