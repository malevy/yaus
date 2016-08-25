using System.Threading.Tasks;

namespace yaus.Storage
{
    public interface ISlotStorage
    {
        Task<long> GetNextAvailableSlot();
    }
}