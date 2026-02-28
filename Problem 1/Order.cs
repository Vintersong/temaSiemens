// Siemens Internship Assignment 2026 - Problem 1: Coffee Shop
// A purchase transaction that tracks the customer, barista, shop, timestamp, and total.
public class Order
{
    private int _orderID;
    private int _customerID;
    private int _baristaID;
    private DateTime _orderDate;
    private decimal _finalTotal;
    private int _shopID;

    // Navigation properties — nullable, populated on demand when loading from the DB.
    private Customer? _customer;
    private Barista? _barista;
    private Shop? _shop;
    private List<OrderItem> _items = new List<OrderItem>();

    // Read-only externally so callers must go through AddItem(), keeping FinalTotal in sync.
    public IReadOnlyList<OrderItem> Items
    {
        get { return _items.AsReadOnly(); }
    }

    public Customer? Customer
    {
        get { return _customer; }
        set { _customer = value; }
    }

    public Barista? Barista
    {
        get { return _barista; }
        set { _barista = value; }
    }

    public Shop? Shop
    {
        get { return _shop; }
        set { _shop = value; }
    }

    public int OrderID
    {
        get { return _orderID; }
        set { _orderID = value; }
    }

    public int CustomerID
    {
        get { return _customerID; }
        set { _customerID = value; }
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

    public DateTime OrderDate
    {
        get { return _orderDate; }
        set { _orderDate = value; }
    }

    public decimal FinalTotal
    {
        get { return _finalTotal; }
        set { _finalTotal = value; }
    }

    public Order(int id, int custID, int barID, int shopID)
    {
        this._orderID = id;
        this._customerID = custID;
        this._baristaID = barID;
        this._shopID = shopID;
        this._orderDate = DateTime.Now;
        this._finalTotal = 0.0m;
    }

    // Adds an item and recalculates the total. Always use this instead of modifying Items directly.
    public void AddItem(OrderItem item)
    {
        _items.Add(item);
        CalculateTotal();
    }

    // Recomputes FinalTotal from all items. Call manually after AddExtra() changes a UnitPrice.
    public void CalculateTotal()
    {
        _finalTotal = 0;
        foreach (OrderItem item in _items)
        {
            _finalTotal += item.UnitPrice * item.Quantity;
        }
    }
}
