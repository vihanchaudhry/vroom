using UnityEngine;
using System.Collections;
using Assets.Scripts.car;

public class Speedometer : MonoBehaviour {

    private TextMesh tm;
    private CarController cc;

	// Use this for initialization
	void Start () {
        tm = GetComponent<TextMesh>();
        cc = GetComponentInParent<CarController>();
	}
	
	// Update is called once per frame
	void Update () {
        tm.text = ((int)(cc.CurrentSpeed)).ToString();
	}
}
