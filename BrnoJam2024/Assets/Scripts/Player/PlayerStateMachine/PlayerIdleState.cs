using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : AbstractState<PlayerStateMachine>
{
	public override void EnterState(PlayerStateMachine context)
	{
		
	}

	public override void ExitState(PlayerStateMachine context)
	{
		
	}

	public override void UpdateState(PlayerStateMachine context)
	{
		if(Input.GetKeyDown(KeyCode.Mouse1))
		{
			context.GoToCover();
		}
	}
}
