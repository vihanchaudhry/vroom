using UnityEngine;
using System.Collections;

public class PedestrianWalk : MonoBehaviour {

    public GameObject destination;
    private Vector3 startPos, destPos;
    private bool run = false;
    private float t;
    private bool fail = false;
    private PlayerProperties pp;
    public ParticleSystem indicator;
    private ParticleSystem ps;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        destPos = destination.transform.position;
        t = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if(run)
        {
            transform.position = Vector3.Lerp(startPos, destPos, t);
            if(t > 1)
            {
                run = false;
                Destroy(transform.parent.gameObject, 1.5f);
                this.enabled = false;
            }
            else if(t > 0.78)
            {
                if(pp.GetComponent<Rigidbody>().velocity != Vector3.zero)
                {
                    //fail
                    GameManager.Instance.GameOverMenu();
                }
            }
            else if(t > 0.56)
            {
                if (pp.GetComponent<Rigidbody>().velocity != Vector3.zero && !fail)
                {
                    fail = true;
                    //demerit
                    GameManager.Instance.addDemerit(1);
                }
            }
            t += Time.unscaledDeltaTime/6;
            
            
        }
	}

    public void turnOn(PlayerProperties p)
    {
        ps = Instantiate(indicator, transform.parent.transform.position + indicator.transform.position, indicator.transform.rotation) as ParticleSystem;
        pp = p;
        run = true;
    }
}
