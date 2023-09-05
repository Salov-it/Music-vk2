using Myaudio.Application.Interface;
using Myaudio.Domain;
using System.Diagnostics;

namespace Myaudio.Application.CQRS.Command.PostDownloadAudio
{
    public class LoadingMp3 : ILooadin
    {
        string param1 = "-y" + " " + "-i";
        string param2 = "-c:a copy";
        string param3 = ".mp3";
        string param4 = @"./mp3/";
        char max = '"';

        public void LooadingMp3(DownloadAudioModels downloadAudio)
        {
           
           string text = param1 + " " + downloadAudio.Urilvk + " " + param2 + " " + param4 + max + downloadAudio.Name + max + param3;
           string text3 = string.Join(" ", text);

           Process process = new Process();
           string path6 = @".\ffmpeg\ffmpeg.exe";
           process.StartInfo.FileName = path6;
           process.StartInfo.Arguments = text3;
           process.Start();
          
        }
    }
}
