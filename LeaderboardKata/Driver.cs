namespace TDDMicroExercises.LeaderBoard
{
    public class Driver
    {
        public Driver(string name, string country)
        {
            Name = name;
            _country = country;
        }

        protected Driver(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }

        private string _country { get; }

        public override int GetHashCode()
        {
            return Name.GetHashCode() * 31 + _country.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (!(obj is Driver))
            {
                return false;
            }

            var other = (Driver)obj;
            return Name.Equals(other.Name) && _country.Equals(other._country);
        }
    }
}