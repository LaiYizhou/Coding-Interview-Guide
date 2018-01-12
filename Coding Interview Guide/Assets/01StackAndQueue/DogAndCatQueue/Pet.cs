

public class Pet
{

    private string type;

    public Pet(string type)
    {
        this.type = type;
    }

    //public new string GetType()
    public string GetPetType()
    {
        return this.type;
    }

}


public class Dog : Pet
{

    public Dog() : base("dog")
    {

    }

}

public class Cat : Pet
{

    public Cat() : base("dog")
    {

    }


}