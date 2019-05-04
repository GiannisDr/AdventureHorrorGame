using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class flashh : MonoBehaviour {
	/*auto to script to exw onomasei flashh alla mono gia ton flashh den einai
	 * elexoyme ama exei parei ton fako sthn prwth pista na mporei na thn xrhsimopoieisei kai sthn deyterh
	 * ama exei parei ton fako tote exei kai kapoio xroniko diasthma na ton xrhsimopoieisei giati 
	 * teleiwnoyn kai oi mpataries toy fakou 
	 * oso ton xrhsimopoiei yparxei enas timer poy katagrafei poso ton exei anoixto
	 * oso pernane kapoia lepta o fakos arxizei kai meiwnei to fos toy,ws poy 8a ftasei se ena shmeio poy
	 * 8a kanei flickering,otan o xronos ftasei sto teliko stadio toy tote o fakos kleinei
	 * */
	public GameObject FPS_player;
	//oi idiotites tou spotlight
	public Light spotlight;
	//diakopths gia na 3eroume pote einai anoixtos o fakos kai pote kleistos
	public bool flash_on = false;
	//timer se float gia na kratame ton xrono
	private float timer = 0.0f;
	//me thn bool timerEnabled 3eroyme pote na metrame ton xrono 
	//kai pote na to stamatame ekei pou emeine
	private bool timerEnabled = false;
	//me ton int int_timer kanoume to timer apo float se int gia na mporoyme na kanoume tis sygkriseis 
	//sthn LoseIntensity() 
	private int int_timer = 0;

	//h arxikh mas 8esh se periptwsh pou pe8anoume mas 3ana bgazei apo thn arxh
	public Vector3 startPosition;
	//sudensh me to image
	public Image iconFlash;
	//o kwdikas gia to lightflicker 
	public LightFlickerEffect lightFlicker;
	// Use this for initialization
	void Start () {
		//pairnoyme to script gia to lightflicker toy fakou pou 8a kanoume pio katw
		lightFlicker = FPS_player.GetComponent<LightFlickerEffect> ();

		//pairnoyme thn arxikh 8esh tou paixth
		startPosition = transform.position;
        iconFlash.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        //iconFlash.enabled = true;
		//an exei parei ton fako tote na mporei na pathsei to f gia na ton xrhsimopoihsei 
		if (iconFlash.enabled == true) {
			//an pathsei to koumpi f tote kalei thn function gia na anoi3ei to fako
			if (Input.GetKeyDown ("f")) {
				openlight ();
			}
			//h function gia ton xrono 
			FlashlightTimer ();
			//function gia na arxizei na kleinei o fakos
			LoseIntensity ();

		} 

	}


	//an path8ei to f tote kaleite h parakatw function
	//h opoia an o fakos einai anoixtos tote ton kleinei 
	//kai ama o fakos einai anoixtos energopoiei mia boolean h opoia leei sthn function gia ton xrono
	//na krataei xrono 
	public  void openlight() {
		if (flash_on == true) {
			spotlight.enabled = true;
			flash_on = false;
			timerEnabled = true;


		} else if (flash_on == false) {
			spotlight.enabled = false;
			flash_on = true;
			timerEnabled = false;
		}

		}

	//oso einai anoixtos o fakos tote o timer metraei ta lepta gia na ta steilei sthn lose intensity
	//etsi wste na 3ekinsei na sbhnei o fakos
	public void FlashlightTimer(){
		if (timerEnabled == true) {
			timer = timer + 1 * Time.deltaTime;
		} 
		Debug.Log (timer.ToString("0"));
	}

	//otan o timer parei kapoies times tote 8a peftei to intensity kai to spot angle toy fakou
	//
	public void LoseIntensity() {
		int_timer = (int)timer;
		/*default times 
		 * gia spotAngle = 90 
		 * gia intensity = 6.88f
		 * */
		if (int_timer >= 60) {
			spotlight.spotAngle = 80;
			spotlight.intensity = 5.00f;
		}
		if (int_timer > 85) {
			spotlight.spotAngle = 60;
			spotlight.intensity = 4.5f;
		}
		if (int_timer > 100) {
			spotlight.spotAngle = 55;
			spotlight.intensity = 4.5f;
		} 
		if (int_timer > 120) {
			//setaroume apo thn arxh ton fako gia na deixnei pws anavosbinei 
			spotlight.spotAngle = 80;
			spotlight.intensity = 5.00f;
			lightFlicker.enabled = true;
		}

		if (int_timer > 135) {
			lightFlicker.enabled = false;
			spotlight.intensity = 0.00f;
			spotlight.spotAngle = 00;
		}

	}
	//na ftia3w tag gia to keno pou pefteis kai se 3ana paei sthn arxh 
	//me thn ontriggerenter elegxoyme ama pesei sto keno tote na 3ana paei apo thn arxh o paixths
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "VoidTrad") {
			BeginFromStart ();
		}
	}

	/*auth thn fucntion thn xrhsimopoioyme ama einai attach sto tag toy kenou tote ton petaei pali sthn arxikh
	 * tou 8esh
	 * */
	public void BeginFromStart(){
		transform.position = startPosition;


	}


	}


