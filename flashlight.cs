using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashlight : MonoBehaviour
{
	//epikoinwnia flash me cameras
	public GameObject character;
	//to icon tou fakou gia na emfanistei otan to paroume
	public Image flash_icon;
	//bazoume 3ana to idio object gia na mporoume na to kanoume set.active = false
	public GameObject flashl;
	//to text gia na pathsei E kai na parei to mpokali
	public Text press;
	//variables this scope
	public bool ontrigger = false;
	//ama parei ton fako tote auth h metblhth 8a paei sthn epomenh skhnh kai 8a exei energo ton fako
	public int passFlas;

	/*to script auto einai parommoio me to bottle script,ama mpei ston collider tote ginetai trigger
	 * emfanizetai to text gia na pathsei E gia na to parei,ama to pathsei tote ginetai disabled to object tou fakou
	 * emfanizetai ston canva to icon toy fakou kai kala oti to exei,kai efoson parei ton fako h den ton parei
	 * tote me thn playerPref pou einai int poy thn xrhsimopoiw ws boolean gia na metaferw ta dedomena 
	 * sthn allh skhnh
	 * */

	void awake () {
		PlayerPrefs.DeleteAll();
	}

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
			press.enabled = true;
			press.text = "Press E to take the flashlight";
			if (Input.GetKey (KeyCode.E) && ontrigger == true) {
				flashl.SetActive (false);
				flash_icon.enabled = true;
			}
		} 
		if (flash_icon.enabled == true) {
			press.enabled = false;
		}

		if (flash_icon.enabled == true) {
			passFlas = 1;
			PlayerPrefs.SetInt ("PlayerPref_Flash", passFlas);
		} else if (flash_icon.enabled == false) {
			passFlas = 0;
			PlayerPrefs.SetInt ("PlayerPref_Flash", passFlas);

		}
	}
}
