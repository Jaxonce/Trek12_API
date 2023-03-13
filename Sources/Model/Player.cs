namespace Model;
//public class Player : IEquatable<Player>
    public class Player
{
    public string Pseudo
    {
        get => pseudo;
        set
        {
            if (value == null)
            {
                pseudo = "";
                return;
            }
            pseudo = value;
        }
    }
    private string pseudo = "";

    public Stats Stats { get; set; }

    public Player(string pseudo)
    {
        Pseudo = pseudo;
        Stats = new Stats();
    }

    public Player(string pseudo, Stats stats)
    {
        Pseudo = pseudo;
        Stats = stats;
    }

    //nécessaire ?
    //public bool Equals(Player? other)
    //        => Pseudo.Equals(other?.Pseudo);

    //997 ou un autre chiffre, à voir
    //public override int GetHashCode()
    //    => Pseudo.GetHashCode() % 997;

    //public override string ToString()
    //    => $"{Pseudo}";
}

