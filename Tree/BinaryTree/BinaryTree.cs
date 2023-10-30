using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tree.BinaryTree
{
    public class BinaryTree<Tdata> where Tdata : IComparable<Tdata>
    {
        TreeNode Root;

        public void Insert(Tdata data)
        {
            TreeNode newNode = new(data);
            if(Root == null)
            {
                Root = newNode;
                return;
            }

            Queue.Queue<TreeNode> queue = new ();

            queue.enqueue(Root);
            while (queue.hasData())
            {
                TreeNode Current = queue.dequeue();

                if(Current.Left == null)
                {
                    Current.Left = newNode;
                    break;
                }
                else queue.enqueue(Current.Left);

                if(Current.Right == null)
                {
                    Current.Right = newNode;
                    break;
                }
                else queue.enqueue (Current.Right);
            }
        }

        public int Height()
        {
            return InternalHeight(Root);
        }

        public int InternalHeight(TreeNode node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(InternalHeight(node.Left), InternalHeight(node.Right));
        }

        public void PreOrder()
        {
            InternalPreOrder(Root);
            Console.WriteLine();
        }

        public void InternalPreOrder(TreeNode node)
        {
            if(node == null) return;
            Console.Write(node.Data+" -> ");
            InternalPreOrder(node.Left);
            InternalPreOrder(node.Right);
        }

        public void InOrder()
        {
            InternalInOrder(Root);
            Console.WriteLine();
        }

        public void InternalInOrder(TreeNode node)
        {
            if (node == null) return;
            InternalInOrder(node.Left);
            Console.Write(node.Data + " -> ");
            InternalInOrder(node.Right);
        }

        public void PostOrder()
        {
            InternalPostOrder(Root);
            Console.WriteLine();
        }

        public void InternalPostOrder(TreeNode node)
        {
            if (node == null) return;
            InternalPostOrder(node.Left);
            InternalPostOrder(node.Right);
            Console.Write(node.Data + " -> ");
        }

        public TreeNode Find(Tdata data)
        {
            bool found = false;
            TreeNode result = InternalFind(Root, data, ref found);
            if (!found)
            {
                Console.WriteLine("Node Does not Exist");
            }
            return result;
        }

        private TreeNode InternalFind(TreeNode node, Tdata data, ref bool found)
        {
            if (node == null || found)
            {
                return null;
            }

            if (node.Data.CompareTo(data) == 0)
            {
                Console.WriteLine($"Node {node.Data} Exists");
                found = true;
                return node;
            }

            TreeNode leftResult = InternalFind(node.Left, data, ref found);
            if (leftResult != null)
            {
                return leftResult;
            }

            TreeNode rightResult = InternalFind(node.Right, data, ref found);
            if (rightResult != null)
            {
                return rightResult;
            }

            return null;
        }      

        public class TreeNode
        {
            public Tdata Data;
            public TreeNode Left;
            public TreeNode Right;
            public TreeNode(Tdata data) 
            { 
                Data = data;
            }
        }

        #region Printer
        class NodeInfo
        {
            public TreeNode Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }
        public void Print(int topMargin = 2, int leftMargin = 2)
        {
            if (this.Root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = this.Root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.Data.ToString() };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                    }
                }
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos;
                        else
                            item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private void Print(NodeInfo item, int top)
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
                PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }

        private void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }

        private void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
        #endregion
    }
}
