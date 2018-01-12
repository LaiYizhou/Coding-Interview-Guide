
public class PetExtend
{


    public int Hahah
    {
        get { return 5; }
        private set { value++; }
    }

    private Pet pet;
    private int id;

    public PetExtend(Pet pet, int id)
    {
        this.pet = pet;
        this.id = id;
    }

    public Pet GetPet()
    {
        return this.pet;
    }

    public int GetId()
    {
        return this.id;
    }

    public string GetPetType()
    {
        return pet.GetPetType();
    }

}
