﻿

namespace UserService.Domain
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
        public string Nick { get; set; }
        public string Avatar { get; set; }
    }
}
