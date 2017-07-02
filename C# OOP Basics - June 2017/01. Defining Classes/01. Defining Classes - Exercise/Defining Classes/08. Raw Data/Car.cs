namespace _08.Raw_Data_1_
{
    class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tires tires;

        public string Model { get => model; set => model = value; }
        internal Engine Engine { get => engine; set => engine = value; }
        internal Cargo Cargo { get => cargo; set => cargo = value; }
        internal Tires Tires { get => tires; set => tires = value; }

        public Car()
        {
            this.Model = model;
            this.Engine = new Engine();
            this.Cargo = new Cargo();
            this.Tires = new Tires();            
        } 

    }
}
