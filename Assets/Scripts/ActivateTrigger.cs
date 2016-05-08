using UnityEngine;
using System.Collections;

public class ActivateTrigger : MonoBehaviour
{

    public GameObject triggerObject;

	// Use this for initialization
	void Start () {
	    triggerObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    triggerObject.SetActive(true);
	}
}
