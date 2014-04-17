using System;

namespace AzureTest.Foundations
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }

        DateTime Today { get; }
    }
}