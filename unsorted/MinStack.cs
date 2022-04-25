// public class MinStack {
//     class Item {
//         public int Value { get; set; }
//         public int MinValue { get; set; }
//         public Item Next { get; set; }
//     }
    
//     private Item head = null;
    
//     public MinStack() {
        
//     }
    
//     public void Push(int val) {
//         var newItem = new Item { Value = val };
        
//         if (head == null) { 
//             head = newItem;
//             head.MinValue = val;
//         } else {
//             newItem.Next = head;
//             newItem.MinValue = Math.Min(head.MinValue, val);
//             head = newItem;
//         }
//     }
    
//     public void Pop() {
//         if (head != null) {
//             head = head.Next;
//         }
//     }
    
//     public int Top() {
//         return head.Value;
//     }
    
//     public int GetMin() {
//         return head.MinValue;
//     }
// }

// /**
//  * Your MinStack object will be instantiated and called as such:
//  * MinStack obj = new MinStack();
//  * obj.Push(val);
//  * obj.Pop();
//  * int param_3 = obj.Top();
//  * int param_4 = obj.GetMin();
//  */