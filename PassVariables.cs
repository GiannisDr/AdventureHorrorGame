using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassVariables : MonoBehaviour {
	/*me auto to script pernaw tis metablhtes apo thn mia skhnh sthn allh,ths zwhs kai tou nerou 
	 * to 1= true 
	 * to 0 = false
	 * */

	//sundesh me to helath_bar gia na baloume tis metablhtes apo thn mia skhnh sthn allh
	public Image health;
	//to fillAmount tou helath_bar pou 8a valoume ta dedomena apo thn prohgoymenh skhnh
	private float fillAmountH;
	//sundeh me to water_bar gia na baloume tis metablhtes apo thn mia skhnh sthn allh
	public Image water;
	//to fillAmount tou water_bar pou 8a valoume ta dedomena apo thn prohgoymenh skhnh
	private float fillAmountW;
	//int gia to playerprefs
	public int flashlightIcon;
	//syndesh me to eikonidio tou fakou
	public Image flashIcon;
	//int gia to playerprefs tou mpoukalioy
	public int  bottleIconS;
	public Image bottleIcon;
	// Use this for initialization


	void Start () {
		//bazoume ta dedomena apo thn prohgoymenh skhnh se auth
		health.fillAmount = PlayerPrefs.GetFloat ("PlayerPref_Life");
		water.fillAmount = PlayerPrefs.GetFloat ("PlayerPref_Water");
		//flashlightIcon = PlayerPrefs.GetInt ("PlayerPref_Flash");
		bottleIconS = PlayerPrefs.GetInt ("PlayerPref_Bottle");

        flashlightIcon = 1;

	}

	/*ama oi times einai 1 tote na einai enabled ta items pou htan kai sthn prwth skhnh
	 * ama oi times einai 0 tote na einai disabled ta items poy htan sthn prwth skhnh 
	 * */
	// Update is called once per frame
	void Update () {
		if (flashlightIcon == 1) {
			flashIcon.enabled = true;
			//Debug.Log ("1");
		} else if (flashlightIcon == 0) {
			flashIcon.enabled = false;
			//Debug.Log ("0");
		}

		if (bottleIconS == 1) {
			bottleIcon.enabled = true;
		} 

	}
}
