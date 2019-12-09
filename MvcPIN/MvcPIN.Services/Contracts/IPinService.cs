using System.Collections.Generic;

namespace MvcPIN.Services.Contracts
{
    public interface IPinService
    {
        bool isValidPin(string pin);

        ICollection<T> GetAllPins<T>();
    }
}
