// public class Solution {
//     public int FirstUniqChar(string s) {
//         var map = new Dictionary<char, int>();
        
//         foreach (char c in s) {
//             if (!map.ContainsKey(c)) {
//                 map.Add(c, 1);
//             } else {
//                 map[c] += 1;
//             }
//         }

//         for (int i = 0; i < s.Length; i++) {
//             if (map[s[i]] == 1) {
//                 return i;
//             }
//         }
        
//         return -1;
//     }
// }