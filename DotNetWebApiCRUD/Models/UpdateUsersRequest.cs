﻿namespace DotNetWebApiCRUD.Models
{
    public class UpdateUsersRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long PhoneNumber { get; set; }

    }
}
