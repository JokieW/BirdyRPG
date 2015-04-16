using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Statuses : MonoBehaviour 
{
    [SerializeField]
    public List<Ditto> _statuses = new List<Ditto>();
    
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
