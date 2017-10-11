using System;

namespace API.EPOCH.BACKEND
{
    public enum RecStatus
    {
        Deleted = -1,
        Active = 0
    }
    
    public interface IBaseClass
    {
        int RecId { get; set; }
        RecStatus RecStatus { get; set; }
    }
}
