using UnityEngine;

namespace Assets.Scripts
{
    public class RightLaneDetection : MonoBehaviour
    {

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerProperties pp = other.GetComponent<PlayerProperties>();
                if (pp.isMerging())
                {
                    if (!pp.getBlinkerRight())
                    {
                        Debug.Log("You didn't have your right blinker on!");
                    }
                }
                pp.setMerging(false);
                Debug.Log("You are in the slow lane.");
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerProperties>().setMerging(true);
                Debug.Log("You have left the slow lane.");
            }
        }
    }
}