using Military_Elite.Interfaces;

namespace Military_Elite.Models
{
    public class Mission : IMissions
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public string State { get; private set; }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}