using Border_Control.Interfaces;

namespace Border_Control
{
    public class Robot : ICitizen, IRobort
    {
        public Robot(string id, string model)
        {
            this.Id = id;
            this.Model = model;
        }

        public string Id { get; private set; }

        public string Model { get; private set; }
    }
}