public abstract class AbstractState<TContext>
	where TContext : StateMachine<TContext>
{
	public abstract void EnterState(TContext context);
	public abstract void UpdateState(TContext context);
	public abstract void ExitState(TContext context);
}

