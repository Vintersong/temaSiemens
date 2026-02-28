// Siemens Internship Assignment 2026 - Problem 1: Coffee Shop
// One line in an order: a beverage in a specific size with optional extras.
// UnitPrice starts as the base Beverage+Size price and increases with each extra added.
public class OrderItem
{
    private int _orderItemID;
    private int _orderID;
    private int _beverageID;
    private int _sizeID;
    private int _quantity;
    private decimal _unitPrice;

    // Navigation properties — nullable, populated on demand when loading from the DB.
    private Beverage? _beverage;
    private Size? _size;
    private List<Extra> _extras = new List<Extra>();

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

    // Read-only externally so callers must go through AddExtra(), keeping UnitPrice in sync.
    public IReadOnlyList<Extra> Extras
    {
        get { return _extras.AsReadOnly(); }
    }

    public int OrderItemID
    {
        get { return _orderItemID; }
        set { _orderItemID = value; }
    }

    public int OrderID
    {
        get { return _orderID; }
        set { _orderID = value; }
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

    public OrderItem(int id, int oID, int bID, int sizeID, int qty, decimal unitPrice)
    {
        this._orderItemID = id;
        this._orderID = oID;
        this._beverageID = bID;
        this._sizeID = sizeID;
        this._quantity = qty;
        this._unitPrice = unitPrice;
    }

    // Adds a customization and immediately raises UnitPrice by the extra's cost.
    // Call Order.CalculateTotal() afterwards to propagate the change to the order total.
    public void AddExtra(Extra extra)
    {
        _extras.Add(extra);
        _unitPrice += extra.ExtraPrice;
    }
}
