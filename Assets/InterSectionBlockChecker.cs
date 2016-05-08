using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class InterSectionBlockChecker : MonoBehaviour {


    private bool check = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(check)
            {
                check = false;
                GetComponentInParent<IntersectionBlock>().setCheck(true);
            }
        }

    }

    public void reset()
    {
        check = true;
    }
}
