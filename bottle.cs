using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bottle : MonoBehaviour
{
	//epikoinwnia bottle me cameras
	public GameObject character;
	//bazoume 3ana to idio object gia na mporoume na to kanoume set.active = false
	public GameObject mpoukali;
	//to icon tou mpoukaliou gia otan paroume to mpoukali
	public Image bottle_icon;
	//to text gia na pathsei E kai na parei to mpoukali
	public Text press;
	//variables this scope
	public bool ontrigger = false;
	public bool takeit = false;
	//ama parei to mpoukali tote auth h metablhth 8a paei sthn epomenh skhnh kai 8a exei energo to mpoukali
	public int passBottl;


	/*me auto to script ama einai trigger o collider tote emfanizei to mhnyma na pathsei E gia na parei to mpoykali
	 * ama to pathsei tote na kanei disabled to text na emfananizei to mpoykali sto UI kai na kanei disabled 
	 * to object tou mpoukalioy efoson to parei to mpoykali me thn playerPref pairnoume mia metablhth integer poy
	 * thn xrhsimopoiw ws boolean gia na perasw sthn epomenh skhnh ama exei to mpoykali h oxi
	 * h takeit xrhsimopοieitai gia na mporei na piei nero efoson exei to mpoykali
	 * */

	void OnTriggerEnter ()
	{
		ontrigger = true;
	}

	void OnTriggerExit ()
	{
		ontrigger = false;
		press.enabled = false;
	}

	void Update ()
	{	
		if (ontrigger == true) {
			press.text = "Press E to take the bottle";
			press.enabled = true;
			if (Input.GetKey (KeyCode.E) && ontrigger == true) {
				press.enabled = false;
				//Debug.Log ("katastrafhke");
				mpoukali.SetActive (false);
				bottle_icon.enabled = true;
				takeit = true;
				if (bottle_icon.enabled == true) {
					passBottl = 1;
					PlayerPrefs.SetInt ("PlayerPref_Bottle", passBottl);
				} else if (bottle_icon.enabled == false) {
					passBottl = 0;
					PlayerPrefs.SetInt ("PlayerPref_Bottle", passBottl);
				} 
			}

		} 
		if (takeit == true) {
			press.enabled = false;
		}

	}
}
