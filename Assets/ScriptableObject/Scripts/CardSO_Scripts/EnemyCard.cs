using UnityEngine;

[CreateAssetMenu(fileName = "EnemyCardSO", menuName = "CardSO/Enemy", order = 1)]
public class EnemyCardSO : DefaultCardSO
{
    [Header("Enemy Card Data")]
    public int Health; //Enemy의 체력
    public int Attack; //Enemy의 공격
    public int ActionTurn; //Enemy의 행동을 취할때까지 대기하는 턴

}
