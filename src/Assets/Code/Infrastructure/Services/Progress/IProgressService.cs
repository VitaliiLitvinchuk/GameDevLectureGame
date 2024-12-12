using Assets.Code.Data;

namespace Assets.Code.Infrastructure.Services.Progress
{
    public interface IProgressService
    {
        PlayerProgress PlayerProgress { get; set; }
    }
}