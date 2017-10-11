using System;
using System.Collections.Generic;
using System.Text;

namespace API.EPOCH.BACKEND
{
    public interface IAccount : IBaseClass
    {
        string AccountName { get; set; }
        string Password { get; set; }
        string Email { get; set; }
    }
}
