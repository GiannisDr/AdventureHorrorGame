using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*me auto to script pernaw ton paixth sthn epomenh pista,einai attach panw se ena aorato gameObject to opoio einai
 * mesa sthn porta kai efoson thn anoi3eis kai mpeis mesa ston collider se bgazei sthn allh pista
 * */

public class changeToMaze : MonoBehaviour {
	//h metablhth poy einai h epomenh pista
	 public string LoadLevel_2;

	void OnTriggerEnter() {


		SceneManager.LoadScene(LoadLevel_2);


	}

}
