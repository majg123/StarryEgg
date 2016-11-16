using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class characterSelect : MonoBehaviour {

	AsyncOperation async;
	bool isLoadGame = false;

	[SerializeField]
	private Text load; 

	public IEnumerator LoadMain_2(){
		if (isLoadGame == false) {
			isLoadGame = true;
			Variables.curScene = 1;
			async = SceneManager.LoadSceneAsync (Variables.curScene);

			while (async.isDone == false) {
				load.text = "Loading...";
				yield return null;
			}
		}
	}

	// Use this for initialization
	void Start () {
	}

	public void A_Click(){
		Variables.evolvePhase = 1;
		Variables.newGame = 1;
		PlayerPrefs.SetInt ("evolvePhase", Variables.evolvePhase);
		PlayerPrefs.SetInt ("A1", 1);
		PlayerPrefs.SetInt ("newGame", Variables.newGame);
		PlayerPrefs.Save ();
		StartCoroutine (LoadMain_2 ());
	}
}
