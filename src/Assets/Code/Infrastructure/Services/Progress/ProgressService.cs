using Assets.Code.Data;

namespace Assets.Code.Infrastructure.Services.Progress
{
    public class ProgressService : IProgressService
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}