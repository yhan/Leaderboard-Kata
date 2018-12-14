namespace TDDMicroExercises.LeaderBoard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NFluent;

    using NUnit.Framework;

    public class Leaderboard
    {
        private readonly List<Race> _races = new List<Race>();

        public Leaderboard(params Race[] races)
        {
            if (races.Any(x => x.Results.Count > 3))
            {
                throw new ArgumentException("Too many drivers");
            }

            _races.AddRange(races);
        }

        public Dictionary<string, int> DriverResults()
        {
            var results = new Dictionary<string, int>();
            foreach (var race in _races)
            {
                foreach (var driver in race.Results)
                {
                    var points = race.GetPoints(driver);
                    if (results.ContainsKey(driver.Name))
                    {
                        results[driver.Name] = results[driver.Name] + points;
                    }
                    else
                    {
                        results.Add(driver.Name, 0 + points);
                    }
                }
            }

            return results;
        }

        public List<string> DriverRankings()
        {
            Dictionary<string, int> results = DriverResults();
            return results.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();
        }
    }

    [TestFixture]
    public class LeaderboardShould
    {
        [Test]
        public void Returns_the_correct_results_When_we_had_one_race_with_standard_driver()
        {
            var leaderboard = new Leaderboard(new Race("race round 1", new Driver("Yi", "China"), new Driver("Seb", "France")));
            var rankings = leaderboard.DriverRankings();

            Check.That(rankings).ContainsExactly("Yi", "Seb");
        }

        [Test]
        public void Returns_the_correct_results_When_we_had_2_races_with_standard_driver()
        {
            var leaderboard = new Leaderboard(new Race("race round 1", new Driver("Yi", "China"), new Driver("Seb", "France")), new Race("race round 1", new Driver("Yi", "China"), new Driver("Seb", "France")));
            var rankings = leaderboard.DriverRankings();

            Check.That(rankings).ContainsExactly("Yi", "Seb");
        }

        [Test]
        public void Returns_the_correct_results_When_we_had_one_race_with_one_sef_driving_car()
        {
            var leaderboard = new Leaderboard(new Race("race round 1", new SelfDrivingCar(algorithmVersion: "Algo", company: "La française"), new Driver("Seb", "France")));
            var rankings = leaderboard.DriverRankings();

            Check.That(rankings).ContainsExactly("Self Driving Car - La française (Algo)", "Seb");
        }

        [Test]
        public void Returns_the_correct_results_When_we_had_2_races_with_one_sef_driving_car()
        {
            var leaderboard = new Leaderboard(new Race("race round 1", new SelfDrivingCar("Algo", "La française"), new Driver("Seb", "France")), new Race("race round 1", new SelfDrivingCar("Algo", "La française"), new Driver("Seb", "France")));
            var rankings = leaderboard.DriverRankings();

            Check.That(rankings).ContainsExactly("Self Driving Car - La française (Algo)", "Seb");
        }

        [Test]
        public void ThrowException_number_of_driver_exceed_3()
        {
            var drivers = new[]
                              {
                                  new Driver("Driver 1", "La française"),
                                  new Driver("Driver 2", "France"),
                                  new Driver("Driver 3", "France"),
                                  new Driver("Driver 4", "France")
                              };

            Check.ThatCode(() => new Leaderboard(new Race("race round 1", drivers))).Throws<ArgumentException>().WithMessage("Too many drivers");
        }
    }
}