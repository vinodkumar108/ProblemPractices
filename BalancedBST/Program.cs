using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace BalancedBST
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstInput = new List<int> { 90, 228, 245, 290, 397, 471, 572, 649, 688, 710, 823, 829, 830, 859, 932, 939, 962 };
            Solution obj = new Solution();
            TreeNode result = obj.sortedArrayToBST(lstInput);
            Console.Read();
        }
    }
   

// * Definition for binary tree
  class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) {this.val = x; this.left = this.right = null;}
  }
 
class Solution
    {
        public TreeNode sortedArrayToBST(List<int> A)
        {
            return  MakeBalancedTree(A, 0, A.Count - 1);
        }
        public TreeNode MakeBalancedTree(List<int> itemArr , int leftInx,int rightIndex)
        {
            if(leftInx < 0 || leftInx >= rightIndex)
            {
                return null;
            }

            int mid = (rightIndex - leftInx) / 2;

            TreeNode root = new TreeNode(itemArr[mid]);

            root.left = MakeBalancedTree(itemArr, leftInx, mid - 1);
            root.right = MakeBalancedTree(itemArr, mid+1, rightIndex);

            return root;
        }
    }
}
