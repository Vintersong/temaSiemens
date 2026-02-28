// Siemens Internship Assignment 2026 - Problem 1: Coffee Shop
// Represents a barista employed at a specific shop location.
// Each Order records which barista prepared it, enabling traceability per transaction.
public class Barista
{
    private int _baristaID;
    private int _shopID;
    private string? _baristaFirstName;
    private string? _baristaLastName;
    private DateTime _employmentDate;

    // Navigation property — nullable, populated on demand when loading from the DB.
    private Shop? _shop;

    public Shop? Shop
    {
        get { return _shop; }
        set { _shop = value; }
    }

    public int BaristaID
    {
        get { return _baristaID; }
        set { _baristaID = value; }
    }

    public int ShopID
    {
        get { return _shopID; }
        set { _shopID = value; }
    }

    public string? BaristaFirstName
    {
        get { return _baristaFirstName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                _baristaFirstName = value;
            }
        }
    }

    public string? BaristaLastName
    {
        get { return _baristaLastName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                _baristaLastName = value;
            }
        }
    }

    public DateTime EmploymentDate
    {
        get { return _employmentDate; }
        set { _employmentDate = value; }
    }

    public Barista(int id, string fName, string lName, DateTime hireDate, int shopID)
    {
        this._baristaID = id;
        this.BaristaFirstName = fName;
        this.BaristaLastName = lName;
        this._employmentDate = hireDate;
        this._shopID = shopID;
    }

    public string GetFullName()
    {
        return this.BaristaFirstName + " " + this.BaristaLastName;
    }
}
