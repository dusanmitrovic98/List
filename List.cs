namespace DataStructures.Collections.List;

public class List<T>
{
    private T[] _items;
    private int _count;
    private const int DefaultCapacity = 4;

    public List()
    {
        this._items = new T[DefaultCapacity];
        this._count = 0;
    }
}
