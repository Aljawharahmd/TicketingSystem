using System;

namespace Ticketing.Integration.Options
{
    public class BiometricOptions
    {
        public string BaseAddress { get; set; }
        public double MatchingVoiceThreshold { get; set; }
        public bool MatchVoiceWithWords { get; set; }
        public int MatchVoiceScoreRatio { get; set; }
        public int MinMatchVoiceScoreRatio { get; set; }
        public double MinimumImageFaceSizeRatio { get; set; }
        public bool VoicesExtractTextDependentFeatures { get; set; }
        public bool CheckFromImageFaceSize { get; set; }
        public Guid AccountId{ get; set; }
        public bool TestMood { get; set; }
    }
}
