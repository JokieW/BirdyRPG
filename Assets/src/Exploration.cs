using UnityEngine;
using System.Collections;

public class Exploration : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                //Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "PointOfInterest")
                {
                    Debug.Log("It's working!");
                    target.position = hitInfo.transform.gameObject.GetComponent<PointOfInterest>().pointOfAcces.position;
                }
                else
                {
                    Debug.Log("nopz");
                }
            }
            else
            {
                //Debug.Log("No hit");
            }
            //Debug.Log("Mouse is down");
        }
    }
}
