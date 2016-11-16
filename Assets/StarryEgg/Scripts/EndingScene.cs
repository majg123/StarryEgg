using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour {
	Transform grass, night, star;

	// Use this for initialization
	void Start () {
		grass = GameObject.Find ("grass").GetComponent<Transform>();
		night = GameObject.Find ("night_Sky").GetComponent<Transform>();
		star = GameObject.Find ("littleBear").GetComponent<Transform>();

		StartCoroutine ("play");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 g_target = new Vector3 (0f, 4f, 0f);
		grass.position = Vector3.Lerp (grass.position, g_target, 0.02f);
		Vector3 n_target = new Vector3 (0f, 0f, 0f);
		night.position = Vector3.Lerp (night.position, n_target, 0.02f);
		Vector3 s_target = new Vector3 (0f, 90f, 0f);
		star.position =  Vector3.Lerp (star.position, s_target, 0.02f);
	}

	IEnumerator play(){
		yield return new WaitForSeconds (3f);
		Variables.isEnding = false; 
		Variables.newGame = 0;
		PlayerPrefs.SetInt ("newGame", Variables.newGame);

		Variables.charType = 1;
		PlayerPrefs.SetInt ("charType", Variables.charType);
		Variables.evolvePhase = 1;
		PlayerPrefs.SetInt ("evolvePhase", Variables.evolvePhase);
		Variables.gauge = 0;
		PlayerPrefs.SetFloat("Energy", Variables.gauge);
		Variables.walkCount = 0;
		PlayerPrefs.SetInt("walkCount", Variables.walkCount);
		Variables.exp = 0;
		PlayerPrefs.SetInt ("Exp", Variables.exp);

		PlayerPrefs.Save ();

		Variables.evolveReset ();

		Variables.evolving = false;
		Variables.curScene = 4;
		SceneManager.LoadScene (Variables.curScene);
	}
}
