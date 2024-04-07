using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : AbstractState<PlayerStateMachine>
{
	public override void EnterState(PlayerStateMachine context)
	{
		context.StartCoroutine(_AttackCoroutine(context.PlayerDildoController.SwingDuration, context));
		context.PlayerDildoDamageController.Damage();
	}

	public override void ExitState(PlayerStateMachine context)
	{
		
	}

	public override void UpdateState(PlayerStateMachine context)
	{
		
	}

	private IEnumerator _AttackCoroutine(float duration, PlayerStateMachine context)
	{
		float backswingDuration = duration / 2f;
		float time = 0f;
		float phase = 0f;

		phase = 0f;
		time = 0f;

		while (time < duration)
		{
			time += Time.deltaTime;
			phase = time / duration;
			context.PlayerDildoController.Downswing(phase);
			yield return null;
		}

		phase = 0f;
		time = 0f;

		while (time < backswingDuration)
		{
			time += Time.deltaTime;
			phase = time / backswingDuration;
			context.PlayerDildoController.BackToNormal(phase);
			yield return null;
		}

		context.GoToIdle();
	}
}
