// Siemens Internship Assignment 2026 - Problem 1: Coffee Shop
// Audit record created whenever a customer earns or redeems loyalty points on an order.
public class LoyaltyTransaction
{
    private int _transactionID;
    private int _customerID;
    private int _orderID;
    private int _pointsEarned;
    private int _pointsRedeemed;
    private DateTime _transactionDate;

    // Navigation properties — nullable, populated on demand when loading from the DB.
    private Customer? _customer;
    private Order? _order;

    public Customer? Customer
    {
        get { return _customer; }
        set { _customer = value; }
    }

    public Order? Order
    {
        get { return _order; }
        set { _order = value; }
    }

    public int TransactionID
    {
        get { return _transactionID; }
        set { _transactionID = value; }
    }

    public int CustomerID
    {
        get { return _customerID; }
        set { _customerID = value; }
    }

    public int OrderID
    {
        get { return _orderID; }
        set { _orderID = value; }
    }

    // 0 when this event was redemption-only.
    public int PointsEarned
    {
        get { return _pointsEarned; }
        set { _pointsEarned = value; }
    }

    // 0 when no redemption occurred on this order.
    public int PointsRedeemed
    {
        get { return _pointsRedeemed; }
        set { _pointsRedeemed = value; }
    }

    public DateTime TransactionDate
    {
        get { return _transactionDate; }
        set { _transactionDate = value; }
    }

    public LoyaltyTransaction(int id, int custID, int orderID, int earned, int redeemed)
    {
        this._transactionID = id;
        this._customerID = custID;
        this._orderID = orderID;
        this._pointsEarned = earned;
        this._pointsRedeemed = redeemed;
        this._transactionDate = DateTime.Now;
    }
}
