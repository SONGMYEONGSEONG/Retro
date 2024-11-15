using UnityEngine;
using Enums;

namespace Structs
{
    [System.Serializable]
    public struct TalkData
    {
        public string fileName;
        public CharacterPos pos;
        public CharacterPos offPos;
        public string name;
        public string select;
        public string talkData;
        public float talkSpeed;
        public string bgmName;
        public string sfxName;
      
    }

    [System.Serializable]
    public struct CardPos
    {
        public bool IsCard;
        public Vector2 Position;
    }


}
