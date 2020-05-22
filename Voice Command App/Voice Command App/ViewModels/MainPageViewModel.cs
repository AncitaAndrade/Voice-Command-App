using Plugin.AudioRecorder;
using System;
using System.IO;
using System.Text;
using System.Windows.Input;
using Voice_Command_App.Views;
using Xamarin.Forms;
using System.Speech.Recognition;
using System.Speech.AudioFormat;

namespace Voice_Command_App.ViewModels
{
    public class MainPageViewModel
    {


        AudioRecorderService recorder;
        public ICommand ButtonClickCommand { get; set; }
        public ICommand StopCommand { get; set; }

        public string MainPageLabel { get; set; }
        public MainPageViewModel()
        {
            ButtonClickCommand = new Command(OnGotoNextPageButtonClicked);
            StopCommand = new Command(OnStopButtonClicked);
            MainPageLabel = "Welcome to Voice based App!";
            recorder = new AudioRecorderService
            {
                TotalAudioTimeout = TimeSpan.FromSeconds(15),
                StopRecordingOnSilence = true
            };
        }

        private async void OnStopButtonClicked()
        {
            if (recorder.IsRecording)
            {
                System.Diagnostics.Debug.WriteLine("Stopped");
                await recorder.StopRecording();
            }
            var filePath = recorder.GetAudioFilePath();
            AudioPlayer player = new AudioPlayer();
            System.Diagnostics.Debug.WriteLine("Playing");
            player.Play(filePath);
            System.Diagnostics.Debug.WriteLine(GetTextFromFile(filePath));
        }

        private string GetTextFromFile(string filePath)
        {
            System.Diagnostics.Debug.WriteLine("Get");
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
            Grammar gr = new DictationGrammar();
            sre.LoadGrammar(gr);
            sre.SetInputToWaveFile(filePath);
            sre.BabbleTimeout = new TimeSpan(Int32.MaxValue);
            sre.InitialSilenceTimeout = new TimeSpan(Int32.MaxValue);
            sre.EndSilenceTimeout = new TimeSpan(100000000);
            sre.EndSilenceTimeoutAmbiguous = new TimeSpan(100000000);

            StringBuilder sb = new StringBuilder();
            while (true)
            {
                try
                {
                    var recText = sre.Recognize();
                    if (recText == null)
                    {
                        break;
                    }

                    sb.Append(recText.Text);
                }
                catch (Exception ex)
                {
                    //handle exception      
                    //...

                    break;
                }
            }
            return sb.ToString();
        }

        private async void OnGotoNextPageButtonClicked()
        {
            //var nextPage = new SecondPage();
            //Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(nextPage);
           
            if (!recorder.IsRecording)
            {
                System.Diagnostics.Debug.WriteLine("Start Record");
                await recorder.StartRecording();
            }
            
        }
    }
}
