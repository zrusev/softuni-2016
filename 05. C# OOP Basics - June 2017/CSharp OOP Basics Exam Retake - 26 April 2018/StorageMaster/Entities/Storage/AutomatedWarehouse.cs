namespace StorageMaster.Entities.Storage
{
    using Entities.Vehicles;
    public class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name) 
            : base(name, capacity: 1, garageSlots: 2, vehicles: new Vehicle[] { new Truck() })
        {
        }
    }
}
