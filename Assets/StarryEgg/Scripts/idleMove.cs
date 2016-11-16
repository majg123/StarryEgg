using UnityEngine;
using System.Collections;

public class idleMove : MonoBehaviour {
	Animator anim;
	public float speed = 1.0f;  
	static float rand;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		StartCoroutine (idle ());
	}

	// Update is called once per frame
	void Update () {
		if (Variables.evolvePhase != 1) {
			if (rand < 0.5) {
				Vector3 target = transform.position + new Vector3 (-1, 0, 0);
				transform.position = Vector3.Lerp (transform.position, target, speed * Time.deltaTime);
			} else if (rand > 1.5) {
				Vector3 target = transform.position + new Vector3 (1, 0, 0);
				transform.position = Vector3.Lerp (transform.position, target, speed * Time.deltaTime);
			}
		}
	}

	IEnumerator idle(){
		while (true) {
			rand = Random.value*2;
			anim.SetFloat ("Blend", rand);
			yield return new WaitForSeconds (3.0f);
		}
	}
}

