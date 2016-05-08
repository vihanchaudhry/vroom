using UnityEngine;
using System.Collections;

public class StopSign : MonoBehaviour
{

    private bool enabled = true;
    private bool part2 = false;
    public ParticleSystem left, right;
    private ParticleSystem leftPS, rightPS;
    private Vector3 offset1, offset2;
    // Use this for initialization
    void Start()
    {
        offset2 = new Vector3(25, 10, -60);
        offset1 = new Vector3(25, 10, 40);
    }

    // Update is called once per frame
    void Update()
    {

        if (part2)
        {
            if (leftPS.startSpeed >= 1 && rightPS.startSpeed >= 1)
            {
                Destroy(leftPS);
                Destroy(rightPS);
                enabled = false;
                part2 = false;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Rigidbody>().velocity == Vector3.zero && !part2 && enabled)
            {
                part2 = true;
                leftPS = Instantiate(left, transform.position + offset1, left.transform.rotation) as ParticleSystem;
                rightPS = Instantiate(right, transform.position + offset2, right.transform.rotation) as ParticleSystem;
                other.GetComponent<PlayerProperties>().startRayCasting();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (enabled)
        {
            //fail
        }
        else
        {
            enabled = true;
        }
        Debug.Log(other);
        other.GetComponentInParent<PlayerProperties>().stopRayCasting();


    }
}
