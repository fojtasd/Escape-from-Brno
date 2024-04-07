

using System;
using UnityEngine;

public abstract class StateMachine<TContext> : MonoBehaviour
	where TContext : StateMachine<TContext>
{
	public event Action<StateChangeDto<TContext>> StateChange;

	protected abstract AbstractState<TContext> CurrentState { get; set; }

	private StateChangeDto<TContext> _stateChangeDto = new StateChangeDto<TContext>();

	public void ChangeState(AbstractState<TContext> state)
	{
		_stateChangeDto.Origin = CurrentState;
		_stateChangeDto.Destination = state;

		CurrentState.ExitState(this as TContext);
		CurrentState = state;
		state.EnterState(this as TContext);

		StateChange?.Invoke(_stateChangeDto);
	}
}

