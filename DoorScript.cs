using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour {

	//epikoinwnia ths portas me ton fps controller 
	public GameObject character;
	//epikoinwnia door with text press
	public Text press;
	//sundesh oasis me door
	public GameObject oasi;
	public oasi oasi_script;
	//sundesi skeleton me door
	public GameObject skeleton;
	public skeleton skeleton_script;
	//sundesh temple me door 
	public GameObject temple;
	public temple temple_script;
	//sundesh me to mpoukali 
	public GameObject bottle;
	public bottle bottle_script;
	//variables in this scope
	private bool InColliderOfDoor = false;
	private float test;
	private bool CloseOnTrigger = false;
	//sundeoume thn porta poy exei ton animator
	public GameObject door;
	public Animator anime;


	/*auto to script einai attach panw sthn porta,ama exei kanei tis aparaithtes kinhseis,opws na paei sthn oash na piei nero
	 * kai na paei apo ton nao tote den mporei na anoi3ei thn porta 
	 * oso phgainei ston porta kai den exei kanei kati apo ta parapanw h porta den anoigei kai toy leei 
	 * na e3ereynhsei thn pista
	 * */

	void Start () {
		//pairnoyme to animation gia thn porta
		anime = door.GetComponent<Animator> ();
	}

	void OnTriggerEnter() {
		//ama einai ston collider ths portas na emfaniei to text 
		InColliderOfDoor = true;
		if (CloseOnTrigger == false) {
			press.enabled = true;
		}
		
	}

	//ama den einai ston collider na kanei disabled to text
	void OnTriggerExit() { 
		InColliderOfDoor = false;
		press.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		//an isxuoyn ola ta parakatw sto if tote na emfanizei to texr pou tou leei na pathsei E gia na to anoi3ei
		if (InColliderOfDoor == true && oasi_script.openDoor == true && temple_script.openDoor == true && skeleton_script.openDoor == true   && bottle_script.takeit == true) {
			press.text = "Press E to open";
			//ama pathsei to E tote paizei to animation gia kanei disabled to text 
			if (Input.GetKey (KeyCode.E)) { 
				//transform.position = transform.position + Vector3.down * Time.deltaTime;	ama to patagame paratetame 8a katebaine me to transform.position
				anime.enabled = true;
				if (anime.enabled == true) {
					press.enabled = false;
					CloseOnTrigger = true;
					//Debug.Log ("eprepe na sbhsei");
				}
			}
		}
		//an den exei kanei kati apo ta aparaithta gia na anoi3ei h porta tote toy leei na e3ereunhsei thn pista
		if (InColliderOfDoor == true && oasi_script.openDoor == false && temple_script.openDoor == false && skeleton_script.openDoor == false) {
			press.text = "You must explore the whole area for the door to open";
		} 
		//ama exei piei nero tote toy leei na paei apo ton nao(ton bohthame kai ligo)
		if (temple_script.openDoor == false && InColliderOfDoor == true) {
			press.text = "You must go to the temple";
		}



	}

}
