namespace TableTopCalculator
{
    public class Player
    {
        public string Name { get; set; }
        // ReSharper disable once InconsistentNaming
        public int ID { get; set; }

        public Player(int id, string name)
        {
            Name = name;
            ID = id;
        }
    }
}
