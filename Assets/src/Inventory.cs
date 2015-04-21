using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour 
{
    [SerializeField]
    public List<Ditto> _items = new List<Ditto>();

    private Ditto _current;
    private int _itemPointer = 0;

    public void AddItem(Ditto item)
    {
        if (_items.Count == 0)
        {
            _current = item;
        }
        _items.Add(item);
    }

    public bool HasItem<T>()
    {
        return _items.Any(x => x.GetType() == typeof(T));
    }

    public T GetItem<T>()
    {
        return (T)(object)_items.FirstOrDefault(x => x.GetType() == typeof(T));
    }

    public T[] GetItems<T>()
    {
        return (T[])(object)_items.All(x => x.GetType() == typeof(T));
    }

    public List<Ditto> AllItems()
    {
        return new List<Ditto>(_items);
    }

    public void NextItem()
    {
        _itemPointer++;
        if (_itemPointer >= _items.Count)
        {
            _itemPointer = 0;
        }
        _current = _items[_itemPointer];
    }

    public void PreviousItem()
    {
        _itemPointer--;
        if (_itemPointer <= -1)
        {
            _itemPointer = _items.Count-1;
        }
        _current = _items[_itemPointer];
    }

    public void UseCurrent()
    {
        _current.UsedBy(gameObject);
    }
}
