using UnityEngine;

[CreateAssetMenu(fileName = "DefenceCardSO", menuName = "CardSO/Defence", order = 1)]
public class DefenceCardSO : DefaultCardSO
{
    [Header("Defence Data")]
    public int Defence; //카드의 방어력
}
