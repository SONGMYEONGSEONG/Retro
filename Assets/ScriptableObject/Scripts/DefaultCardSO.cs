using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultCardSO", menuName = "CardSO/Default", order = 0)]
public class DefaultCardSO : ScriptableObject
{
    [Header("Default Card Data")]
    public string Name; //ī���̸�
    public string Explanation; //ī�弳��
    public int[] BufTurn; //���� ȿ���� ���ӵǴ� ��
    public int[] StatChangeValue; //���� ������� �����Ǵ� ���� ����
}
