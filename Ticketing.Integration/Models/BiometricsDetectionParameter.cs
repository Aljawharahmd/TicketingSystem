using System;
using Ticketing.Integration.Enums;
using Ticketing.Integration.Options;

namespace Ticketing.Integration.Models
{
    public class BiometricsDetectionParameter
    {
        public BiometricsDetectionParameter(BiometricOptions options, RecognizeDetectionMethod method)
        {
            FileType = method;
            MatchingVoiceThreshold = options.MatchingVoiceThreshold;
            MatchVoiceWithWords = options.MatchVoiceWithWords;
            MatchVoiceScoreRatio = options.MatchVoiceScoreRatio;
            MinMatchVoiceScoreRatio = options.MinMatchVoiceScoreRatio;
            MinimumImageFaceSizeRatio = options.MinimumImageFaceSizeRatio;
            VoicesExtractTextDependentFeatures = options.VoicesExtractTextDependentFeatures;
            CheckFromImageFaceSize = options.CheckFromImageFaceSize;
            AccountID = options.AccountId;
        }

        public RecognizeDetectionMethod FileType { get; }
        public double MatchingVoiceThreshold { get; }
        public bool MatchVoiceWithWords { get; }
        public int MatchVoiceScoreRatio { get; }
        public int MinMatchVoiceScoreRatio { get; }
        public double MinimumImageFaceSizeRatio { get; }
        public bool VoicesExtractTextDependentFeatures { get; }
        public bool CheckFromImageFaceSize { get; }
        public Guid AccountID { get; }

        /// <summary>
        /// Original, registered file
        /// </summary>
        public byte[] PrimaryFileBytes { get; set; }

        /// <summary>
        /// Login, recognizing file
        /// </summary>
        public byte[] SecondaryFileBytes { get; set; }
    }
}
