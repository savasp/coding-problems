// public class Solution {
//     public int[][] Merge(int[][] intervals) {
//         var sorted = intervals.OrderBy(interval => interval[0]).ToArray();
        
//         var merged = new List<int[]>();
//         merged.Add(sorted[0]);
        
//         for (int i = 1; i < sorted.Length; i++) {
//             if (merged.Last()[1] >= sorted[i][0]) {
//                 merged.Last()[1] = Math.Max(sorted[i][1], merged.Last()[1]);
//             } else {
//                 merged.Add(sorted[i]);
//             }
//         }
        
//         return merged.ToArray();
//     }
// }