using UnityEngine;

namespace Assets.Scripts.car
{
    // this script is specific to the supplied Sample Assets car, which has mudguards over the front wheels
    // which have to turn with the wheels when steering is applied.

    public class Mudguard : MonoBehaviour
    {
        public CarController CarController; // car controller to get the steering angle

        private Quaternion _mOriginalRotation;


        private void Start()
        {
            _mOriginalRotation = transform.localRotation;
        }


        private void Update()
        {
            transform.localRotation = _mOriginalRotation*Quaternion.Euler(0, CarController.CurrentSteerAngle, 0);
        }
    }
}
