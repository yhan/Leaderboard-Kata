namespace TDDMicroExercises.LeaderBoard
{
    public class SelfDrivingCar : Driver
    {
        public SelfDrivingCar(string algorithmVersion, string company)
            : base(null, company)
        {
            AlgorithmVersion = algorithmVersion;
            Name = "Self Driving Car - " + Country + " (" + AlgorithmVersion + ")";
        }

        public string AlgorithmVersion { get; set; }
    }
}