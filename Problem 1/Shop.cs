// Siemens Internship Assignment 2026 - Problem 1: Coffee Shop
// Represents a physical coffee shop location in the chain.
// Supports multi-location operations: each shop has its own baristas and orders.
public class Shop
{
    private int _shopID;
    private string _shopName;
    private string _shopAddress;

    public int ShopID
    {
        get { return _shopID; }
        set { _shopID = value; }
    }

    public string ShopName
    {
        get { return _shopName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                _shopName = value;
            }
        }
    }

    public string ShopAddress
    {
        get { return _shopAddress; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                _shopAddress = value;
            }
        }
    }

    public Shop(int id, string name, string addr)
    {
        this._shopID = id;
        this._shopName = name;
        this._shopAddress = addr;
    }
}
