// public class Solution {
//     public int NumIslands(char[][] grid) {
//         bool[,] visited = new bool[grid.Length, grid[0].Length];
        
//         int answer = 0;
//         for (int i = 0; i < grid.Length; i++) {
//             for (int j = 0; j < grid[0].Length; j++) {
//                 if (grid[i][j] == '1' && !visited[i, j]) {
//                     dfs(grid, visited, i, j);
//                     answer++;
//                 }
//             }
//         }
        
//         return answer;
//     }
    
//     void dfs(char[][] grid, bool[,] visited, int i, int j) {
//         if (grid[i][j] == '1' && !visited[i, j]) {
//             visited[i, j] = true;

//             if (i < grid.Length - 1) {
//                 dfs(grid, visited, i + 1, j);
//             }

//             if (i >= 1) {
//                 dfs(grid, visited, i - 1, j);
//             }

//             if (j < grid[0].Length - 1) {
//                 dfs(grid, visited, i, j + 1);
//             }

//             if (j >= 1) {
//                 dfs(grid, visited, i, j - 1);
//             }
//         }
//     }
// }