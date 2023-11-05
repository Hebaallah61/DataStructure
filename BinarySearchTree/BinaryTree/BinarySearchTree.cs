using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BinarySearchTree.BinarySearchTree
{
    public class BinarySearchTree<Tdata> where Tdata : IComparable<Tdata>
    {
        public TreeNode Root;

        public void Balance()
        {
            List<Tdata> list = new();
            InOrderToArray(Root, list);
            Root = RecursiveBalance(0, list.Count-1, list);
        }

        void InOrderToArray(TreeNode node, List<Tdata> list)
        {
            if (node == null) return;
            InOrderToArray(node.Left, list);
            list.Add(node.Data);
            InOrderToArray(node.Right,list);
        }

        TreeNode RecursiveBalance(int start, int end, List<Tdata> list)
        {
            if (start > end) return null;
            int mid= (start+end)/2;
            TreeNode newNode = new(list[mid]);
            newNode.Left=RecursiveBalance(start,mid-1,list);
            newNode.Right=RecursiveBalance(mid+1,end,list);
            return newNode;
        }

        public void BSDuplicateCountInsert(Tdata data)
        {
            TreeNode node= BSFind(data);
            if (node!=null)
            {
                node.Count++;
                Console.WriteLine($"Count of {data} in the BST is: {node.Count}");
                return;
            }
            SimpleInsert(data);
        }

        public void BSInsert(Tdata data, bool IsDuplicate=true)
        {
            if (IsDuplicate == false)
            {
                bool exist = IsExsit(data);
                if (exist)
                {
                    Console.WriteLine($"Already {data} Exists");
                    return;
                }
            }
            SimpleInsert(data);
        }

        public void SimpleInsert(Tdata data)
        {
            TreeNode newNode = new(data);
            if (Root == null)
            {
                Root = newNode;
                return;
            }
            TreeNode CurrentNode = Root;
            while (CurrentNode != null)
            {
                if (data.CompareTo(CurrentNode.Data) < 0)
                {
                    if (CurrentNode.Left == null)
                    {
                        CurrentNode.Left = newNode;
                        break;
                    }
                    else CurrentNode = CurrentNode.Left;
                }
                else
                {
                    if (CurrentNode.Right == null)
                    {
                        CurrentNode.Right = newNode;
                        break;
                    }
                    else CurrentNode = CurrentNode.Right;
                }
            }
        }

        public TreeNode BSFind(Tdata data)
        {
            TreeNode CurrentNode = Root;
            while (CurrentNode != null)
            {
                if (data.CompareTo(CurrentNode.Data) == 0)
                {
                    return CurrentNode;
                }
                else if (data.CompareTo(CurrentNode.Data) < 0)
                {
                    CurrentNode = CurrentNode.Left;
                }
                else if (data.CompareTo(CurrentNode.Data) > 0)
                {
                    CurrentNode = CurrentNode.Right;
                }
            }
            return null;
        }

        public bool IsExsit(Tdata _data)
        {
            return BSFind(_data) != null;
        }

        public void BsDelete(Tdata data)
        {
            NodeAndParent nodeInfo = BSFindNodeAndItsParent(data);
            if(nodeInfo.Node==null) return;
            if (nodeInfo.Node.Left != null && nodeInfo.Node.Right != null) BSDeleteHasChilds(nodeInfo.Node);
            else if (nodeInfo.Node.Left != null ^ nodeInfo.Node.Right != null) BSDeleteHasOneChild(nodeInfo.Node);
            else BSDeleteLeaf(nodeInfo);
        }

        public NodeAndParent BSFindNodeAndItsParent(Tdata data)
        {
            TreeNode CurrentNode = Root;
            TreeNode Parent = null;
            NodeAndParent Info= null;
            bool left=false;

            while (CurrentNode != null)
            {
                if (data.CompareTo(CurrentNode.Data) == 0)
                {
                    Info= new() { Node= CurrentNode, Parent=Parent, isLeft=left };
                    break;
                }
                else if (data.CompareTo(CurrentNode.Data) < 0)
                {
                    Parent = CurrentNode;
                    left = true;
                    CurrentNode = CurrentNode.Left;
                }
                else if (data.CompareTo(CurrentNode.Data) > 0)
                {
                    Parent = CurrentNode;
                    left= false;
                    CurrentNode = CurrentNode.Right;
                }
            }
            return Info;
        }

        void BSDeleteLeaf(NodeAndParent nodeAndParentInfo)
        {
            if (nodeAndParentInfo.Parent == null) 
            {
                Root = null;
            }
            else
            {
                if(nodeAndParentInfo.isLeft)
                {
                    nodeAndParentInfo.Parent.Left = null;
                }
                else
                {
                    nodeAndParentInfo.Parent.Right = null;
                }
            }
        }

        void BSDeleteHasOneChild(TreeNode nodeToDelete)
        {
            TreeNode nodeToReplace = null;
            if (nodeToDelete.Left != null)
            {
                nodeToReplace= nodeToDelete.Left;
            }
            else
            {
                nodeToReplace= nodeToDelete.Right;
            }
            nodeToDelete.Data = nodeToReplace.Data;
            nodeToDelete.Left=nodeToReplace.Left;
            nodeToDelete.Right= nodeToReplace.Right;
        }

        void BSDeleteHasChilds(TreeNode nodeToDelete)
        {
            TreeNode currentNode = nodeToDelete.Right;
            TreeNode parent = null;
            while(currentNode.Left != null)
            {
                parent= currentNode;
                currentNode= currentNode.Left;
            }
            if(parent != null)
            {
                parent.Left = currentNode.Right;
            }
            else
            {
                nodeToDelete.Right=currentNode.Right;
            }
            nodeToDelete.Data= currentNode.Data;
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
            if (node == null) return;
            Console.Write(node.Data + " -> ");
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


        public class TreeNode
        {
            public Tdata Data;
            public int Count=1;
            public TreeNode Left;
            public TreeNode Right;
            public TreeNode(Tdata data) 
            { 
                Data = data;
            }
        }
        public class NodeAndParent
        {
            public TreeNode Node;
            public TreeNode Parent;
            public bool isLeft;
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
