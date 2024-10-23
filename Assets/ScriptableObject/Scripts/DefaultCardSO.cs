using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultCardSO", menuName = "CardSO/Default", order = 0)]
public class DefaultCardSO : ScriptableObject
{
    [Header("Default Card Data")]
    public string Name; //카드이름
    public string Explanation; //카드설명
    public int[] BufTurn; //사용시 효과기 지속되는 턴
    public int[] StatChangeValue; //턴이 지난경우 변동되는 값의 단위
}
