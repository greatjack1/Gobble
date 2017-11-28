using System;
using Gobble.Providers;
namespace Gobble.Keys
{
    /// <summary>
    /// API keystore.
    /// This interface is implemented by any class that wants to act as a key store.
    /// Its role is to provide api keys for any of the providers in the providers enumeration
    /// </summary>
    public interface IApiKeystore
    {
        String getKey(Provider Provider);
    }
}
