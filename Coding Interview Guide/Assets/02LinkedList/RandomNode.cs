
public class RandomNode
{

    public int value;
    public RandomNode next;
    public RandomNode rand;

    public RandomNode(int data)
    {
        this.value = data;
        next = null;
    }

    public RandomNode(int data, RandomNode next, RandomNode rand)
    {
        this.value = data;
        this.next = next;
        this.rand = rand;
    }
}
