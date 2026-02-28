// Siemens Internship Assignment 2026 - Problem 1: Coffee Shop
// Resolves the many-to-many relationship between Beverage and Size.
// Each row stores the price for one Beverage + Size combination (e.g. Large Latte = 4.50€).
public class BeveragePrice
{
    private int _beverageID;
    private int _sizeID;
    private int _priceID;
    private decimal _price;

    // Navigation properties — nullable, populated on demand when loading from the DB.
    private Beverage? _beverage;
    private Size? _size;

    public Beverage? Beverage
    {
        get { return _beverage; }
        set { _beverage = value; }
    }

    public Size? Size
    {
        get { return _size; }
        set { _size = value; }
    }

    public int BeverageID
    {
        get { return _beverageID; }
        set { _beverageID = value; }
    }

    public int SizeID
    {
        get { return _sizeID; }
        set { _sizeID = value; }
    }

    public int PriceID
    {
        get { return _priceID; }
        set { _priceID = value; }
    }

    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public BeveragePrice(int bevID, int sizeID, int priceID, decimal price)
    {
        this._beverageID = bevID;
        this._sizeID = sizeID;
        this._priceID = priceID;
        this._price = price;
    }
}
