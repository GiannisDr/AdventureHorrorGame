using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*auto to script einai sthn mpara poy einai to nero gia na elegxoyme to pososto tou nerou
 * */
public class WbarScript : MonoBehaviour {
	//epoikinwnia ths maskas me to fill amount gia thn bara
	 public Image water_bar;
	 private float fillAmount;
	//epikoinwnia thw oashs me thn bara tou nerou
	 public GameObject character;
	 public GameObject bottle;
	 public bottle bottleScript;
	 public GameObject oasi;
	 public oasi oasiScript;

	//epikoinwnia thw baras me to text
	public Text warn;

	//variables this scope
	 public float water_percentage = 70; //pososto nerou  
	public float waitTime = 30.0f;
	 public float stop_watch = 60.0f;
	//an toy teleiwsei to nero na paei sthn zwh kai na thn meiwnei
	 public bool GoToHealth = false;
	//stamataw ton timer
	 public bool stop_timer = false;
	 private bool drink = false;
	 public bool closeWarning = false;
	//o timer pou 8a 3ekinsei pmolis pieis nero
	private float timerToDrinkWaterAgain = 0.0f;
	private int IntimerToDrinkWaterAgain = 0;
	//h boolean pou otan piei nero 8a ginei true kai 8a paei sthn fucntion gia na xasei 3ana nero gia na thn energopoihsei
	private bool water_timer = false;
	//epistrofh gia check

	//na ftia3w mia function h opoia 8a pairnei to lightflicker kai 8a xrhsimopoieite ama o fakos exei 3eperasei ta 4:30 lepta 
	void Start () {
		bottleScript = bottle.GetComponent<bottle>();
		oasiScript = oasi.GetComponent<oasi>();

	}
	
	// Update is called once per frame
	void Update () {
		//me thn playerpref pairnoyme to posost tou nerou 
		PlayerPrefs.SetFloat ("PlayerPref_Water", water_bar.fillAmount);
			TimerToLoseWater();
			AgainWater();
	}
	//me thn parakatw function bazoume to nero sto 30%
	public void HandleWaterBar() {
			water_bar.fillAmount = water (water_percentage, 0, 100, 0, 1);
	}

	//h function water fernei to apotelesma sthn apo panw function
	private float water(float value,float inMin,float inMax,float outMax,float outMin) {
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		//(50 - 0) * (1 - 0) / (100 - 0) + 0
		// 50 * 1 / 100 = 0.8;
}

	/* me thn parakatw function exoume ton timer poy 3ekinaei molis 3ekinhsei to paixnidi
	 * ama pesei o timer katw apo to mhden den bgazei allo to debug.log me ton xrono
	 * ama den exei parei to mpoykali kai den exei piei nero tote arxizei kai toy meiwnetai to nero
	 * ama to nero pesei sto 0 tote emfanizei ena text me pou ton proeidopoiei na piei amesws nero
	 * h GoToHealth einai mia metablhth o opoia ama exei pesei sto 0 paei sthn zwh kai 3ekinaei na thn meiwnei
	 * ama piei nero tote epistrecei h closeWarning kai kleinei to text
	 * */
	private void TimerToLoseWater() {
		stop_watch = stop_watch - Time.deltaTime;
		//an 8elw na mhn peftei to nero molis parei to mpoykali 
		if (bottleScript.takeit == false || oasiScript.GetInWater == false) {
			if (stop_watch > 0) {
				//debuglog tou timer gia to pote 8a pesei to nero 
				//Debug.Log ("timer " + stop_watch.ToString ("0"));
			
			}
			if (stop_watch < 0 && water_timer == false && (bottleScript.takeit == false || oasiScript.GetInWater == false)) {
				water_bar.fillAmount = water_bar.fillAmount - 0.35f / waitTime * Time.deltaTime;
				//zwh += 0.09f / 30 * timer
				//zwh  +=  ((0.09f)to poso to opoio 8a meionete) / 30(gia poso 8a meionete) * stop_watch pou einai meion time.deltatime
			}
			if (water_bar.fillAmount == 0) {
				warn.text = "You must drink water immediately for your life to increase or you will die.";
				warn.enabled = true;
				GoToHealth = true;
				//an h gotohealth gyrisei apo to script ths zwhs kai einai false tote to text warning ginetai false
				if (GoToHealth == false) {
					warn.enabled = false;
				}
				if (closeWarning == true) {
					warn.enabled = false;
				}
			}
			
		}
		/*ama exei parei to mpoykali kai einai panw ston collider tou nerou tote mporei na pathsei to Q
		 * kai na piei nero,tou bgazei ena text poy toy leei "pata Q gia na pieis nero"
		 * ama pathsei Q kai piei nero tote stamataei na peftei to pososto tou nerou h ths zwhs ama exei paei
		 * sthn zwh giati to nero einai hdh sto 0 
		 * kai tou gemizei to nero
		 * efoson piei mia fora kanei true thn water_timer 8a breite thn xrhsh ths sthn AgainWater function poy exw pio katw
		 * */

		if (bottleScript.takeit == true && oasiScript.GetInWater == true) {


			if (drink == false || water_timer == true) {
				if (water_bar.fillAmount != 1) {
					warn.text = "Press Q to drink water";
					warn.enabled = true;
				}
				if (Input.GetKey (KeyCode.Q)) {
					warn.enabled = false;
					stop_watch = 0;
					GoToHealth = false;
					drink = true;
					//to 3ana mhdewnizw etsi wste otan 3ana paei sthn againwater na 3ekinhsei o timer pali apo to 0 na metraei 
					timerToDrinkWaterAgain = 0;
					water_timer = true;

				}
			}
		}
	}

	/*efoson h water_timer einai truw tote exoume kapoia if kai enan timer ta opoia metrane kai oso pernaei o xronos
	 * meiwnoyn to nero pali kai oso pernaei h wra toso pio grhgora to meiwnoyn
	 * */
	public void AgainWater() {
		if (water_timer == true) {
			
			timerToDrinkWaterAgain = timerToDrinkWaterAgain + 1 * Time.deltaTime;
			Debug.Log (timerToDrinkWaterAgain.ToString ("0"));
			IntimerToDrinkWaterAgain = (int)timerToDrinkWaterAgain;
			if (IntimerToDrinkWaterAgain > 40 && IntimerToDrinkWaterAgain < 55) {
				water_bar.fillAmount = water_bar.fillAmount - 0.35f / waitTime * Time.deltaTime;
			} else if (IntimerToDrinkWaterAgain > 70 && IntimerToDrinkWaterAgain < 85) {
				water_bar.fillAmount = water_bar.fillAmount - 0.52f / waitTime * Time.deltaTime;
			} else if (IntimerToDrinkWaterAgain > 95 && IntimerToDrinkWaterAgain < 110) {
				water_bar.fillAmount = water_bar.fillAmount - 0.55f / waitTime * Time.deltaTime;
			} else if (IntimerToDrinkWaterAgain > 120) {
				water_bar.fillAmount = water_bar.fillAmount - 0.65f / waitTime * Time.deltaTime;
			}

		}


	}
		
}