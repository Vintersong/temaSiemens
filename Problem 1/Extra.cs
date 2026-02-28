// Siemens Internship Assignment 2026 - Problem 1: Coffee Shop
// Optional drink customization added to a beverage order.
// Supported extras: extra espresso shot, vanilla syrup, caramel syrup, whipped cream.
public class Extra
{
    private int _extraID;
    private string _extraName;
    private decimal _extraPrice;

    public int ExtraID
    {
        get { return _extraID; }
        set { _extraID = value; }
    }

    public string ExtraName
    {
        get { return _extraName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                _extraName = value;
            }
        }
    }

    public decimal ExtraPrice
    {
        get { return _extraPrice; }
        set { _extraPrice = value; }
    }

    public Extra(int id, string name, decimal price)
    {
        this._extraID = id;
        this._extraName = name;
        this._extraPrice = price;
    }
}
