namespace StorageMaster.Entities.Storage
{
    using Entities.Products;
    using Entities.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public abstract class Storage
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        private int capacity; //maximum weight of products the storage can handle
        public int Capacity 
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        private int garageSlots;
        public int GarageSlots
        {
            get
            {
                return this.garageSlots;
            }
            private set
            {
                this.garageSlots = value;
            }
        }

        private readonly Vehicle[] garage;
        public IReadOnlyCollection<Vehicle> Garage
        {
            get
            {
                return this.garage.ToList().AsReadOnly();
            }
        }

        public readonly List<Product> products;
        public IReadOnlyCollection<Product> Products
        {
            get
            {
                return this.products.AsReadOnly();
            }
        }

        private Storage()
        {
            this.products = new List<Product>();
        }

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
            :this()
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.garage = new Vehicle[this.GarageSlots];
            var tempVehicles = vehicles.Cast<Vehicle>().ToArray();

            Array.Copy(tempVehicles, this.garage, tempVehicles.Length);

        }

        public bool IsFull => this.products.Select(w => w.Weight).Sum() >= this.Capacity;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            else if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return this.garage[garageSlot];
        }


        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle currentVehicle = this.GetVehicle(garageSlot);

            if (!deliveryLocation.garage.Any(g => g == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            int newSlotIndex = deliveryLocation.garage.Select((veh, ind) => new { veh, ind })
                                    .Where(v => v.veh == null)
                                    .Select(i => i.ind)
                                    .FirstOrDefault();

            this.garage[garageSlot] = null;

            deliveryLocation.garage[newSlotIndex] = currentVehicle;

            return newSlotIndex;
        }
        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle currentVehicle = this.GetVehicle(garageSlot);

            int productCounter = default(int);
            while (!this.IsFull && !currentVehicle.IsEmpty)
            {
                this.products.Add(currentVehicle.Unload());

                productCounter++;
            }

            return productCounter;
        }
    }
}
