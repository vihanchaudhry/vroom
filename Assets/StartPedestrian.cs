using UnityEngine;
using System.Collections;

public class StartPedestrian : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<PedestrianWalk>().turnOn(other.GetComponentInParent<PlayerProperties>());
        }
    }
}
