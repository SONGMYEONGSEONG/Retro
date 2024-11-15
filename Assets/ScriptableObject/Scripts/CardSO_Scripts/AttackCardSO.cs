using UnityEngine;

[CreateAssetMenu(fileName = "AttackCardSO", menuName = "CardSO/Attack", order = 0)]
public class AttackCardSO : DefaultCardSO
{
    [Header("Attack Data")]
    public int Attack; //카드의 공격력
    public int AttackCount; //공격 횟수 

}
