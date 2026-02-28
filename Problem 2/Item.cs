// Siemens Internship Assignment 2026 - Problem 2: SieMarket
// Represents a single line item within a customer order.
// Unit price is captured at order time, not looked up live.
public class Item
{
    private string _productName;
    private int _quantity;
    // decimal avoids floating-point rounding errors on monetary values.
    private decimal _unitPrice;

    public string ProductName
    {
        get { return _productName; }
        set { _productName = value; }
    }

    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }

    public decimal UnitPrice
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }

    public Item(string name, int qty, decimal price)
    {
        this._productName = name;
        this._quantity = qty;
        this._unitPrice = price;
    }
}
