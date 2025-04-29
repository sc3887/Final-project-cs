
namespace BO;

//חריגה  עבור יישות עם מספר מזהה שלא קיים ברשימה
[Serializable]
public class BLIdNotExistsException : Exception
{
    public BLIdNotExistsException(string message) : base(message)
    {

    }
    public BLIdNotExistsException(string message, Exception innerException)
                : base(message, innerException) { }

}
//חריגה עבור יישות עם מספר מזהה שכבר קיים ברשימה
[Serializable]
public class BLIdIsExistsException : Exception
{
    public BLIdIsExistsException(string message) : base(message)
    {

    }
    public BLIdIsExistsException(string message, Exception innerException)
                : base(message, innerException) { }
}

//חריגה עבור יישות עם מספר מזהה שכבר קיים ברשימה
[Serializable]
public class BLOptionNotExistsException : Exception
{
    public BLOptionNotExistsException(string message) : base(message)
    {

    }
    public BLOptionNotExistsException(string message, Exception innerException)
                : base(message, innerException) { }
}

[Serializable]
//חריגה עבור מוצר שאין מספיק במלאי
public class BLnotEnoughInStock : Exception
{
    public BLnotEnoughInStock(string message) : base(message)
    {

    }
    public BLnotEnoughInStock(string message, Exception innerException)
                : base(message, innerException) { }
}
