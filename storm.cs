using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storm : MonoBehaviour {
	//sundesh paixth me terrain
	//public GameObject character;
	public ParticleSystem dust;

	public bool exit = false;
	public bool dmg_from_dustorm = false;


	/*1) an eisai mesa sto prwto terrain tote to dustorm einai kleisto enw ama bgeis pros ta e3w 
	 * an eisai e3w apo to prwto terrain,dhladh se xtupaei h amothiella tote to script 8a stelnei
	 * thn metablhth dmg_from_dustorm pou 8a einai true sto life_bar gia na meiwnetai h zwh */


	void Start() {
	}

	// Update is called once per frame
	void Update () {
		/*ama h exit einai false tote na stamathsei to particle tou dust alliws ama einai true na pai3ei to 
		 * to particle tou dust
		 * */
		if (exit == false) {
			dust.Stop();
		} else if  (exit == true) {
			dust.Play();

		}
			
	}
	/*ama einai mesa ston collider tou prwtou terrain tote to exit na ginetai false gia na mhn pai3i to particle
	 * kai ama einai true tote na pai3ei to particle tou dust
	 * */
	void OnTriggerStay() {
		exit = false;
		dmg_from_dustorm = false;
	}

	void OnTriggerExit() {
		exit = true;
		dmg_from_dustorm = true;
	}
}
