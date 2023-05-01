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

    private void EnsureCapacity(int minCapacity)
    {
        int newCapacity = this._items.Length == 0 ? DEFAULT_CAPACITY : this._items.Length * 2;

        if (newCapacity < minCapacity)
        {
            newCapacity = minCapacity;
        }

        Array.Resize(ref this._items, newCapacity);
    }

    public void Add(T item)
    {
        if (this._count == this._items.Length)
        {
            EnsureCapacity(this._count + 1);
        }

        this._items[this._count++] = item;
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

    public void ForEach(Action<T> action)
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        for (int i = 0; i < this._count; i++)
        {
            action(_items[i]);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this._count; i++)
        {
            yield return _items[i];
        }
    }

    public List<T> GetRange(int index, int count)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is less than 0.");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Count is less than 0.");
        }

        if (this._count - index < count)
        {
            throw new ArgumentException("Invalid range.");
        }

        var rangeList = new List<T>(count);

        for (int i = index; i < index + count; i++)
        {
            rangeList.Add(_items[i]);
        }

        return rangeList;
    }

    public int IndexOf(T item)
    {
        return Array.IndexOf(_items, item, 0, this._count);
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > this._count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (this._count == _items.Length)
        {
            EnsureCapacity(this._count + 1);
        }

        if (index < this._count)
        {
            Array.Copy(_items, index, _items, index + 1, this._count - index);
        }
    }

    public void Reverse()
    {
        int left = 0;
        int right = this._count - 1;

        while (left < right)
        {
            T temp = _items[left];
            _items[left] = _items[right];
            _items[right] = temp;

            left++;
            right--;
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this._count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        for (int i = index; i < this._count - 1; i++)
        {
            this._items[i] = this._items[i + 1];
        }

        this._count--;
        this._items[_count] = default(T);
    }

    public void RemoveRange(int index, int count)
    {
        if (index < 0 || index + count > this._count)
        {
            throw new ArgumentOutOfRangeException("index or count is out of range");
        }

        if (count > 0)
        {
            Array.Copy(_items, index + count, _items, index, this._count - index - count);
            Array.Clear(_items, this._count - count, count);
            this._count -= count;
        }
    }
}
