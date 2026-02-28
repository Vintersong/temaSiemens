// Siemens Internship Assignment 2026 - Problem 1: Coffee Shop
// Typed category for the three offered beverages (replaces a free-text field).
public enum BeverageType
{
    Espresso,
    Latte,
    Cappuccino
}

// Represents a drink on the menu (name, description, type).
// Price is NOT stored here — it is size-dependent and lives in BeveragePrice.
public class Beverage
{
    private int _beverageID;
    private string _beverageName;
    private string _beverageDescription;
    private BeverageType _beverageType;

    public int BeverageID
    {
        get { return _beverageID; }
        set { _beverageID = value; }
    }

    public string BeverageName
    {
        get { return _beverageName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                _beverageName = value;
            }
        }
    }

    public string BeverageDescription
    {
        get { return _beverageDescription; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                _beverageDescription = value;
            }
        }
    }

    public BeverageType BeverageType
    {
        get { return _beverageType; }
        set { _beverageType = value; }
    }

    public Beverage(int id, string beverageName, string beverageDescription, BeverageType type)
    {
        this._beverageID = id;
        this._beverageName = beverageName;
        this._beverageDescription = beverageDescription;
        this._beverageType = type;
    }
}
