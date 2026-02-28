// Siemens Internship Assignment 2026 - Problem 1: Coffee Shop
// Represents a loyalty-program member belonging to a MembershipType tier (Regular or Gold).
public class Customer
{
    private int _customerID;
    private string? _customerFirstName;
    private string? _customerLastName;
    private DateTime _registrationDate;
    private MembershipType _membershipType;
    private int _loyaltyPoints;

    public int CustomerID
    {
        get { return _customerID; }
        set { _customerID = value; }
    }

    public string? CustomerFirstName
    {
        get { return _customerFirstName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                _customerFirstName = value;
            }
        }
    }

    public string? CustomerLastName
    {
        get { return _customerLastName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                _customerLastName = value;
            }
        }
    }

    public DateTime RegistrationDate
    {
        get { return _registrationDate; }
        set { _registrationDate = value; }
    }

    public MembershipType MembershipType
    {
        get { return _membershipType; }
        set { _membershipType = value; }
    }

    // Shortcut to the tier's FK value, used when persisting to the database.
    public int TierID
    {
        get { return _membershipType.TierID; }
    }

    public int LoyaltyPoints
    {
        get { return _loyaltyPoints; }
        set { _loyaltyPoints = value; }
    }

    public Customer(int id, string fName, string lName, MembershipType membershipType, int points)
    {
        this._customerID = id;
        this.CustomerFirstName = fName;
        this.CustomerLastName = lName;
        this._membershipType = membershipType;
        this._loyaltyPoints = points;
        this._registrationDate = DateTime.Now;
    }

    public string GetFullName()
    {
        return this.CustomerFirstName + " " + this.CustomerLastName;
    }

    // Adds points after a purchase: floor(amountSpent × PointsMultiplier).
    // Regular tier multiplier = 1, Gold tier multiplier = 2.
    public void EarnPoints(decimal amountSpent)
    {
        this._loyaltyPoints += (int)(amountSpent * _membershipType.PointsMultiplier);
    }

    // Deducts points to redeem a free drink. Returns false if balance is insufficient.
    public bool RedeemPoints(int points)
    {
        if (this._loyaltyPoints >= points)
        {
            this._loyaltyPoints -= points;
            return true;
        }
        return false;
    }
}
