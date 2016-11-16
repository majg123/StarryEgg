using UnityEngine;
using System.Collections;

public class StarRotate : MonoBehaviour {

	public GameObject star;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		star.transform.Rotate (new Vector3 (0, 20, 0), Space.Self);
	}
}
