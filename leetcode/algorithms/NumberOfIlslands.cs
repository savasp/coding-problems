namespace Savas.Revision.Algorithms;

using Xunit;

/// <summary>
/// The given matrix indicates lands with '1' and water with '0'.
/// The problem is to identify the islands (i.e., sourounded by sea).
/// the edges of the matrix are assumed to be sea.
/// The input is assumed to be valid.
/// <summary>
public class NumberOfIslands {
    public static int NumIslands(char[][] grid) {
        bool[,] visited = new bool[grid.Length, grid[0].Length];
        
        int answer = 0;
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                if (grid[i][j] == '1' && !visited[i, j]) {
                    Dfs(grid, visited, i, j);
                    answer++;
                }
            }
        }
        
        return answer;
    }
    
    private static void Dfs(char[][] grid, bool[,] visited, int i, int j) {
        if (grid[i][j] == '1' && !visited[i, j]) {
            visited[i, j] = true;

            if (i < grid.Length - 1) {
                Dfs(grid, visited, i + 1, j);
            }

            if (i >= 1) {
                Dfs(grid, visited, i - 1, j);
            }

            if (j < grid[0].Length - 1) {
                Dfs(grid, visited, i, j + 1);
            }

            if (j >= 1) {
                Dfs(grid, visited, i, j - 1);
            }
        }
    }
}


/// --- Test infrastructure and test cases
///

public class NumberOfIslandsTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] {
            new int[][] {
                new int[] { 1 }
            },
            1
        },
        new object[] {
            new int[][] {
                new int[] { 0 }
            },
            0
        },
        new object[] {
            new int[][] {
                new int[] { 1, 0, 0 },
                new int[] { 0, 0, 1 },
            },
            2
        },
        new object[] {
            new int[][] {
                new int[] { 1, 1, 0 },
                new int[] { 1, 0, 1 },
            },
            2
        },
        new object[] {
            new int[][] {
                new int[] { 1, 1, 1 },
                new int[] { 1, 0, 1 },
            },
            1
        },
        new object[] {
            new int[][] {
                new int[] { 0, 0, 0 },
                new int[] { 1, 0, 1 },
                new int[] { 0, 0, 0 },
            },
            2
        },
        new object[] {
            new int[][] {
                new int[] { 0, 0, 0 },
                new int[] { 1, 1, 1 },
                new int[] { 0, 0, 0 },
            },
            1
        },
        new object[] {
            new int[][] {
                new int[] { 0, 0, 0 },
                new int[] { 0, 1, 0 },
                new int[] { 0, 0, 0 },
            },
            1
        },
        new object[] {
            new int[][] {
                new int[] { 1, 0, 1 },
                new int[] { 0, 0, 0 },
                new int[] { 1, 0, 1 },
            },
            4
        },
        new object[] {
            new int[][] {
                new int[] { 1, 0, 1 },
                new int[] { 1, 0, 0 },
                new int[] { 1, 0, 1 },
            },
            3
        },
        new object[] {
            new int[][] {
                new int[] { 1, 0, 1 },
                new int[] { 1, 1, 0 },
                new int[] { 1, 0, 1 },
            },
            3
        },
        new object[] {
            new int[][] {
                new int[] { 1, 1, 1 },
                new int[] { 1, 1, 0 },
                new int[] { 1, 0, 1 },
            },
            2
        },
        new object[] {
            new int[][] {
                new int[] { 1, 1, 1 },
                new int[] { 0, 1, 0 },
                new int[] { 1, 1, 1 },
            },
            1
        },
        new object[] {
            new int[][] {
                new int[] { 1, 1, 1 },
                new int[] { 1, 0, 1 },
                new int[] { 1, 1, 1 },
            },
            1
        },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void NumberOfIslandsTest(int[][] grid, int expected)
    {
        var gridchar = new char[grid.Length][];
        for (int m = 0; m < grid.Length; m++)
        {
            gridchar[m] = new char[grid[m].Length];
            for (int n = 0; n < grid[m].Length; n++)
            {
                gridchar[m][n] = grid[m][n] == 0 ? '0' : '1';
            }
        }

        var answer = NumberOfIslands.NumIslands(gridchar);

        Assert.Equal(expected, answer);
    }
}