using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts
{
    public class IntersectionBlock : MonoBehaviour
    {
        public TrafficLight TrafficLight;

        void OnTriggerEnter(Collider other)
        {
            if (TrafficLight != null)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    if (TrafficLight.CurrentLight == TrafficLight.Lights.Red)
                    {
                        GameManager.Instance.GameOverMenu();
                    }
                }
            }
        }
    }
}
