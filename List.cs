namespace DataStructures.Collections.List;

public class List<T>
{
    private T[] _items;
    private int _count;
    private const int DEFAULT_CAPACITY = 4;

    public List()
    {
        this._items = new T[DEFAULT_CAPACITY];
        this._count = 0;
    }

    public List(int capacity)
    {
        this._items = new T[capacity];
        this._count = 0;
    }
}
