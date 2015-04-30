using UnityEngine;
using System.Collections;

public class Exploration : MonoBehaviour {

    public Transform target;
	
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                if (hitInfo.transform.gameObject.tag == "PointOfInterest")
                {
                    target.position = hitInfo.transform.gameObject.GetComponent<PointOfInterest>().pointOfAcces.position;
                }
            }
            else
            {
                //Debug.Log("No hit");
            }
        }
    }
}
