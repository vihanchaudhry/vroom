using UnityEngine;
using System.Collections;

public class Curb : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOverMenu();
        }
    }
}
