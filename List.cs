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

    public void Add(T item)
    {
        if (this._count == this._items.Length)
        {
            EnsureCapacity(this._count + 1);
        }

        this._items[this._count++] = item;
    }

    private void EnsureCapacity(int minCapacity)
    {
        int newCapacity = this._items.Length == 0 ? DEFAULT_CAPACITY : this._items.Length * 2;

        if (newCapacity < minCapacity)
        {
            newCapacity = minCapacity;
        }

        Array.Resize(ref this._items, newCapacity);
    }

    public void AddRange(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Add(item);
        }
    }

    public void Clear()
    {
        Array.Clear(this._items, 0, this._count);
        this._count = 0;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(_items[i], item))
            {
                return true;
            }
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _items.CopyTo(array, arrayIndex);
    }
}
