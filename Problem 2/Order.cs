// Siemens Internship Assignment 2026 - Problem 2: SieMarket
// Represents a customer order containing one or more items.
public class Order
{
    private int _orderID;
    private Customer _customer;
    private List<Item> _items;

    public int OrderID
    {
        get { return _orderID; }
        set { _orderID = value; }
    }

    public Customer Customer
    {
        get { return _customer; }
        set { _customer = value; }
    }

    public List<Item> Items
    {
        get { return _items; }
        set { _items = value; }
    }

    public Order(int id, Customer customer)
    {
        this._orderID = id;
        this._customer = customer;
        this._items = new List<Item>();
    }

    // 2.2 - Applies a 10% discount when the order subtotal exceeds 500€.
    public decimal CalculateFinalPrice()
    {
        decimal subtotal = 0;

        foreach (Item item in this._items)
        {
            subtotal += (item.UnitPrice * item.Quantity);
        }

        if (subtotal > 500)
        {
            return subtotal * 0.9m;
        }

        return subtotal;
    }

    // 2.3 - Returns the full name of the customer who spent the most across all orders.
    // Two-pass: first accumulate spend per CustomerID, then resolve the winner's name.
    public static string FindTopSpender(List<Order> allOrders)
    {
        // Pass 1: total spend per customer (after discounts).
        Dictionary<int, decimal> totals = new Dictionary<int, decimal>();

        foreach (Order order in allOrders)
        {
            decimal amount = order.CalculateFinalPrice();
            int id = order.Customer.CustomerID;

            if (totals.ContainsKey(id))
                totals[id] += amount;
            else
                totals.Add(id, amount);
        }

        // Pass 2: find the CustomerID with the highest total.
        int topID = -1;
        decimal maxSpent = -1;

        foreach (var entry in totals)
        {
            if (entry.Value > maxSpent)
            {
                maxSpent = entry.Value;
                topID = entry.Key;
            }
        }

        foreach (Order order in allOrders)
        {
            if (order.Customer.CustomerID == topID)
                return order.Customer.GetFullName();
        }

        return "";
    }

    // 2.4 (Bonus) - Returns products with their total quantity sold, sorted descending.
    // Note: sorted via List<KeyValuePair<>> before inserting into the result Dictionary,
    // since Dictionary does not guarantee insertion order.
    public static Dictionary<string, int> GetPopularProducts(List<Order> allOrders)
    {
        Dictionary<string, int> productTotals = new Dictionary<string, int>();

        foreach (Order order in allOrders)
        {
            foreach (Item item in order.Items)
            {
                if (productTotals.ContainsKey(item.ProductName))
                    productTotals[item.ProductName] += item.Quantity;
                else
                    productTotals.Add(item.ProductName, item.Quantity);
            }
        }

        List<KeyValuePair<string, int>> sorted = new List<KeyValuePair<string, int>>(productTotals);
        sorted.Sort((a, b) => b.Value.CompareTo(a.Value));

        Dictionary<string, int> result = new Dictionary<string, int>();
        foreach (var pair in sorted)
            result.Add(pair.Key, pair.Value);

        return result;
    }
}
