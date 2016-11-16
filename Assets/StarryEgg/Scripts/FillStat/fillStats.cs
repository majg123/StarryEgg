using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fillStats : MonoBehaviour {

    [SerializeField]
    private Image stressEgg;
    [SerializeField]
    private Image healthEgg;
    [SerializeField]
    private Image satietyEgg;
    [SerializeField]
    private Image intelligenceEgg;
    [SerializeField]
    private Image cleanlinessEgg;

    [SerializeField]
    private Text numStress;
    [SerializeField]
    private Text numHealth;
    [SerializeField]
    private Text numSatiety;
    [SerializeField]
    private Text numIntel;
    [SerializeField]
    private Text numClean;

    // Use this for initialization
    void Update () {
      

        stressEgg.fillAmount = Variables.Stress / 100f;
        numStress.text = Variables.Stress.ToString();

        healthEgg.fillAmount = Variables.Health / 100f;
        numHealth.text = Variables.Health.ToString();

        satietyEgg.fillAmount = Variables.Satiety / 100f;
        numSatiety.text = Variables.Satiety.ToString();

        intelligenceEgg.fillAmount = Variables.Intelligence / 100f;
        numIntel.text = Variables.Intelligence.ToString();

        cleanlinessEgg.fillAmount = Variables.Cleanliness / 100f;
        numClean.text = Variables.Cleanliness.ToString();

    }
	
	
}
