using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*me auto to script to opoio einai attach panw sthn oasi elegxoume ama exei kanei ola ta aparaithta gia na piei nero
 * uparxoun sxolia pio katw gia ka8e shmeio tou kwdika
 * */
public class oasi : MonoBehaviour {
	//epikoinwnei o fps controler me to water kai to bottle me to water
	public GameObject character;
	public GameObject bottle;
	public bottle script;
	//epikoinwnei to water me thn mpara tou nerou 
	public GameObject water_bar;
	public WbarScript waterScript;
	//epikoinwnia oasis me text(script)
	public Text warning;

	 

	//metablhtes class
	public bool GetInWater= false;
	public bool drinkWater = false;
	public bool openDoor = false;
	// Use this for initialization
	void Start () {
		script = bottle.GetComponent<bottle>(); //sto script bazoume to script tou bottle
		waterScript = water_bar.GetComponent<WbarScript> (); // sto waterscript bazoume to script apo thn mpara tou nerou

	}
		
	//ama einai panw ston collider na ginetai true mia timh pou 8a xrhsimopooisoume pio katw 
	void OnTriggerEnter() {
		 GetInWater= true;

	}

	//ama bgei apo ton collider tote na kanei disabled to text
	void OnTriggerExit(){
		GetInWater= false;
		//3ana gyrnaw thn eikona off
		warning.enabled = false;
	}

	void Update () {
		//an pathsei q kai exei parei to mpoykali kai einai ston collider tote pinei nero
		if (Input.GetKey (KeyCode.Q) == true  && (script.takeit == true && GetInWater == true)) {
			openDoor = true;
			//grafw mesa sto text tou warning
			warning.text = "ooh well,you are alive!";
			//kanw  on to text tou warning
			warning.enabled = true;
			//Debug.Log ("very well,you are alive");
			waterScript.water_percentage = 0;
			waterScript.HandleWaterBar();
			drinkWater = true;
		}

		//an exei pathsei q exei pathsei ton collider kai den exei mpoykali den pinei nero
		if (Input.GetKey(KeyCode.Q) && GetInWater == true && script.takeit == false) {
			openDoor = true;
			//Debug.Log ("to drink water first find the bottle");
			warning.text = "To drink water,first you must take the bottle.";
			warning.enabled = true;
		}
	

	}
		
	}


	
