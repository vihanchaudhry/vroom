﻿using UnityEngine;
using System.Collections;

public class PedestrianCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("3");
            GameManager.Instance.AddDemerit(1);
            Destroy(gameObject);
        }
    }
}
