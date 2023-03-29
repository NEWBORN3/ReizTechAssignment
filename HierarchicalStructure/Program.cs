using System.Xml.Linq;

namespace HierarchicalStructure
{
    class Branch
    {
        internal List<Branch> branches;

    }

     class Program
    {
        static void Main(string[] args)
        {
            //create the root node first
            Branch root = new Branch();

            //create the first to nodes
            root.branches = new List<Branch>
            {
                new Branch(),
                new Branch(),
            };

            root.branches[0].branches = new List<Branch> { new Branch()}; // add leaf node for the left node

            // add the three nodes for node 3
            root.branches[1].branches = new List<Branch> {
                new Branch(),
                new Branch(),
                new Branch()
            };

            root.branches[1].branches[0].branches = new List<Branch> { new Branch() }; // add leaf node for the left node

            // add the two nodes for the middle node 
            root.branches[1].branches[1].branches = new List<Branch>
            {
                new Branch(),
                new Branch()
            };

            root.branches[1].branches[1].branches[0].branches = new List<Branch> { new Branch() };  // add leaf node for the left node

            Console.WriteLine(Depth(root));
        }

        //Method to Calculate the depth
        public static int Depth(Branch node)
        {
            if (node.branches == null)
            {
                return 1;
            }
            else
            {
                int maxDepth = 0;
                foreach (Branch child in node.branches)
                {
                    int childDepth = Depth(child); // Recursion 
                    if (childDepth > maxDepth)
                    {
                        maxDepth = childDepth;
                    }
                }
                return 1 + maxDepth;
            }
        }
    }
}