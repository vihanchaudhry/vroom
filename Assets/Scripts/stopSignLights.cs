using UnityEngine;
using System.Collections;

public class stopSignLights : MonoBehaviour
{

    private bool on = false;
    private bool done = false;
    private ParticleSystem ps;
    // Use this for initialization
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            if (ps.startSpeed < 1)
            {
                ps.startSpeed += Time.unscaledDeltaTime;
            }
            else
            {
                on = false;
                done = true;
            }
        }
    }


    public void set()
    {
        if (!done)
            on = true;
    }
}
