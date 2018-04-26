namespace StorageMaster.Entities.Storage
{
    using Entities.Vehicles;
    public class DistributionCenter : Storage
    {
        public DistributionCenter(string name) 
            : base(name, capacity: 2, garageSlots: 5, vehicles: new Vehicle[] { new Van(), new Van(), new Van() })
        {
        }
    }
}
