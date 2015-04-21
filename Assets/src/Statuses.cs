using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Statuses : MonoBehaviour 
{
    [SerializeField]
    public List<Ditto> _statuses = new List<Ditto>();

    public bool HasEffect<T>()
    {
        return _statuses.Any(x => x.GetType() == typeof(T));
    }

    public T GetEffect<T>()
    {
        return (T)(object)_statuses.FirstOrDefault(x => x.GetType() == typeof(T));
    }

    public T[] GetEffect<T>()
    {
        return (T[])(object)_statuses.All(x => x.GetType() == typeof(T));
    }

    void Update()
    {
        foreach (Ditto d in new List<Ditto>(_statuses))
        {
            d.UsedBy(gameObject);
            if (!d.StillAlive())
            {
                _statuses.Remove(d);
            }
        }
    }
}
