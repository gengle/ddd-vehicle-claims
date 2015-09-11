using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Vehicle : IEquatable<Vehicle>
    {
        public Vehicle(string make = null, string model = null, int? year=null, string vin=null)
        {
            Make = make;
            Model = model;
            Year = year;
            Vin = vin;
        }

        public Vehicle()
        {
            
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Vin { get; set; }
        public static Vehicle Empty { get; } = new Vehicle();

        public bool Equals(Vehicle other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Make, other.Make) 
                   && string.Equals(Model, other.Model) 
                   && Year == other.Year 
                   && string.Equals(Vin, other.Vin);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Vehicle)) return false;
            return Equals((Vehicle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Make?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (Model?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Year.GetHashCode();
                hashCode = (hashCode*397) ^ (Vin?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Vehicle left, Vehicle right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Vehicle left, Vehicle right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"Make: {Make}, Model: {Model}, Year: {Year}, Vin: {Vin}";
        }
    }
}