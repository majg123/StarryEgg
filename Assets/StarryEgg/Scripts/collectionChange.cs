using UnityEngine;
using System.Collections;

public class collectionChange : MonoBehaviour {
	SpriteRenderer egg, baby, g1,g2,a1,a2;

	[SerializeField]
	private Sprite A1_S;
	[SerializeField]
	private Sprite A2_S;
	[SerializeField]
	private Sprite A3_S;
	[SerializeField]
	private Sprite A4_S;
	[SerializeField]
	private Sprite A5_S;
	[SerializeField]
	private Sprite A6_S;

	void Start () {
		egg = GameObject.Find ("Egg").GetComponent<SpriteRenderer> ();
		baby = GameObject.Find ("Baby").GetComponent<SpriteRenderer> ();
		g1 = GameObject.Find ("Growing_1").GetComponent<SpriteRenderer> ();
		g2 = GameObject.Find ("Growing_2").GetComponent<SpriteRenderer> ();
		a1 = GameObject.Find ("Adult_1").GetComponent<SpriteRenderer> ();
		a2 = GameObject.Find ("Adult_2").GetComponent<SpriteRenderer> ();

		if (Variables.A1 == 1) {
			egg.sprite = A1_S;
			egg.transform.localScale =  new Vector2( 1.1f , 0.8f);
		}
			
		if (Variables.A2 == 1) {
			baby.sprite = A2_S;
			baby.transform.localScale = new Vector3 (1.3f, 0.8f);
		}
			
		if (Variables.A3 == 1) {
			g1.sprite = A3_S;
			g1.transform.localScale = new Vector3 (1.1f, 0.65f);
		}
		if (Variables.A4 == 1) {
			a1.sprite = A4_S;
			a1.transform.localScale = new Vector3 (1.1f, 0.7f);
			//a1.transform.localPosition = new Vector2 (4.08f, 4.57f);
		} 
		if (Variables.A5 == 1) {
			g2.sprite = A5_S;
			g2.transform.localScale = new Vector3 (1.1f, 0.65f);
			//g2.transform.localPosition = new Vector2 (4.08f, 4.57f);
		} 
		if (Variables.A6 == 1) {
			a2.sprite = A6_S;
			a2.transform.localScale = new Vector3 (1.1f, 0.7f);
			//a2.transform.localPosition = new Vector2 (4.08f, 4.57f);
		} 
	}
	
	// Update is called once per frame
	void Update () {

	}
}
