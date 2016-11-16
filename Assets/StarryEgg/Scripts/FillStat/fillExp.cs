using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fillExp : MonoBehaviour {

    [SerializeField]
    private Image content; 
	// Use this for initialization
	void Update () {
        content.fillAmount = Variables.exp / 100f;
    }
	
}
