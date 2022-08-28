using System;
using Newtonsoft.Json;

namespace BerkutBotDataCollector.Helpers
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object source) => JsonConvert.SerializeObject(source);
    }
}

