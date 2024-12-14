using System.Collections.Generic;
using Assets.Code.Infrastructure.SaveLoad;

namespace Assets.Code.Infrastructure.SaveLoadRegistry
{
    public interface ISaveLoadRegistryService
    {
        IEnumerable<IReadProgress> ProgressReaders { get; }
        IEnumerable<IWriteProgress> ProgressWriters { get; }
        void RegisterAsProgressReader(IReadProgress progressReader);
        void RegisterAsProgressWriter(IWriteProgress progressWriter);
    }
}