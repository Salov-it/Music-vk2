using AudioSearchService.Application.Dto;
using AudioSearchService.Application.Interface;
using Myaudio.Domain;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AudioSearchService.Application.CQRS.Command
{
    internal class LoadingMp3 : ILooadin
    {

        string param1 = "-y" + " " + "-i";
        string param2 = "-c:a copy";
        string param3 = ".mp3";
        string param4 = @"./mp3/";
        char max = '"';

        GetAudioSearchHandler getAudioSearchHandler = new GetAudioSearchHandler();
        public void LooadingMp3(List<AudioSearcDto>Audios)
        {
            for (int i = 0; i < Audios.Count; i++)
            {
                var audioUril = Audios[i].Urilvk;
                var audioName = Audios[i].Name;

                string text = param1 + " " + audioUril + " " + param2 + " " + param4 + max + audioName + max + param3;
                string text3 = string.Join(" ", text);

                Process process = new Process();
                string path6 = @"./ffmpeg/ffmpeg.exe";
                process.StartInfo.FileName = path6;
                process.StartInfo.Arguments = text3;
                process.Start();
            }
        }

    }
}
