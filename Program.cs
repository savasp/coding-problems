// See https://aka.ms/new-console-template for more information

// Exercises
IEnumerable<IExercise> exercises = new List<IExercise> {
    new Tribonacci(),
//    new MinCostClimbingStairs(),
//    new HouseRobber(),
};

foreach (var ex in exercises) {
    Console.WriteLine(ex.Name);
    Console.WriteLine(new String('-', ex.Name.Length));
    ex.Start();
}