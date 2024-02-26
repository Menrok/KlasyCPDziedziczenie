using System;

internal class Person
{
    public string firstName { get; protected set; }
    public string familyName { get; protected set; }
    public int age { get; protected set; }


    public Person(string firstName, string familyName, int age)
    {
        FirstName = firstName;
        FamilyName = familyName;
        Age = age;
    }

    public string FirstName
    {
        get => firstName;
        set 
        { 
            if (string.IsNullOrWhiteSpace(value) || !IsNameValid(value))
            {
                throw new ArgumentException("Wrong name!");
            }
            firstName = CorrectFormat(value);
        }
    }

    public string FamilyName
    {
        get => familyName;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !IsNameValid(value))
            {
                throw new ArgumentException("Wrong name!");
            }
            familyName = CorrectFormat(value);
        }
    }

    public int Age
    {
        get => age;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }
            age = value;
        }
    }


    private bool IsNameValid(string name)
    {
        foreach (char c in name)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                return false;
            }
        }
        return true;
    }

    public void modifyFirstName(string newFirstName)
    {
        FirstName = newFirstName;
    }

    public void modifyFamilyName(string newFamilyName)
    {
        FamilyName = newFamilyName;
    }

    public void modifyAge(int newAge)
    {
        if (this is Child && newAge < 0 || newAge >= 15 && this is Child)
        {
            throw new ArgumentException("Child’s age must be less than 15!");
        }
        Age = newAge;
    }

    private static string CorrectFormat(string name)
    {
        name = name.Replace(" ", "");
        if (name.Length > 0)
        {
            char[] chars = name.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            for (int i = 1; i < chars.Length; i++)
            {
                chars[i] = char.ToLower(chars[i]);
            }
            return new string(chars);
        }
        return name;
    }

    public override string ToString()
    {
        return $"{FirstName} {FamilyName} ({Age})";
    }
}