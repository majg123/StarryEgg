 using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public static class Variables
{
	public static String lastDay;

	public static bool behaviorSceneOn = false;
	public static bool statSceneOn = false;
	public static bool mainSceneOn = false;
    
	public static bool boolExp = false;
    public static bool SleepButton = false;
    public static bool BookButton = false;
    public static bool EatButton = false;
    public static bool CleanButton = false;
    public static bool ExerciseButton = false;
    public static bool PlayButton = false;

    public static int curScene = 0;

	public static int newGame;
	public static bool isEnding = false;

	public static int charType;
	public static int evolvePhase = 1;

    //public static float gauge = 1800;
	public static float gauge;
	public static int walkCount;
    public static int n = 1;
    public static float[] E = new float[8];
    public static float maxpd = 0;
    //public static int walkCount = PlayerPrefs.GetInt("walkCount", 0);
    public static int exp;

	public static int Health;
	public static int Cleanliness;
	public static int Satiety;
	public static int Stress;
	public static int Intelligence;

	//북극곰자리 캐릭터의  단계별 도감 오픈 여부. 0 = close, 1 = open
	public static int A1, A2, A3, A4, A5, A6;

	//public static Boolean boolEgg = true, boolBasic = false, boolGrown_basic=false;
	//public static Boolean finEgg = true, finBasic = false, finGrown_basic=false;
    
	public static Boolean boolMute = false;

	public static bool evolving = false;

    public static void expUp(int amount)
    {

		if (Variables.exp+amount < 100)
		{
            Variables.exp += amount;
			PlayerPrefs.SetInt ("Exp", Variables.exp);
			PlayerPrefs.Save ();
			evolving = false;
        }
        else
        {
			evolving = true;
			Variables.exp = 0;
			PlayerPrefs.SetInt ("Exp", Variables.exp);
			//PlayerPrefs.Save ();

			switch (Variables.evolvePhase) {
			case 1:	 //Egg -> evolve
				Variables.evolvePhase += 1;
				PlayerPrefs.SetInt ("evolvePhase", Variables.evolvePhase);
				PlayerPrefs.SetInt ("A2", 1);
				PlayerPrefs.Save ();
				break;
			case 2:		//유아기 -> evlove
				if (Variables.Health < 50) {	////////evolve Condition
					Variables.evolvePhase += 1; //3, white
					PlayerPrefs.SetInt ("evolvePhase", Variables.evolvePhase);
					PlayerPrefs.SetInt ("A3", 1);
					PlayerPrefs.Save ();
				} else {
					Variables.evolvePhase += 3; //5, black
					PlayerPrefs.SetInt ("evolvePhase", Variables.evolvePhase);
					PlayerPrefs.SetInt ("A5", 1);
					PlayerPrefs.Save ();
				}
				break;
			case 3:
				Variables.evolvePhase += 1;
				PlayerPrefs.SetInt ("evolvePhase", Variables.evolvePhase);
				PlayerPrefs.SetInt ("A4", 1);
			//	PlayerPrefs.Save ();
				break;
			case 4:
				Variables.isEnding = true; 		//Go to Ending Scene
				Variables.curScene = 8;
				SceneManager.LoadScene (Variables.curScene);
				break;
			case 5:
				Variables.evolvePhase += 1;
				PlayerPrefs.SetInt ("evolvePhase", Variables.evolvePhase);
				PlayerPrefs.SetInt ("A6", 1);
			//	PlayerPrefs.Save ();
				break;
			case 6:
				Variables.isEnding = true; 		//Go to Ending Scene
				Variables.curScene = 8;
				SceneManager.LoadScene (Variables.curScene);
				break;
			}
			//evolveReset ();
			Variables.gauge = Mathf.Clamp(Variables.gauge + 108000, 0, 216000);
			PlayerPrefs.SetFloat("Energy", Variables.gauge);

			PlayerPrefs.Save ();
        }
    }


	  public static void evolveReset(){
		Variables.Health = 0;
		Variables.Cleanliness = 0;
		Variables.Satiety = 0;
		Variables.Intelligence = 0;
		Variables.Stress = 0;
		PlayerPrefs.SetInt ("Health", Variables.Health);
		PlayerPrefs.SetInt ("Cleanliness", Variables.Cleanliness);
		PlayerPrefs.SetInt ("Satiety", Variables.Satiety);
		PlayerPrefs.SetInt ("Intelligence", Variables.Intelligence);
		PlayerPrefs.SetInt ("Stress", Variables.Stress);
		PlayerPrefs.Save ();

	}			

    public static float Map(float value, float inMin, float inMax, float outMin, float outMax)
    { //0~200,0,200,1(출력최대1)
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    public static float max(float a, float b)
    {
        if (a < b)
            return b;
        else
            return a;
    }

    // 임계값 갱신
    public static float threshold(int k)
    {
        float a;
        if (k == 1) return 2.0f;
        else if (k == 2) return (maxpd + 8.0f) / 5;
        else if (k == 3) return (maxpd + 6.0f) / 4;
        else if (k == 4) return (maxpd + 4.0f) / 3;
        else if (k == 5) return (maxpd + 2.0f) / 2;
        else if (k == 6) return maxpd;
        else
        {
            if (E[k - 1] < 3.3) a = 4.6f;
            else if (3.3f <= E[k - 1] && E[k - 1] < 3.6f) a = 4.8f;
            else if (3.6f <= E[k - 1] && E[k - 1] < 3.8f) a = 4.2f;
            else a = 4.1f;

            return (E[k - 1] * (10 * a + 1) - E[k - 6]) / 50;
        }
    }
}
