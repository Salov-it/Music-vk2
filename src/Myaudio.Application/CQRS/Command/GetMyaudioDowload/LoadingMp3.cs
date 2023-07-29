using Myaudio.Application.CQRS.Interface;
using System.Diagnostics;

namespace Myaudio.Application.CQRS.Command.GetMyaudio
{
    public class LoadingMp3 : ILooadin
    {
        string param1 = "-y" + " " + "-i";
        string param2 = "-c:a copy";
        string param3 = ".mp3";
        string param4 = @"./mp3/";
        char max = '"';

        private readonly IContext _context;
        public LoadingMp3(IContext context)
        {
            _context = context;
        }
        public void LooadingMp3()
        {
             
            var myaudios = _context.Myaudio.ToList();
               
            for(int i = 0; i < myaudios.Count; i++)
            {
             
                var audioUril = myaudios[i].Urilvk;
                var audioName = myaudios[i].Name;

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
