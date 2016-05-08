using UnityEngine;
using System.Collections;

public class Curb : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Dude! You just hit the curb, wtf?");
        }
    }
}
