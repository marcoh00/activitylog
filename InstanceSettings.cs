using System;
using Microsoft.AspNetCore.Http;

namespace activitylog
{
    public interface IInstanceSettings
    {
        string Color { get;  }
    }
    public class RandomColorInstanceSettings : IInstanceSettings
    {
        public string Color { get; }

        public RandomColorInstanceSettings()
        {
            Color = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
        }
    }
}