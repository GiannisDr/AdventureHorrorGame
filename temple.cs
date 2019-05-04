using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temple : MonoBehaviour {

	/*auto to script einai attach panw se ena aorato gameOblect to poio einai sthn eisodos tou naou kai efoson 
	 * o paixths mpei mesa tote epistrefei mia boolean sto script ths porta gia na 3erei oti exei paei 
	 * apo ton nao
	 * */

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
