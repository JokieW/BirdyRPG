using UnityEngine;
using System.Collections;

public class TargetPicker : MonoBehaviour 
{
    [SerializeField]
    private GameObject _currentTarget;

    void Start()
    {
        PickRandomTarget();
    }

    public void PickRandomTarget()
    {
        foreach (Fighter f in GameObject.FindObjectsOfType<Fighter>())
        {
            if (f.gameObject != gameObject)
            {
                _currentTarget = f.gameObject;
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        _currentTarget = target;
    }
}
