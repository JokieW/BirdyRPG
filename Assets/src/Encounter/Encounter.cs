using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Encounter : MonoBehaviour {

    public List<EncounterEvent> events = new List<EncounterEvent>();

    bool active = false;

    public void Trigger()
    {
        foreach (EncounterEvent e in events)
        {
            if (!e.IsCleared())
            {
                e.Play();
                break;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            Trigger();
        }
    }
}
