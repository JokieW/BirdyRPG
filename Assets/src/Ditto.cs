using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Ditto
{
    public string handle;

    //Effect
    protected virtual void OnEffect(GameObject target)
    {

    }

    public void UsedBy(GameObject target)
    {
        _uses++;
        try
        {
            OnEffect(target);
        }
        catch (Exception e)
        {
            Debug.LogError("ERROR IN EFFECT: " + e);
        }
    }

    //Lifetime
    private float _creationTime;
    private int _uses;

    protected int UseCount
    {
        get
        {
            return _uses;
        }
    }

    public virtual bool StillAlive()
    {
        return false;
    }

    //Ctors
    private Ditto() { }
    protected Ditto(string name)
    {
        handle = name;
        _creationTime = Time.time;
    }
}
