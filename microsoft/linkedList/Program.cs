using System;
using System.Collections.Generic;

namespace linkedList
{
    class ListNode
    {
        public int value { get; set; }
        public ListNode next { get; set; } = null;
    }

    class Program
    {
        // static List<ListNode> mergedList = new List<ListNode>();
        // static ListNode root;
        static void Main(string[] args)
        {
            // List<ListNode> listA = new List<ListNode>();
            // List<ListNode> listB = new List<ListNode>();

            // listA.Add(new ListNode { value = 1, sibling = new ListNode { value = 2 } });
            // listB.Add(new ListNode { value = 3, sibling = new ListNode { value = 4 } });

            // var list1 = new ListNode { value = 8, next = new ListNode { value = 9 } };
            // var list2 = new ListNode { value = 3, next = new ListNode { value = 5 } };

            var list1 = new ListNode { value = 1, next = new ListNode { value = 2, next = new ListNode { value = 4} } };
            var list2 = new ListNode { value = 1, next = new ListNode { value = 3, next = new ListNode { value = 4 } } };

            var node = foo(list1, list2);

            // var node = root;
            while (node != null)
            {
                Console.Write($"{node.value} ,");
                node = node.next;
            }

        }

        private static ListNode foo(ListNode nodeA, ListNode nodeB)
        {
            ListNode left = null;
            ListNode right = null;
            ListNode root = (nodeA.value <= nodeB.value) ? nodeA : nodeB;
            ListNode tail = null;
            ListNode preTail = null;

            while (nodeA != null && nodeB != null)
            {
                // save next nodes
                ListNode nodeANext = nodeA.next;
                ListNode nodeBNext = nodeB.next;

                if (nodeA.value <= nodeB.value)
                {
                    left = nodeA;
                    right = nodeB;
                }
                else
                {
                    left = nodeB;
                    right = nodeA;
                }

                // splice nodes together
                left.next = right;

                // add to the merged list
                if (tail?.value > left.value)
                {
                    preTail.next = left;
                    left.next = tail;
                }else if (tail != null){
                    tail.next = left;
                }

                tail = right;
                preTail = left;

                nodeA = nodeANext;
                nodeB = nodeBNext;
            }

            return root;
        }

    }

}
