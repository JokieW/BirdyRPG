using UnityEngine;
using System.Collections;

public class EnergyRegen : Ditto 
{
	public float RegenRate = 1.0f;
	public float BaseRegen = 10.0f;
	
	protected override void OnEffect(GameObject target)
    {
       target.GetComponent<Stats>().Energy += BaseRegen * RegenRate;
    }

    public override bool StillAlive()
    {
        return true;
    }

    public EnergyRegen(string name) : base(name){}
}

