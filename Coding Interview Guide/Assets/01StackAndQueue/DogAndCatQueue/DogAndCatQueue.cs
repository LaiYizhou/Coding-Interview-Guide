using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAndCatQueue
{

    private Queue<PetExtend> dogQueue;
    private Queue<PetExtend> catQueue;

    private int count;

    public DogAndCatQueue()
    {
        dogQueue = new Queue<PetExtend>();
        catQueue = new Queue<PetExtend>();
        count = 0;
    }

    public void Add(Pet pet)
    {
        if (pet.GetPetType() == "dog")
        {
            dogQueue.Enqueue(new PetExtend(pet, count++));
        }
        else if (pet.GetPetType() == "cat")
        {
            catQueue.Enqueue(new PetExtend(pet, count++));
        }
        else
        {
            Debug.LogError("Type doesn't match");
        }
    }

    public Pet PollAll()
    {
        if (dogQueue.Count != 0 && catQueue.Count != 0)
        {
            if (dogQueue.Peek().GetId() < catQueue.Peek().GetId())
                return dogQueue.Dequeue().GetPet();
            else
                return catQueue.Dequeue().GetPet();
        }
        else if(dogQueue.Count != 0)
            return dogQueue.Dequeue().GetPet();
        else if (catQueue.Count != 0)
            return catQueue.Dequeue().GetPet();
        else
            return null;
    }

    public Pet PollDog()
    {
        if (dogQueue.Count == 0)
            return null;
        else
        {
            return dogQueue.Dequeue().GetPet();
        }
    }

    public Pet PollCat()
    {
        if (catQueue.Count == 0)
            return null;
        else
        {
            return catQueue.Dequeue().GetPet();
        }
    }

    public bool IsEmpty()
    {
        return dogQueue.Count == 0 && catQueue.Count == 0;
    }

    public bool IsDogEmpty()
    {
        return dogQueue.Count == 0;
    }

    public bool IsCatEmpty()
    {
        return catQueue.Count == 0;
    }

}
