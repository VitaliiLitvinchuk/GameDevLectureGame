namespace Assets.Code.Infrastructure.GameStates.Api
{
    public interface IPayloadedEnterableState<in TPayload> : IState
    {
        void Enter(TPayload payload);
    }
}