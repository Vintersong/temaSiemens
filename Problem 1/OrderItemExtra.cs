// Siemens Internship Assignment 2026 - Problem 1: Coffee Shop
// DB join table resolving the many-to-many relationship between OrderItem and Extra.
// In-memory, extras live on OrderItem._extras; this class persists each link individually.
public class OrderItemExtra
{
    private int _orderItemExtraID;
    private int _orderItemID;
    private int _extraID;

    // Navigation properties — nullable, populated on demand when loading from the DB.
    private OrderItem? _orderItem;
    private Extra? _extra;

    public OrderItem? OrderItem
    {
        get { return _orderItem; }
        set { _orderItem = value; }
    }

    public Extra? Extra
    {
        get { return _extra; }
        set { _extra = value; }
    }

    public int OrderItemExtraID
    {
        get { return _orderItemExtraID; }
        set { _orderItemExtraID = value; }
    }

    public int OrderItemID
    {
        get { return _orderItemID; }
        set { _orderItemID = value; }
    }

    public int ExtraID
    {
        get { return _extraID; }
        set { _extraID = value; }
    }

    public OrderItemExtra(int id, int orderItemID, int extraID)
    {
        this._orderItemExtraID = id;
        this._orderItemID = orderItemID;
        this._extraID = extraID;
    }
}
