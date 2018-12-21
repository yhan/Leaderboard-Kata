namespace TDDMicroExercises.LeaderBoard
{
    public class SelfDrivingCar : Driver
    {
        public SelfDrivingCar(string algorithmVersion, string company)
            : base(name: "Self Driving Car - " + company + " (" + algorithmVersion + ")")
        {
        }
    }
}