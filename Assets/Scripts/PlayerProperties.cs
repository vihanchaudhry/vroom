using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour
{

    private bool blinkerLeft, blinkerRight;
    public Blinking BlinkLeft, BlinkRight;
    public bool TestLeft, TestRight;
    private bool merging = false;
    private float timer; //time until reset
    private CarState cs;
    private RaycastHit hit;
    private Ray ray;
    private bool rayCasting = false;
    public LayerMask lm;

    // Use this for initialization
    void Start()
    {
        cs = GetComponentInChildren<CarState>();
        TestLeft = TestRight = false;
        rayCasting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rayCasting)
        {
            Camera cam = GetComponentInChildren<Camera>();
            ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(ray, out hit, 100, lm))
            {

                hit.transform.gameObject.GetComponent<stopSignLights>().set();
                // Do something with the object that was hit by the raycast.
            }
        }
        if (TestLeft)
        {
            setBlinkerLeft(true);
            TestLeft = false;
        }
        if(TestRight)
        {
            setBlinkerRight(true);
            TestRight = false;
        }

    }

    //set blinkers, turn off other blinker if setting on
    public void setBlinkerLeft(bool b)
    {
        blinkerLeft = b;
        if (b)
        {
            blinkerRight = false;
            BlinkRight.setRun(false);
            StartCoroutine(runTimerL(BlinkLeft.runTime));
        }
        BlinkLeft.setRun(b);

    }

    public void setBlinkerRight(bool b)
    {
        blinkerRight = b;
        if (b)
        {
            blinkerLeft = false;
            BlinkLeft.setRun(false);
            StartCoroutine(runTimerR(BlinkRight.runTime));
        }
        BlinkRight.setRun(b);

    }

    public bool getBlinkerLeft()
    {
        return blinkerLeft;
    }

    public bool getBlinkerRight()
    {
        return blinkerRight;
    }

    IEnumerator runTimerL(float f)
    {
        yield return new WaitForSeconds(f);
        blinkerLeft = false;
    }

    IEnumerator runTimerR(float f)
    {
        yield return new WaitForSeconds(f);
        blinkerRight = false;
    }

    public void setMerging(bool b)
    {
        merging = b;
    }

    public bool isMerging()
    {
        return merging;
    }

    //1,2, or 3
    public void shift(int f)
    {
        cs.shift(f);
    }

    public void startRayCasting()
    {
        rayCasting = true;
    }

    public void stopRayCasting()
    {
        rayCasting = false;
    }
}
