using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Tree Construct Problem");

            List<int> A = new List<int> { 7, 5, 6, 2, 3, 1, 4 };
            List<int> B = new List<int> { 5, 6, 3, 1, 4, 2, 7 };

            TreeNode node = buildTree(A, B);

            Console.Read();
        }
        public static TreeNode buildTree(List<int> A, List<int> B)
        {

            if (A == null || B == null || A.Count == 0 || B.Count == 0 || A.Count != B.Count)
            {
                return null;
            }

            if (A.Count == 1 && B.Count == 1)
            {
                TreeNode node = new TreeNode(A[0]);
                node.left = null;
                node.right = null;
                return node;
            }

            TreeNode result = Construct(A, B, 0, A.Count - 1, 0, B.Count - 1);
            return result;
        }
        public static TreeNode Construct(List<int> inList, List<int> postList, int inSrt, int inEnd, int psSrt, int psEnd)
        {
            if (inSrt > inEnd)
            {
                return null;
            }

            TreeNode rootNode = new TreeNode(postList[psEnd]);          


            //Search root node in Inorder list
            int inRoot = -1;
            for (int i = inSrt; i <= inEnd; i++)
            {
                if (inList[i] == postList[psEnd])
                {
                    inRoot = i;
                    break;
                }
            }

            //Get length of left tree
            int countL = inRoot - inSrt;

          
            rootNode.left = Construct(inList, postList, inSrt, inRoot - 1, psSrt, psSrt + countL - 1);
            rootNode.right = Construct(inList, postList, inRoot + 1, inEnd, psSrt + countL, psEnd - 1);
            

           

            return rootNode;
        }

    }
    class TreeNode
    {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int x) { this.val = x; this.left = this.right = null; }
    }
}
