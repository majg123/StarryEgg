using UnityEngine;
using UnityEngine.UI;

public class behaviorText : MonoBehaviour
{
    [SerializeField]
    private Text CurAction_Text;

	[SerializeField]
	private Text BehaviorGaugeText;

    void Update()
    {
        switch (pointRotate.count)
        {
		case 1:
			CurAction_Text.text = "Sleeping";
			BehaviorGaugeText.text = "-2.5%";
                break;
		case 2:
			CurAction_Text.text = "Washing";
			BehaviorGaugeText.text = "-1.5%";
                break;
		case 3:
			CurAction_Text.text = "Playing";
			BehaviorGaugeText.text = "-1%";
                break;
		case 4:
			CurAction_Text.text = "Reading";
			BehaviorGaugeText.text = "-1.3%";
                break;
		case 5:
			CurAction_Text.text = "Exercising";
			BehaviorGaugeText.text = "-2%";
                break;
		default:
			CurAction_Text.text = "Eating";
			BehaviorGaugeText.text = "-1.5%";
                break;
        }
    }
}
