namespace StorageMaster.Entities.Storage
{
    using Entities.Vehicles;
    public class Warehouse : Storage
    {
        public Warehouse(string name) 
            : base(name, capacity: 10, garageSlots: 10, vehicles: new Vehicle[] { new Semi(), new Semi(), new Semi() })
        {
        }
    }
}
