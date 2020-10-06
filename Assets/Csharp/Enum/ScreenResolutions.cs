using System;
using System.Runtime.Serialization;

namespace Csharp.Enum
{
    [DataContract]
    public enum ScreenResolutions
    {
        [EnumMember]
        HD = 1,
        
        [EnumMember]
        SD = 2
    }
}