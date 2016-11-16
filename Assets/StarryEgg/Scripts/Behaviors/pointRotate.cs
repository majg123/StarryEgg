using UnityEngine;
using System.Runtime.InteropServices;

public class pointRotate : MonoBehaviour
{
	[DllImport("org.example.rotaryevent")]
	static extern bool setFalse();

	[DllImport("org.example.rotaryevent")]
	static extern bool getClock();

	[DllImport("org.example.rotaryevent")]
	static extern bool getCounterClock();

    public static int count = 1;
    //public static float angle = 0;


    void Update()
    {
		if(Variables.behaviorSceneOn)
        	Rotate();
    }

    void Rotate()
    {
        //angle = transform.eulerAngles.z;

		if (getClock())
        {
			if (count >= 1 && count < 6) {
				//angle -= 45;
				//transform.localPosition = new Vector3 (0, -3.8f);
				//transform.RotateAround (Vector3.zero, Vector3.forward, -45.0f);
				this.transform.Rotate (0, 0, -45.0f);
				count++;

			}
			setFalse ();

        }
		else if (getCounterClock())
        {
			if (count>1 && count<=6) {
				//angle += 45;
				//transform.localPosition = new Vector3 (0, -3.8f);
				//transform.RotateAround (Vector3.zero, Vector3.forward, -45.0f);
				this.transform.Rotate (0, 0, 45.0f);
				count--;

			}
			setFalse ();
        }
    }
}
