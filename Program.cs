using root.Trie;
public class Program
{
    public static void Main(params string[] args)
    {
        var trie = new Trie();

        trie.Insert("cat");
        trie.Insert("cap");
        trie.Insert("dog");
        trie.Insert("Product:123");
        trie.Insert("Product:124");


        trie.Insert("Muhammad:124");
        trie.Insert("Muhammad:125");


        Console.WriteLine("Searching about cat {0}", trie.Search("cat"));

        Console.WriteLine("Searching about prefix product:123 {0}", trie.SearchPrefix("Product:12"));

        trie.PrintTrie();

        trie.RemoveByPrefix("Muhammad");

        trie.PrintTrie();


        

    }
}