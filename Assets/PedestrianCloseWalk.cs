﻿using UnityEngine;
using System.Collections;

public class PedestrianCloseWalk : PedestrianWalk {

    private bool can = true;
    private ParticleSystem ps;
    public GameObject coll;

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
            Debug.Log(t);
            transform.position = Vector3.Lerp(startPos, destPos, t);
            if (t > 1)
            {
                run = false;
                Destroy(transform.parent.gameObject, 1.5f);
                this.enabled = false;
            }
            else if(t > 0.8 && can)
            {
                Destroy(coll);
                can = false;
            }
            t += Time.unscaledDeltaTime/6;
        }
	}

    public void turnOn(PlayerProperties p)
    {
        ps = Instantiate(indicator, transform.parent.transform.position + indicator.transform.position, indicator.transform.rotation) as ParticleSystem;
        run = true;
    }
}
