using System.Collections.Generic;
using System;

public class Hat<T>
{
    IList<T> items = new List<T>();
    int nextItemIndex;

    public int Count { get { return items.Count; } }

    public void Put(T item)
    {
        items.Add(item);
        RandomizeNextItemIndex();
    }

    public T Pick()
    {
        T poppedItem = items[nextItemIndex];
        items.RemoveAt(nextItemIndex);
        RandomizeNextItemIndex();
        return poppedItem;
    }

    public T Peak()
    {
        return items[nextItemIndex];
    }

    void RandomizeNextItemIndex()
    {
        nextItemIndex = new Random().Next(items.Count);
    }
}
