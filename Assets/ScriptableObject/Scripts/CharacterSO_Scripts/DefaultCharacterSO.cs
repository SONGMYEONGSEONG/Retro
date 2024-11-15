using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "DefaultCharacterSO", menuName = "CharacterSO/Default", order = 2)]
public class DefaultCharacterSO : ScriptableObject
{
    [Header("Default Character Data")]
    public int CharacterID; //캐릭터 ID
    public string Name; //캐릭터 이름
    public int Health; //사용시 적용되는 체력수치
    public int Attack; //사용시 적용되는 공격력수치
    public int Defence; //사용시 적용되는 방어력
    public Sprite CharacterSprite; //캐릭터의 이미지 
}
