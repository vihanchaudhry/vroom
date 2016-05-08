using UnityEngine;
using System.Collections;

public class Curb : MonoBehaviour {

    void OnCollisionEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Dude! You just hit the curb, wtf?");
        }
    }
}
