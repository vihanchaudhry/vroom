using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour
{

    private bool blinkerLeft, blinkerRight;
    public Blinking BlinkLeft, BlinkRight;
    public bool TestLeft, TestRight;
    private bool merging = false;
    private float timer; //time until reset

    // Use this for initialization
    void Start()
    {
        TestLeft = TestRight = false;
    }

    // Update is called once per frame
    void Update()
    {
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
}
