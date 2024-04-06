using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine<PlayerStateMachine>
{
	protected override AbstractState<PlayerStateMachine> CurrentState { get; set; }

	public PlayerCoverController PlayerCoverController => _playerCoverController;
	public PlayerDildoController PlayerDildoController => _playerDildoController;
	public Player Player => _player;

	[SerializeField] private PlayerCoverController _playerCoverController;
	[SerializeField] private PlayerDildoController _playerDildoController;
	[SerializeField] private Player _player;
 
	private PlayerIdleState _idleState = new PlayerIdleState();
	private PlayerCoverState _coverState = new PlayerCoverState();
	private PlayerAttackState _attackState = new PlayerAttackState();

	private void Awake()
	{
		CurrentState = _idleState;
	}

	private void Update()
	{
		CurrentState.UpdateState(this);
	}

	public void GoToCover()
	{
		ChangeState(_coverState);
	}

	public void GoToIdle()
	{
		ChangeState(_idleState);
	}

	public void GoToAttack()
	{
		ChangeState(_attackState);
	}
}
