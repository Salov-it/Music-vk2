using AudioPopularService.Application.Interface;
using AudioPopularService.Domain;
using System.Diagnostics;

namespace AudioPopularService.Application.CQRS.Command.GetAudioPopular
{
    public class LoadingMp3 : ILooadin
    {
        string param1 = "-y" + " " + "-i";
        string param2 = "-c:a copy";
        string param3 = ".mp3";
        string param4 = @"./mp3/";
        char max = '"';

        GetAudioPopulaHandler getAudioPopulaHandler = new GetAudioPopulaHandler();
        public void LooadingMp3(List<AudioPopul> Audios)
        {
            for (int i = 0; i < Audios.Count; i++)
            {
                var audioUril = Audios[i].Urilvk;
                var audioName = Audios[i].Name;

                string text = param1 + " " + audioUril + " " + param2 + " " + param4 + max + audioName + max + param3;
                string text3 = string.Join(" ", text);

                Process process = new Process();
                string path6 = @"C:\Users\salov\Desktop\Программы\Githab\Music-vk2\src\WebApi\ffmpeg\ffmpeg.exe";
                process.StartInfo.FileName = path6;
                process.StartInfo.Arguments = text3;
                process.Start();
            }
        }
    }
}
