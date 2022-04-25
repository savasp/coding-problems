// public class Solution {
//     public int[] Intersection(int[] nums1, int[] nums2) {
//         var s1 = nums1.OrderBy(n => n).ToArray();
//         var s2 = nums2.OrderBy(n => n).ToArray();
//         var answer = new List<int>();
        
//         for (int i = 0, j = 0; i < s1.Length && j < s2.Length;) {
//             if (s1[i] == s2[j]) {
//                 if (answer.Count == 0 || (answer.Last() != s1[i])) {
//                     answer.Add(s1[i]);
//                 }
//                 i++;
//             } else if (s1[i] > s2[j]) {
//                 j++;
//             } else {
//                 i++;
//             }
//         }
//         return answer.ToArray();
//     }
// }