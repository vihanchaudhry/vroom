using UnityEngine;
using System.Collections;

public class IntersectionReset : MonoBehaviour {

    private float first, second;
    private bool setOnce = false;
    private bool setTwice = false;
    private float blinker = 0;

	// Use this for initialization
	void Start () {
        first = second = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //0 is none, 1 is left, 2 is right
    public void setBlinker(float b)
    {
        blinker = b;
    }

    //1 for front, 2 for left, 3 for back, 4 for right
    //return 1 for first time, return 2 for second time
    public float set(float f)
    {
        if (!setOnce)
        {
            first = f;
            setOnce = true;
            return 1;
        }
        else if(!setTwice)
        {
            second = f;
            setTwice = true;
            return 2;
        }
        else
        {
            return 0;
        }
    }

    //math.abs(a-b) == 2 => no blinker
    //-1 or 3 => left
    //1 or -3 => right
    public void calculate(PlayerProperties p)
    {
        float f = first - second;
        if(f == 1 || f == -3) {
            if (blinker != 2)
            {
                GameManager.Instance.AddDemerit(1);
            }
        }
        else if(f == -1 || f == 3)
        {
            if(blinker != 1)
            {
                GameManager.Instance.AddDemerit(1);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            setOnce = setTwice = false;
        }
    }

   


}
