using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Howto_back : MonoBehaviour {

	public void back(){
		Variables.curScene = 3;
		SceneManager.LoadScene (Variables.curScene);
	}
}
