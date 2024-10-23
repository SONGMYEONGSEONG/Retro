using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackCardSO", menuName = "CardSO/Attack", order = 1)]
public class AttackCardSO : DefaultCardSO
{
    [Header("Attack Card Data")]
    public int Attack; //사용시 적용되는 공격력수치


}
