// Siemens Internship Assignment 2026 - Problem 1: Coffee Shop
// Represents one of the three available drink sizes: Small, Medium, or Large.
public class Size
{
    private int _sizeID;
    private string _sizeName;

    public int SizeID
    {
        get { return _sizeID; }
        set { _sizeID = value; }
    }

    public string SizeName
    {
        get { return _sizeName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                _sizeName = value;
            }
        }
    }

    public Size(int id, string name)
    {
        this._sizeID = id;
        this._sizeName = name;
    }
}
