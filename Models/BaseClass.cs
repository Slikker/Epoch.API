using System;
using LinqToDB.Mapping;

namespace API.EPOCH.BACKEND
{
    // Base class for all classes
    public class BaseClass : IBaseClass
    {
        [Column("rec_id"), PrimaryKey, Identity]
        public int RecId { get; set; }

        [Column("rec_status")]
        public RecStatus RecStatus { get; set; }
    }
}
