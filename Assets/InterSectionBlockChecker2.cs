using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class InterSectionBlockChecker2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            transform.parent.GetComponentInChildren<InterSectionBlockChecker>().reset();
            GetComponentInParent<IntersectionBlock>().setCheck(true);

        }
    }
}
