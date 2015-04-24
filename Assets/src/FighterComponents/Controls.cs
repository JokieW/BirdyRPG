using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Altimeter))]
public abstract class Controls : MonoBehaviour 
{
    private CompCache<Altimeter> _altimeter;

    protected virtual void Awake()
    {
        _altimeter = new CompCache<Altimeter>(gameObject);
    }

    protected void MoveUp()
    {
        _altimeter.get.GoUp();
    }

    protected void MoveDown()
    {
        _altimeter.get.GoDown();
    }
}
