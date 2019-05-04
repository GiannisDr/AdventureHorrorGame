using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour {
	//ama exei paei apo ton skeleto tote kanei true thn openDoor h opoia paei sto script ths portas
	public bool openDoor = false;

	void OnTriggerEnter() {
		openDoor = true;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
