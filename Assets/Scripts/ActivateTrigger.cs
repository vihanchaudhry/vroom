using UnityEngine;
using System.Collections;
using Assets.Scripts.car;

public class ActivateTrigger : MonoBehaviour
{

    public GameObject triggerObject;

	// Use this for initialization
	void Start () {
	    triggerObject.SetActive(false);
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other)
	{
	    CarUserControl car = other.GetComponent<CarUserControl>();
        if (car)
	        triggerObject.SetActive(true);
	}
}
