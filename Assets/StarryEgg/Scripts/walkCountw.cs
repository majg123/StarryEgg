using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;


public class walkCountw : MonoBehaviour
{
    
    private float x;
    private float y;
    private float z;
    private float e;

    
    // Update is called once per frame
    void Update()
    {
        getAcceleration();
        Count();
        HandleBar();
    }


    void HandleBar()
    {
        // 걸음 최대 10000 : 60%, 기본 하루 : 40%
        // 하루(86400s)에 40%차게 : 216000에 100차게
        Variables.gauge = Mathf.Clamp(Variables.gauge + Time.deltaTime, 0, 216000);
        PlayerPrefs.SetFloat("Energy", Variables.gauge);
        PlayerPrefs.Save();
    }


    void getAcceleration()
    {
        x = Input.acceleration.x;
        y = Input.acceleration.y;
        z = Input.acceleration.z;
        e = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2) + Mathf.Pow(z, 2));
    }

    void Count()
    {
        if (Variables.threshold(Variables.n) < e)
        {
            if (Variables.n > 7)
            {
                System.Array.Resize(ref Variables.E, Variables.E.Length + 1);
            }
            Variables.E[Variables.n] = e;
            Variables.walkCount++;
			// 5000보에 30%, 64800/216000 -> 1보에 0.006%참, 12.96/216000
			Variables.gauge += Variables.walkCount * 12.96f;

            PlayerPrefs.SetInt("walkCount", Variables.walkCount);
            PlayerPrefs.SetFloat("Energy", Variables.gauge);
            PlayerPrefs.Save();

            Variables.maxpd = Variables.max(Variables.maxpd, Variables.E[Variables.n]);
            Variables.n++;
            Thread.Sleep(300);   // 300ms이하는 카운트 안하게!!
        }
    }
}