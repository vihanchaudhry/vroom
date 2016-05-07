using UnityEngine;

namespace Assets.Scripts
{
    public class LeftLaneDetection : MonoBehaviour {

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("You are in the fast lane.");
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("You have left the fast lane.");
            }
        }
    }
}
