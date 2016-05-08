using UnityEngine;
using System.Collections;

public class TrafficLight : MonoBehaviour
{

    public float greenTime;
    public float yellowTime;
    public float redTime;
    public GameObject greenLight;
    public GameObject yellowLight;
    public GameObject redLight;
    private float currentTime;
    public enum lights { green, yellow, red}
    public lights currentLight;

	// Use this for initialization
	void Start ()
	{
	    currentLight = lights.green;
	    StartCoroutine(GreenToYellow());
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (currentLight == lights.green)
	    {
	        greenLight.SetActive(true);
	        yellowLight.SetActive(false);
	        redLight.SetActive(false);
	    }
	    else if (currentLight == lights.yellow)
	    {
	        greenLight.SetActive(false);
	        yellowLight.SetActive(true);
	        redLight.SetActive(false);
	    }
	    else
	    {
            greenLight.SetActive(false);
            yellowLight.SetActive(false);
            redLight.SetActive(true);
        }
	}

    IEnumerator GreenToYellow()
    {
        currentLight = lights.green;
        yield return new WaitForSeconds(greenTime);
        StartCoroutine(YellowToRed());
    }

    IEnumerator YellowToRed()
    {
        currentLight = lights.yellow;
        yield return new WaitForSeconds(yellowTime);
        StartCoroutine(RedToGreen());
    }

    IEnumerator RedToGreen()
    {
        currentLight = lights.red;
        yield return new WaitForSeconds(greenTime);
        StartCoroutine(GreenToYellow());
    }
}
