using System;
using System.Threading;
using System.Threading.Tasks;

namespace BaGetter.Protocol.Catalog;

/// <summary>
/// The NuGet Catalog resource is an append-only data structure indexed by time.<br/>
/// The <see cref="ICursor"/> tracks up to what point in the catalog has been successfully
/// processed. The value is a catalog commit timestamp.
/// </summary>
/// <remarks>
/// See: <see href="https://docs.microsoft.com/en-us/nuget/api/catalog-resource#cursor"/><br/>
/// Based off: <see href="https://github.com/NuGet/NuGet.Services.Metadata/blob/3a468fe534a03dcced897eb5992209fdd3c4b6c9/src/NuGet.Protocol.Catalog/ICursor.cs"/>
/// </remarks>
public interface ICursor
{
    /// <summary>
    /// Get the value of the cursor.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the task.</param>
    /// <returns>The cursor value. Null if the cursor has no value yet.</returns>
    Task<DateTimeOffset?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Set the value of the cursor.
    /// </summary>
    /// <param name="value">The new cursor value.</param>
    /// <param name="cancellationToken">A token to cancel the task.</param>
    Task SetAsync(DateTimeOffset value, CancellationToken cancellationToken = default);
}
