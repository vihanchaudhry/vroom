using UnityEngine;

namespace Assets.Scripts.car
{
    public class BrakeLight : MonoBehaviour
    {
        public CarController Car; // reference to the car controller, must be dragged in inspector

        private Renderer m_Renderer;


        private void Start()
        {
            m_Renderer = GetComponent<Renderer>();
        }


        private void Update()
        {
            // enable the Renderer when the car is braking, disable it otherwise.
            m_Renderer.enabled = Car.BrakeInput > 0f;
        }
    }
}
