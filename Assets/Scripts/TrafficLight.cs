using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class TrafficLight : MonoBehaviour
    {

        public float GreenTime;
        public float YellowTime;
        public float RedTime;
        public GameObject GreenLight;
        public GameObject YellowLight;
        public GameObject RedLight;
        public enum Lights { Green, Yellow, Red}
        public Lights CurrentLight;

        // Use this for initialization
        void Start ()
        {
            CurrentLight = Lights.Green;
            StartCoroutine(GreenToYellow());
        }
	
        // Update is called once per frame
        void Update ()
        {
            if (CurrentLight == Lights.Green)
            {
                GreenLight.SetActive(true);
                YellowLight.SetActive(false);
                RedLight.SetActive(false);
            }
            else if (CurrentLight == Lights.Yellow)
            {
                GreenLight.SetActive(false);
                YellowLight.SetActive(true);
                RedLight.SetActive(false);
            }
            else
            {
                GreenLight.SetActive(false);
                YellowLight.SetActive(false);
                RedLight.SetActive(true);
            }
        }

        IEnumerator GreenToYellow()
        {
            CurrentLight = Lights.Green;
            yield return new WaitForSeconds(GreenTime);
            StartCoroutine(YellowToRed());
        }

        IEnumerator YellowToRed()
        {
            CurrentLight = Lights.Yellow;
            yield return new WaitForSeconds(YellowTime);
            StartCoroutine(RedToGreen());
        }

        IEnumerator RedToGreen()
        {
            CurrentLight = Lights.Red;
            yield return new WaitForSeconds(GreenTime);
            StartCoroutine(GreenToYellow());
        }
    }
}
