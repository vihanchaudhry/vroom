using UnityEngine;

namespace Assets.Scripts
{
    public class RightLaneDetection : MonoBehaviour {

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("You are in the slow lane.");
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("You have left the slow lane.");
            }
        }
    }
}