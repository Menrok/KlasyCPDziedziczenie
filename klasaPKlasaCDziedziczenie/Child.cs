using System;

internal class Child : Person
{
    private readonly Person mother;
    private readonly Person father;

    public Child(string firstName, string familyName, int age, Person mother = null, Person father = null)
        : base(firstName, familyName, age)
    {
        if (age >= 15)
        {
            throw new ArgumentException("Child’s age must be less than 15!");
        }

        this.mother = mother;
        this.father = father;
    }

    public void ModifyAge(int newAge)
    {
        if (this is Child && newAge < 0 || newAge >= 15 && this is Child)
        {
            throw new ArgumentOutOfRangeException(nameof(newAge), "Child's age must be between 0 and 15!");
        }

        Age = newAge;
    }

    public override string ToString()
    {
        string motherInfo = (mother != null) ? $"mother: {mother.ToString()}" : "mother: No data";
        string fatherInfo = (father != null) ? $"father: {father.ToString()}" : "father: No data";

        return base.ToString() + Environment.NewLine + motherInfo + Environment.NewLine + fatherInfo;
    }
}