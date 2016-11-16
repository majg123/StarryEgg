using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class collection : MonoBehaviour {

    public void click()
    {
	//	Variables.selectType = 1;
		Variables.A1 = PlayerPrefs.GetInt ("A1", 0);
		Variables.A2 = PlayerPrefs.GetInt ("A2", 0);
		Variables.A3 = PlayerPrefs.GetInt ("A3", 0);
		Variables.A4 = PlayerPrefs.GetInt ("A4", 0);
		Variables.A5 = PlayerPrefs.GetInt ("A5", 0);
		Variables.A6 = PlayerPrefs.GetInt ("A6", 0);

		Variables.curScene = 5;
		SceneManager.LoadScene(Variables.curScene);
    }
}
