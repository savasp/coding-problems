namespace Savas.Revision.DynamicProgramming;

using static System.Console;

public class TribonacciExercise : IExercise {
struct Test {
    public int n;
    public int expected;
}

    public String Name => "Tribonacci sequence";
    public void Start() {
        var tests = new Test[] {
            new Test { n = 4, expected = 4},
            new Test { n = 25, expected = 1389537},
        };

        WriteLine("Tribonacci sequence");

        var i = 0;
        foreach (var test in tests) {
            var str = $"Test case {i++}";
            WriteLine();
            WriteLine(str);
            WriteLine(new String('.', str.Length));

            var trib = tribonacci(test.n);
            WriteLine($"Tribonacci of {test.n} = {trib}.");
            WriteLine(trib != test.expected ? "Failed!!!" : "Passed!");

        }
    }

    int tribonacci(int n) {
        if (n == 0) return 0;
        if (n == 1 || n == 2) return 1;

        int nm1 = 1;
        int nm2 = 1;
        int nm3 = 0;
        int t = 0;

        for (int i = 3; i <= n; i++) {
            t = nm1 + nm2 + nm3;
            nm3 = nm2;
            nm2 = nm1;
            nm1 = t;
        }

        return t;
    }
}
