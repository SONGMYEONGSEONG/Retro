using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefenceCardSO", menuName = "CardSO/Defence", order = 2)]
public class DefenceCardSO : DefaultCardSO
{
    [Header("Defence Card Data")]
    public int Defence; //사용시 적용되는 방어력

}
