namespace DO;

//חריגה  עבור יישות עם מספר מזהה שלא קיים ברשימה
[Serializable]
public class DalIdNotExistsException : Exception
{
    public DalIdNotExistsException(string message) : base(message)
    {

    }
}
//חריגה עבור יישות עם מספר מזהה שכבר קיים ברשימה
[Serializable]
public class DalIdIsExistsException : Exception
{
    public DalIdIsExistsException(string message) : base(message)
    {

    }
}

//חריגה עבור יישות עם מספר מזהה שכבר קיים ברשימה
[Serializable]
public class DalOptionNotExistsException : Exception
{
    public DalOptionNotExistsException(string message) : base(message)
    {

    }
}