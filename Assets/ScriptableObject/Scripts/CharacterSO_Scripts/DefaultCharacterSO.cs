using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterStatus
{
    Health = 0,
    Attack = 1,
    Defence = 2,
}

[CreateAssetMenu(fileName = "DefaultCharacterSO", menuName = "CharacterSO/Default", order = 2)]
public class DefaultCharacterSO : ScriptableObject
{
    [Header("Default Character Data")]
    public int CharacterID; //ĳ���� ID
    public string Name; //ĳ���� �̸�
    public int Health; //���� ����Ǵ� ü�¼�ġ
    public int Attack; //���� ����Ǵ� ���ݷ¼�ġ
    public int Defence; //���� ����Ǵ� ����
    public Sprite CharacterSprite; //ĳ������ �̹��� 
}
