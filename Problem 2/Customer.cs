// Siemens Internship Assignment 2026 - Problem 2: SieMarket
// Represents a customer of the SieMarket online electronics store.
public class Customer
{
    private string _firstName;
    private string _lastName;
    private int _customerID;

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public int CustomerID
    {
        get { return _customerID; }
        set { _customerID = value; }
    }

    public string GetFullName()
    {
        return this.FirstName + " " + this.LastName;
    }

    public Customer(int id, string firstName, string lastName)
    {
        this._customerID = id;
        this._firstName = firstName;
        this._lastName = lastName;
    }
}
