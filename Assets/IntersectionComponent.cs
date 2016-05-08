using UnityEngine;
using System.Collections;

public class IntersectionComponent : MonoBehaviour {

    private IntersectionReset dad;
    public float side = 1;

	// Use this for initialization
	void Start () {
        dad = GetComponentInParent<IntersectionReset>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (dad.set(side) == 2)
            {
                dad.calculate(other.GetComponent<PlayerProperties>());
            }
            else
            {
                dad.setBlinker(other.GetComponent<PlayerProperties>().getBlinker());
            }
        }
    }
}
