using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarScript : MonoBehaviour {
	//[serializeField] se periptwsh poy ta exoyme private me to serializefield mporoyme na exoyme public gia ligo tis metablhtes ston ispector
	 private float fillAmount;
	 public Image life_bar;
	//epikoinwnia fps me barscript kai bottle me barscript
	public GameObject character;
	public GameObject bottle;
	public bottle script;

	//epikoinwnia me waterbar kai barlife
	public GameObject wbar;
	public WbarScript wbarScript;

	//epikoinwnia me to text
	public Text lose;
	 
	//load screen
	 public string LoadLevel;
	//epikoinwnia me to terrain gia na milhsoume me to script
	public  GameObject terrain1;
	//pairnoume to script
	public storm storm_dmg;
	//ftiaxnoume to timer, oso pernaei o xronos toso pio grhgrora 8a katebainei to nero
	public float timer = 0f;
	// Use this for initialization
	void Start () {
		script = bottle.GetComponent<bottle>();
		wbarScript = wbar.GetComponent<WbarScript> ();
		storm_dmg = terrain1.GetComponent<storm> ();
	}
	
	// Update is called once per frame
	void Update () {
		//krataw tis times pou einai sto life_bar.fillAmount gia thn zwh sthn epomenh pista
		PlayerPrefs.SetFloat ("PlayerPref_Life",life_bar.fillAmount);
		if (wbarScript.GoToHealth == true) {
		TimerToLoseHealth ();
		}
		//elegxoume ama h metablhth apo to duststorm einai true,ama einai tote kaloume thn sunarthsh gia na xasei zwh
		if (storm_dmg.dmg_from_dustorm == true) {
			LoseHealthFromDust ();
		}

	}



	private void HandleLifeBar() {
		//function h opoia phgainei thn zwh  sto 100%
			life_bar.fillAmount = map (0, 0, 100, 0, 1);
	}

	//function h opoia toy meiwnei thn zwh kai otan paei sto 0 tote emfanizei thn skhnh poy xanei
	private void TimerToLoseHealth() {
			life_bar.fillAmount = life_bar.fillAmount - 0.20f / wbarScript.waitTime * Time.deltaTime;
		if (life_bar.fillAmount == 0) {
			SceneManager.LoadScene(LoadLevel);
			//lose.enabled = true;
			//Debug.Log ("ginetai true to lose");
			wbarScript.closeWarning = true;
			//Debug.Log ("to warning prepei na ginei false");
		}


	}

	//bazoume ton kwdika pou ama ton xtupaei to dustorm tote 8a xanei kapoio pososto apo thn zwh toy 
	//h sunarthsh auth 8a ginetai efoson elegxete mia boolean sthn update
	private void LoseHealthFromDust() {
		timer = timer + 1 * Time.deltaTime;
		//debug.log ton xrono gia na mporw na 3erw se pio deuterolepto eimai,ton kanw disable gia na mhn fainetai
		Debug.Log (timer.ToString ("0"));
		if (timer < 5) {
			life_bar.fillAmount = life_bar.fillAmount - 1.30f / wbarScript.waitTime * Time.deltaTime;
			//Debug.Log ("mphke sto prwto");
		}
		if (timer > 6) {
			life_bar.fillAmount = life_bar.fillAmount - 1.50f / wbarScript.waitTime * Time.deltaTime;
			//Debug.Log ("mphke sto deutero");
		}
		if (timer >= 5 && timer >= 10) {
			life_bar.fillAmount = life_bar.fillAmount - 1.70f / wbarScript.waitTime * Time.deltaTime;
			//Debug.Log ("mphke sto trito");
		}
		if (life_bar.fillAmount == 0) {
			SceneManager.LoadScene (LoadLevel);
		}
	}
		//h function poy upologizei to 30% tou fillamount gia na 3ekinaei apo ekei
	private float map(float value,float inMin,float inMax,float outMax,float outMin) {
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		//(50 - 0) * (1 - 0) / (100 - 0) + 0
		// 50 * 1 / 100 = 0.8;
	}
		
}
	