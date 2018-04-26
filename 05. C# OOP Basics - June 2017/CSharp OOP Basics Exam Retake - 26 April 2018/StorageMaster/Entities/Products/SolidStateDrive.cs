namespace StorageMaster.Entities.Products
{
    public class SolidStateDrive : Product
    {
        public SolidStateDrive(double price) 
            : base(price, weight: 0.2)
        {
        }
    }
}
