using System.Runtime.Serialization;

namespace GoodGames.Data.Model
{
    public enum GameStatus
    {
        [EnumMember]
        WANT_PLAY,
        [EnumMember]
        PLAYING,
        [EnumMember]
        FINISHED,

    }
}
