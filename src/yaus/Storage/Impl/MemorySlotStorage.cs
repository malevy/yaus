using System.Threading;
using System.Threading.Tasks;

namespace yaus.Storage.Impl
{
    public class MemorySlotStorage : ISlotStorage
    {
        private long _nextSlotIndex = 0;

        public Task<long> GetNextAvailableSlot()
        {
            var slotIndex = Interlocked.Increment(ref _nextSlotIndex);
            return Task.FromResult(slotIndex);
        }
    }
}