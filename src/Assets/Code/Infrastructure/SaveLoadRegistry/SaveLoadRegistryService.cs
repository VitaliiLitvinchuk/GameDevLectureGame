using System.Collections.Generic;
using Assets.Code.Infrastructure.SaveLoad;

namespace Assets.Code.Infrastructure.SaveLoadRegistry
{
    public class SaveLoadRegistryService : ISaveLoadRegistryService
    {
        private readonly List<IReadProgress> _progressReader = new();
        private readonly List<IWriteProgress> _progressWriter = new();
        public IEnumerable<IReadProgress> ProgressReaders { get => _progressReader; }
        public IEnumerable<IWriteProgress> ProgressWriters { get => _progressWriter; }

        public void RegisterAsProgressReader(IReadProgress progressReader)
        {
            _progressReader.Add(progressReader);
        }

        public void RegisterAsProgressWriter(IWriteProgress progressWriter)
        {
            _progressWriter.Add(progressWriter);
        }
    }
}