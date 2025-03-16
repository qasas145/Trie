using System.Xml.Linq;

namespace root.Trie
{
    public class TrieNode
    {
        public IDictionary<char, TrieNode> Children  = new Dictionary<char, TrieNode>();
        public bool IsEndOfWord = false;
    }
    public class Trie
    {
        private TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }
        // inserting a char 
        public void Insert(string word)
        {
            var node = root;
            foreach(var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.IsEndOfWord = true;
        }


        public TrieNode FindNode(string prefix)
        {
            var node = root;
            foreach (var ch in prefix)
            {
                if (!node.Children.ContainsKey(ch))
                    return null;

                node = node.Children[ch];

            }
            return node;
        }
        public bool Search(string word)
        {
            var node = root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                    return false;

                node = node.Children[ch];

            }
            return node.IsEndOfWord;
        }

        public bool SearchPrefix(string prefix)
        {
            var node = root;
            foreach (var ch in prefix)
            {
                if (!node.Children.ContainsKey(ch))
                    return false;
                node = node.Children[ch];
            }
            return true;
        }

        public void RemoveByPrefix(string prefix)
        {
            var node = FindNode(prefix);
            if (node != null)
            {
                node.Children.Clear();  
                node.IsEndOfWord = false;
            }
        }
        public void PrintTrie()
        {
            PrintTrieHelper(root, "", true, '\0'); 
        }

        private void PrintTrieHelper(TrieNode node, string prefix, bool isLast, char key)
        {
            if (node != root) 
            {
                Console.Write(prefix);
                Console.Write(isLast ? "└── " : "├── ");
                Console.WriteLine(key == '\0' ? "root" : key.ToString()); // طباعة الحرف أو "root" للجذر
                prefix += isLast ? "    " : "│   ";
            }

            var children = node.Children.ToList();
            for (int i = 0; i < children.Count; i++)
            {
                PrintTrieHelper(children[i].Value, prefix, i == children.Count - 1, children[i].Key);
            }
        }

    }
}
