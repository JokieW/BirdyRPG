using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    Vector3 defaultPosition = Vector3.zero;
    Quaternion defaultRotation = new Quaternion();

    Transform targetLocation;

	// Use this for initialization
	void Start () {
        defaultPosition = Camera.main.transform.position;
        defaultRotation = Camera.main.transform.rotation;
	}

    bool defaultLocation = true;

	// Update is called once per frame
	void Update () {
	    if(defaultLocation)
        {
            Camera.main.transform.position = Vector3.Lerp(this.transform.position, defaultPosition, Time.deltaTime * 5);
            Camera.main.transform.rotation = Quaternion.Lerp(this.transform.rotation, defaultRotation, Time.deltaTime * 5);
        }
        else
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, targetLocation.position, Time.deltaTime * 30);
            Camera.main.transform.rotation = Quaternion.RotateTowards(Camera.main.transform.rotation, targetLocation.rotation, Time.deltaTime * 30);
        }
	}

    public void SetNewLocation(Transform location)
    {
        targetLocation = location;
        defaultLocation = false;
    }

    public void ResetLocation()
    {
        defaultLocation = true;
    }
}
