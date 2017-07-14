namespace Problem_1.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionPerKm;

        private double FuelConsumptionPerKm
        {
            get { return this.fuelConsumptionPerKm; }
            set { this.fuelConsumptionPerKm = value; }
        }

        private double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        private bool Drive(double distance)
        {
            var fuelRequired = distance * this.FuelConsumptionPerKm;
            if (fuelRequired <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelRequired;
                return true;
            }

            return false;
        }

        public string TryTravelDistance(double distance)
        {
            if (this.Drive(distance))
            {
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuelAmount) => this.FuelQuantity += fuelAmount;

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}