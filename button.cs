using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*auto to script einai attach sto koumpi pou emfanizetai otan xasei o paixths,ama to pathsei tote toy 3ana fortwnei 
 * thn pista
 * */
public class button : MonoBehaviour {

	public void changemenuscene(string scenename) {
		
		SceneManager.LoadScene(scenename);
	}


}
