using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaseClosed.Tests.WebTests
{
    class CodedUITestSettings
    {
        /// <summary> Test startup. </summary>
        public static void StartTest()
        {
            // Configure the playback engine
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.MaximumRetryCount = 10;
            Playback.PlaybackSettings.ShouldSearchFailFast = false;
            Playback.PlaybackSettings.DelayBetweenActions = 500;
            Playback.PlaybackSettings.SearchTimeout = 5000;

            // Add the error handler
            Playback.PlaybackError -= Playback_PlaybackError; // Remove the handler if it's already added
            Playback.PlaybackError += Playback_PlaybackError; // Ta dah...
        }

        /// <summary> PlaybackError event handler. </summary>
        private static void Playback_PlaybackError(object sender, PlaybackErrorEventArgs e)
        {
            // Wait a second
            System.Threading.Thread.Sleep(1000);

            // Retry the failed test operation
            e.Result = PlaybackErrorOptions.Retry;
        }
    }
}
