// public class Solution {
//     public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
//         var merged = new int[nums1.Length + nums2.Length];
        
//         var n = nums1.Length + nums2.Length;
//         int m = 0, k = 0;
//         for (int i = 0; i < n; i++) {
//             if (m < nums1.Length && k < nums2.Length) {
//                 if (nums1[m] < nums2[k]) {
//                     merged[i] = nums1[m++];
//                 } else {
//                     merged[i] = nums2[k++];
//                 }
//             } else {
//                 if (m < nums1.Length) {
//                     merged[i] = nums1[m++];
//                 } else {
//                     merged[i] = nums2[k++];
//                 }
//             }
//         }
        
//         if (n == 1) return merged[0];
//         if ((n % 2) == 0) {
//             return (merged[n / 2 - 1] + merged[n / 2]) / 2.0;
//         } else {
//             return merged[n / 2];
//         }
//     }
// }