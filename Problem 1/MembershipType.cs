// Siemens Internship Assignment 2026 - Problem 1: Coffee Shop
// Represents a loyalty program tier (Regular or Gold).
// Regular = 1 point per euro spent, Gold = 2 points per euro spent.
public class MembershipType
{
    private int _tierID;
    private string _tierName;
    private int _pointsMultiplier;

    public int TierID
    {
        get { return _tierID; }
        set { _tierID = value; }
    }

    public string TierName
    {
        get { return _tierName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                _tierName = value;
            }
        }
    }

    public int PointsMultiplier
    {
        get { return _pointsMultiplier; }
        set { _pointsMultiplier = value; }
    }

    public MembershipType(int id, string name, int multiplier)
    {
        this._tierID = id;
        this._tierName = name;
        this._pointsMultiplier = multiplier;
    }
}
