// public class Solution {
//     static Dictionary<char, string[]> map = new Dictionary<char, string[]> {
//         { '2', new string[] { "a", "b", "c" } },
//         { '3', new string[] { "d", "e", "f" } },
//         { '4', new string[] { "g", "h", "i" } },
//         { '5', new string[] { "j", "k", "l" } },
//         { '6', new string[] { "m", "n", "o" } },
//         { '7', new string[] { "p", "q", "r", "s" } },
//         { '8', new string[] { "t", "u", "v" } },
//         { '9', new string[] { "w", "x", "y", "z" } },
//     };
    
//     public IList<string> LetterCombinations(string digits) {
//         if (digits.Length == 0) return new string[] {};
        
//         return letterCombinations(digits).ToList();         
//     }
    
//     IEnumerable<string> letterCombinations(string digits) {
//         var answer = new List<string>();
//         if (digits.Length == 1) {
//             answer.AddRange(map[digits[0]]);
//             return answer;
//         }

//         foreach (var str in letterCombinations(digits.Substring(1)))
//             for (int i = 0; i < map[digits[0]].Length; i++) {
//                 answer.Add(map[digits[0]][i] + str);
//             }
        
//         return answer;
//     }
// }