using UnityEngine;
using System.Collections;

public class ExpUp_Book : StateMachineBehaviour {
	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Variables.expUp(11);
	}

}
