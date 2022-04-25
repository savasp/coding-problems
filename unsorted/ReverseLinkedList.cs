// /**
//  * Definition for singly-linked list.
//  * public class ListNode {
//  *     public int val;
//  *     public ListNode next;
//  *     public ListNode(int val=0, ListNode next=null) {
//  *         this.val = val;
//  *         this.next = next;
//  *     }
//  * }
//  */
// public class Solution {
//     public ListNode ReverseList(ListNode node) {
//         ListNode save = null;
//         ListNode previous = null;
//         while (node != null) {
//             save = node.next;
//             node.next = previous;
//             previous = node;
//             node = save;
//         }

//         return previous;
//     }
// }