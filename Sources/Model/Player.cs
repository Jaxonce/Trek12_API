namespace Model;
public class Player : IEquatable<Player>
{

    public int Id { get; set; }
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

    public Player(string pseudo, int id)
    {
        Pseudo = pseudo;
        Id = id;
        Stats = new Stats();
    }

    public Player(string pseudo, Stats stats, int id=0)
    {
        Pseudo = pseudo;
        Stats = stats;
        Id = id;
    }

    public void AddWin()
    {
        Stats.NbWin += 1;
    }

    public void AddPlayed()
    {
        Stats.NbPlayed += 1;
    }

    public void AddMaxChain(int maxChain)
    {
        Stats.MaxChain = maxChain;
    }

    public void AddMaxZone(int maxZone)
    {
        Stats.MaxZone = maxZone;
    }

    public void AddMaxPoints(int maxPts)
    {
        Stats.MaxPoints = maxPts;
    }

    public bool Equals(Player? other)
            => Pseudo.ToLower().Equals(other?.Pseudo.ToLower());

    //997 ou un autre chiffre, à voir
    public override int GetHashCode()
        => Pseudo.GetHashCode() % 997;

    public override string ToString()
        => $"{Pseudo}";
}

