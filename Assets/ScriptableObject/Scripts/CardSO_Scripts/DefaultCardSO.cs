using UnityEngine;

[CreateAssetMenu(fileName = "DefaultCardSO", menuName = "CardSO/Default", order = 0)]
public class DefaultCardSO : ScriptableObject
{
    [Header("Default Card Data")]
    public int CardID; //카드 아이디
    public string _Name; //카드이름
    public string Description; //카드설명
    public int Value; //카드 데이터(공격력,방어력 수치 등등)
    public Sprite CardSprite; //카드 이미지 


   [Header("Buff Card Turn Data")]
    public bool isBuff; //해당 카드에 버프효과가 있는지 체크
    public int[] BufTurn; //사용시 효과기 지속되는 턴
    public int[] StatChangeValue; //턴이 지난경우 변동되는 값의 단위

    [Header("Card Cost Data")]
    public bool isCost; //해당 카드에 코스트효과가 있는지 체크
    public CharacterStatus[] StatusType; //사용시 해당 Cost가 적용되는 타입
    public int[] CostStatChangeValue; //사용시 해당 스텟의 Cost로 증감되는 수치

}
