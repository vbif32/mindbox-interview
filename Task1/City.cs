namespace Task1
{
    public partial class City
    {
        private readonly string _name;

        private City(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}