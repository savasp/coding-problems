namespace Savas.Revision.AlgoExpert;

using System.Collections.Generic;
using System.Linq;
using Xunit;

public class TopologicalSort {

    // Given a set of jobs and their dependencies,
    // return the order of the jobs.
    // If there is a cycle in the dependencies, return an empty list.
    // We assume that the input is valid so we aren't checking
    // whether the dependencies list refers to valid jobs.
    // dependency pair [j1, j2]: j1 <= depends on <= j2.
	public static List<int> Sort(List<int> jobs, List<int[]> dependencies) {
        var jobsMap = new Dictionary<int, Job>();
        foreach (var j in jobs) {
            jobsMap.Add(j, new Job { Id = j });
        }

        foreach (var d in dependencies) {
            jobsMap[d[1]].Dependencies.Add(jobsMap[d[0]]);
        }
        
        var answer = new List<int>();
        foreach(var j in jobsMap.Values)
        {
            var cycle = dfs(j, answer);
            if (cycle) {
                return new List<int>();
            }
        }

        return answer;
	}

    private static bool dfs(Job job, List<int> answer)
    {
        if (job.Visiting)
        {
            return true;
        }

        job.Visiting = true;

        // Go only through the nodes the jobs that haven't already
        // been added in the answer
        foreach (var j in job.Dependencies.Where(jj => !jj.Added))
        {
            if (dfs(j, answer)) {
                return true;
            };
        }

        if (!job.Added) {
            job.Added = true;
            answer.Add(job.Id);
        }

        job.Visiting = false;

        return false;
    }

    private class Job {
        public int Id;
        public List<Job> Dependencies = new List<Job>();
        
        public bool Visiting = false;
        public bool Added = false;
    }
}

/// --- Test infrastructure and test cases
/// 

public class TopologicalSortTests
{
    public static IEnumerable<object[]> Data => new List<object[]> {
        new object[] { 
            new List<int> {1, 2, 3, 4}, 
            new List<int[]> { new int[] {1, 2}, new int[] {1, 3}, new int[] {3, 2}, new int[] {4, 2}, new int[] {4, 3} },
            new List<int[]> { new int[] { 1, 4, 3, 2 }, new int[] { 4, 1, 3, 2} }
        },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void TopologicalSortTest(List<int> jobs, List<int[]> dependencies, List<int[]> expected) {
        var answer = TopologicalSort.Sort(jobs, dependencies);

foreach(var j in answer) {
    Console.Write(j + " ");
}

        Assert.True(expected.Contains(answer.ToArray(), new ArrayComparer()));
    }

    private class ArrayComparer : IEqualityComparer<int[]> {
        public bool Equals(int[] a1, int[] a2) => a1.SequenceEqual(a2);
        public int GetHashCode(int[] a) => a.GetHashCode();
    }
}