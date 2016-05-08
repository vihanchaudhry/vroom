using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts
{
    public class IntersectionBlock : MonoBehaviour
    {
        public TrafficLight TrafficLight;
        private bool check = false;

        void OnTriggerEnter(Collider other)
        {
            if (TrafficLight != null)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    if (TrafficLight.CurrentLight == TrafficLight.Lights.Red)
                    {
                        if (check)
                        {
                            GameManager.Instance.GameOverMenu(GameManager.Errors.RanRed);
                            check = false;
                        }
                    }
                }
            }
        }
        public void setCheck(bool b)
        {
            check = b;
        }
    }


}
