using UnityEngine;
using System.Collections;

public class Blinking : MonoBehaviour {

    public bool run = false;
    public float runTime = 8;
    private float timer, runTimer;
    private SpriteRenderer sp;

	// Use this for initialization
	void Start () {
        runTimer = runTime;
        timer = 0;
        sp = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(run)
        {
            timer += Time.unscaledDeltaTime;
            if(timer >= 0.25f)
            {
                runTimer -= timer;
                timer = 0;
                sp.enabled = !sp.enabled;
            }

//            if (runTimer < 0)
//            {
//                run = false;
//                runTimer = runTime;
//                timer = 0;
//                sp.enabled = false;
//            }
        }
	}

    public void setRun(bool b)
    {
        run = b;
        sp.enabled = b;

    }
}
