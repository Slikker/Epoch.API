using System;
using LinqToDB.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace API.EPOCH.BACKEND
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    // Base class for all classes
    public class BaseClass : IBaseClass
    {
        [Column("rec_id"), PrimaryKey, Identity]
        public int RecId { get; set; }

        [Column("rec_status")]
        public RecStatus RecStatus { get; set; }
    }
}
