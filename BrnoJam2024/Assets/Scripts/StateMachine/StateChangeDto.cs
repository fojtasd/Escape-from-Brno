public struct StateChangeDto<TContext>
	where TContext : StateMachine<TContext>
{
	public AbstractState<TContext> Origin { get; set; }
	public AbstractState<TContext> Destination { get; set; }
}