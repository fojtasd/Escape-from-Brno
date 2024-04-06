using UnityEngine;

public class PlayerCoverState : AbstractState<PlayerStateMachine>
{
	public override void EnterState(PlayerStateMachine context)
	{
		context.PlayerCoverController.SetCoverActive(true);
	}

	public override void ExitState(PlayerStateMachine context)
	{
		context.PlayerCoverController.SetCoverActive(false);
	}

	public override void UpdateState(PlayerStateMachine context)
	{

		if(Input.GetKeyUp(KeyCode.Mouse1))
		{
			context.GoToIdle();
			return;
		}

		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			context.GoToAttack();
			return;
		}
	}
}
