using UnityEngine;
using System.Collections;

public class ExpUp_Exercise : StateMachineBehaviour {

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Variables.expUp(10);
	}

}
