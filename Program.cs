namespace Savas.Revision;

// See https://aka.ms/new-console-template for more information

// Exercises
class Program {
    static IEnumerable<IExercise> exercises = new List<IExercise> {
//        new DynamicProgramming.TribonacciExercise(),
//        new DynamicProgramming.MinCostClimbingStairsExercise(),
//        new DynamicProgramming.HouseRobberExercise(),
//        new DataStructures.RluCacheExercise(),
//        new Algorithms.TwoSumExercise(),
//        new Algorithms.LongestSubstringExercise(),
        new Algorithms.RomanToIntegerExercise(),
    };

   static void Main() {
        foreach (var ex in exercises) {
            Console.WriteLine();
            Console.WriteLine(ex.Name);
            Console.WriteLine(new String('-', ex.Name.Length));
            ex.Start();
        }
    }
}

static class Extensions {
    public static String MapToString(this IEnumerable<int> array) => array.Select(i => i + " ").Aggregate((str, i) => (str + i));
}

