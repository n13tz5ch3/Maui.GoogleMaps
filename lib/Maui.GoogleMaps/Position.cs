
namespace Maui.GoogleMaps
{
    public struct Position(double latitude, double longitude)
    {
        public double Latitude { get; } = Math.Min(Math.Max(latitude, -90.0), 90.0);

        public double Longitude { get; } = Math.Min(Math.Max(longitude, -180.0), 180.0);

        public override bool Equals(object? obj)
        {
            if (obj is not Position other)
                return false;
            return (decimal)Latitude == (decimal)other.Latitude && (decimal)Longitude == (decimal)other.Longitude;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Latitude.GetHashCode();
                hashCode = (hashCode * 397) ^ Longitude.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Position left, Position right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !Equals(left, right);
        }

        public static Position operator -(Position left, Position right)
        {
            return new Position(left.Latitude - right.Latitude, left.Longitude - right.Longitude);
        }
    }
}