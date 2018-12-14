namespace TDDMicroExercises.LeaderBoard
{
    using System.Collections.Generic;

    public class Race
    {
        private static readonly int[] Points =
            {
                25,
                18,
                15
            };

        private readonly string _name;

        public Race(string name, params Driver[] drivers)
        {
            _name = name;
            Results = new List<Driver>();
            Results.AddRange(drivers);
        }

        public List<Driver> Results { get; }

        public int Position(Driver driver)
        {
            return Results.FindIndex(d => Equals(d, driver));
        }

        public int GetPoints(Driver driver)
        {
            return Points[Position(driver)];
        }

        public override string ToString()
        {
            return _name;
        }
    }
}