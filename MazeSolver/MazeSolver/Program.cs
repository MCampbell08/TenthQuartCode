namespace MazeSolver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SolveMaze solveMaze = new SolveMaze();
            solveMaze.ReadFile();
            solveMaze.Solve();
        }    
    }
}
