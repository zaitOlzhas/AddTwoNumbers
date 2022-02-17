using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbers
{
    class Program
    {
        ///https://leetcode.com/problems/add-two-numbers/
        /// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. 
        /// Add the two numbers and return the sum as a linked list.
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        ///The number of nodes in each linked list is in the range[1, 100].
        ///0 <= Node.val <= 9
        ///It is guaranteed that the list represents a number that does not have leading zeros.
        static void Main(string[] args)
        {
            var firstArray1 = new int[3] { 2, 4, 3 };
            var secondArray1 = new int[3] { 5, 6, 4 };
            handleProblemCase(firstArray1, secondArray1);

            var firstArray2 = new int[1] { 0 };
            var secondArray2 = new int[1] { 0 };
            handleProblemCase(firstArray2, secondArray2);

            var firstArray3 = new int[7] { 9, 9, 9, 9, 9, 9, 9 };
            var secondArray3 = new int[4] { 9, 9, 9, 9 };
            handleProblemCase(firstArray3, secondArray3);

            var firstArray4 = new int[1] { 9 };
            var secondArray4 = new int[10] { 1, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            handleProblemCase(firstArray4, secondArray4);

            Console.ReadKey();
        }
        private static void handleProblemCase(int[] firstArray, int[] secondArray)
        {
            var problem = new Problem();
            Console.WriteLine("First ListNode: ");
            var node1 = problem.GenerateNode(firstArray);
            Console.WriteLine("\r\nSecond ListNode: ");
            var node2 = problem.GenerateNode(secondArray);
            Console.WriteLine("\r\nCombined ListNode: ");
            var nodeAnswer = problem.AddTwoNumbers(node1, node2);
            Console.WriteLine("\r\n-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
        }
        private class Problem
        {           
            /// <summary>
            /// Generating ListNodes from array
            /// </summary>
            /// <param name="array"></param>
            /// <returns></returns>
            public ListNode GenerateNode(int[] array)
            {
                Console.Write(array[0]);
                if (array.Length == 1)
                    return new ListNode(array[0]);
                else
                    return new ListNode(array[0], GenerateNode(SubArray(array, 1, array.Length - 1)));
            }
            /// <summary>
            /// Method of combining two ListNodes
            /// </summary>
            /// <param name="l1"></param>
            /// <param name="l2"></param>
            /// <returns></returns>
            internal ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {                
                return NodeSum(l1, l2);
            }
            /// <summary>
            /// Recursive method of combining two ListNodes
            /// </summary>
            /// <param name="l1"></param>
            /// <param name="l2"></param>
            /// <param name="mode"></param>
            /// <returns></returns>
            private ListNode NodeSum(ListNode l1 = null, ListNode l2 = null, int mode = 0)
            {
                
                var nodeValue = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + mode;
                Console.Write(nodeValue%10);
                if (l1?.next == null && l2?.next == null && nodeValue < 10)
                {
                    return new ListNode(nodeValue);
                }
                else
                {
                    var nextNode = NodeSum(l1 != null ? l1.next : null, l2 != null ? l2.next : null, nodeValue >= 10 ? 1 : 0);
                    return new ListNode(nodeValue % 10, nextNode);
                }
            }
            /// <summary>
            /// GetRange of array
            /// </summary>
            /// <param name="data"></param>
            /// <param name="index"></param>
            /// <param name="length"></param>
            /// <returns></returns>
            public static int[] SubArray(int[] data, int index, int length)
            {
                int[] result = new int[length];
                Array.Copy(data, index, result, 0, length);
                return result;
            }
        }
        /// <summary>
        /// Class of nodes
        /// </summary>
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
