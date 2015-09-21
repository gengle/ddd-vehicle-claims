using System;
using Application.Services;
using Core;
using Domain;

namespace Application.Messaging.Commands
{
    public class AssignVehicleCommand : ICommand
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Vin { get; set; }

        public AssignVehicleCommand(string id, string make = null, string model = null, int? year = null, string vin = null)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Vin = vin;
        }

        public AssignVehicleCommand()
        {
        }

        public static AssignVehicleCommand WithId(Guid id)
        {
            return new AssignVehicleCommand(id.ToString());
        }
        public AssignVehicleCommand WithMake(string value)
        {
            return new AssignVehicleCommand(this.Id, make: value, model: this.Model, year: this.Year, vin: this.Vin);
        }

        public AssignVehicleCommand WithModel(string value)
        {
            return new AssignVehicleCommand(this.Id, make: this.Make, model: value, year: this.Year, vin: this.Vin);
        }

        public AssignVehicleCommand WithYear(string value)
        {
            var year = 0;
            if (int.TryParse(value, out year))
            {
                return this.WithYear(year);
            }
            return this;
        }

        public AssignVehicleCommand WithYear(int? value)
        {
            return new AssignVehicleCommand(this.Id, make: this.Make, model: this.Model, year: value, vin: this.Vin);
        }

        public AssignVehicleCommand WithVin(string value)
        {
            return new AssignVehicleCommand(this.Id, make: this.Make, model: this.Model, year: this.Year, vin: value);
        }
    }
}