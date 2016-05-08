using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
		private bool isLeftBlinkering;
		private bool isRightBlinkering;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();

			isLeftBlinkering = false;
			isRightBlinkering = false;
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            float shifter = CrossPlatformInputManager.GetAxis("Pay Respects");

			float leftBlinker = CrossPlatformInputManager.GetAxis("Left Bumper");
			float rightBlinker = CrossPlatformInputManager.GetAxis("Right Bumper");

			// Handle Blinker logic
			PlayerProperties pp = GetComponent<PlayerProperties>();
			if (leftBlinker == 1) {
				if (!isLeftBlinkering) {
					if (pp.getBlinkerLeft()) {
						pp.setBlinkerLeft(false);
					} else {
						pp.setBlinkerLeft(true);
					}
					isLeftBlinkering = true;
				}
			}
			else
			{
				if (isLeftBlinkering) {
					isLeftBlinkering = false;
				}
			}

			if (rightBlinker == 1) {
				if (!isRightBlinkering) {
					if (pp.getBlinkerRight()) {
						pp.setBlinkerRight(false);
					} else {
						pp.setBlinkerRight(true);
					}
					isRightBlinkering = true;
				}
			}
			else
			{
				if (isRightBlinkering) {
					isRightBlinkering = false;
				}
			}

            m_Car.Move(h, v, v, handbrake, shifter);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
