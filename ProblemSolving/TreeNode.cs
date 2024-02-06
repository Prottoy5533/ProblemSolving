using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }




        public int maxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            int left = maxDepth(root.left);
            int right = maxDepth(root.right);
            return Math.Max(left, right) + 1;

        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
                return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var currentLevel = new List<int>();
                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();
                    currentLevel.Add(currentNode.val);
                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }

                result.Add(currentLevel);

            }
            return result;
        }

        public IList<double> AverageOfLevels(TreeNode root)
        {
            var result = new List<double>();
            if (root == null) return result;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                double currentLevelAvg = 0;
                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();
                    currentLevelAvg += currentNode.val;
                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }

                }

                currentLevelAvg = currentLevelAvg / levelSize;
                result.Add(currentLevelAvg);
            }

            return result;
        }

        public TreeNode FindSuccessor(TreeNode root, int key)
        {

            if (root == null) return null;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.left != null)
                {
                    queue.Enqueue(currentNode.left);
                }
                if (currentNode.right != null)
                {
                    queue.Enqueue(currentNode.right);
                }

                if (currentNode.val == key)
                    break;
            }

            return queue.Dequeue();

        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (root == null)
            {
                return result;
            }

            bool zigZag = true; // true: from left to right, false: from right to lefr

            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var currentLevel = new List<int>();
                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();

                    if (zigZag)
                    {
                        currentLevel.Add(currentNode.val);
                    }
                    else
                    {
                        currentLevel.Insert(0, currentNode.val);
                    }

                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }

                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }

                }

                result.Add(currentLevel);
                zigZag = !zigZag;

            }
            return result;

        }

        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                int currentLevelSize = queue.Count;
                var currentLevel = new List<int>();

                for(int i = 0;i < currentLevelSize; i++)
                {
                    var currentNode = queue.Dequeue();
                    currentLevel.Add(currentNode.val);

                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }

                }

                result.Insert(0,currentLevel);

            }


            return result;

        }

        public Node Connect(Node root)
        {
            if (root == null)
                return null;

            var leftMost = root;

            while(leftMost.left != null)
            {
                var current = leftMost;
                while(current != null)
                {
                    current.left.next = current.right;
                    if (current.next != null)
                    {
                        current.right.next = current.next.left;
                    }
                    current = current.next;

                }
                leftMost = leftMost.left;   
                
            }

            return root;

        }

        public IList<int> RightSideView(TreeNode root)
        {

            var result = new List<int>();   
            if (root == null)
                return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int currentLevel = queue.Count;

                for (int i = 0; i < currentLevel; i++)
                {
                    var currentNode = queue.Dequeue();
                   

                    if(currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }

                    if (i == currentLevel - 1)
                        result.Add(currentNode.val);

                }
            }

            return result;

        }

        public bool IsSymmetric(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);

            while(queue.Count>0)
            {
                var left = queue.Dequeue();
                var right = queue.Dequeue();

                if (left == null && right == null)
                    continue;
                if (left == null || right == null)
                    return false;
                if (left.val != right.val)
                    return false;

                queue.Enqueue(left.left);
                queue.Enqueue(right.right);
                queue.Enqueue(left.right);
                queue.Enqueue(right.left);

            }
            return true;
        }

        public bool IsValidBST(TreeNode root)
        {
            if (root.val < root.left.val || root.val > root.right.val)
                return false;

            IsValidBST(root.left);
            IsValidBST(root.right);
            return true;

        }
        int diameter = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            
            Height(root);
            return diameter-1;

        }

        int Height(TreeNode root)
        {
            if(root == null) return 0;

            int leftHeight = Height(root.left);
            int rightHeight = Height(root.right);
            int dia = leftHeight + rightHeight +1;
            diameter = Math.Max(diameter, dia);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public TreeNode InvertTree(TreeNode root)
        {

            if (root == null)
                return null;

            var left = InvertTree(root.left);
            var right = InvertTree(root.right);

            root.left = right;
            root.right = left;

            return root;

        }
    }
}
