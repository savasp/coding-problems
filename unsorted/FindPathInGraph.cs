// public class Solution {
//     public bool ValidPath(int n, int[][] edges, int source, int destination) {
//         var adjacencies = new Dictionary<int, List<int>>();
//         var visited = new bool[n];

//         for (int i = 0; i < n; i++) {
//             adjacencies.Add(i, new List<int>());
//             visited[i] = false;
//         }
        
//         foreach (var e in edges) {
//             adjacencies[e[0]].Add(e[1]);
//             adjacencies[e[1]].Add(e[0]);
//         }
        
//         return dfs(source, destination, adjacencies, visited);
//     }
    
//     bool dfs(int node, int destination, Dictionary<int, List<int>> adjastencies, bool[] visited) {
//         if (visited[node]) return false;
//         visited[node] = true;
//         if (node == destination) return true;
        
//         foreach (var e in adjastencies[node]) {
//             if (dfs(e, destination, adjastencies, visited)) return true;
//         }
        
//         return false;
//     }
// }