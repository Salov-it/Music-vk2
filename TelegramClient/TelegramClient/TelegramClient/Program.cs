using Music_vk_Client_Api.Api;
using Music_vk_Client_Api.Api.GetAudioPopular;
using Music_vk_Client_Api.Api.GetAudioSearch;
using Music_vk_Client_Api.Api.GetMyaudio;
using Music_vk_Client_Api.Api.GetUser;
using Music_vk_Client_Api.Config;



PostUser getUser = new PostUser();
GetAudioSearch getAudioSearch = new GetAudioSearch();
GetMyaudio getMyaudio = new GetMyaudio();

var Content = await getUser.User("89244452428","Salov1999");
Console.WriteLine(Content);

var Content2 = await getMyaudio.MyAudio(3);
Console.WriteLine(Content2);