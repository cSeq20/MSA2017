using Newtonsoft.Json;
using System.Collections.Generic;

namespace MSATodo.Models
{
    public class SpellCheckSuggestion
    {
        public string Suggestion { get; set; }
        public double Score { get; set; }
    }

    public class FlaggedToken
    {
        public int offset { get; set; }
        public string Token { get; set; }
        public string Type { get; set; }
        public IList<SpellCheckSuggestion> suggestions { get; set; }
    }

    public class SpellCheckResult
    {      
        [JsonProperty("_type")]
        public string Type { get; set; }
        public IList<FlaggedToken> FlaggedTokens { get; set; }
    }
}
