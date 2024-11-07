using UnityEngine;

[CreateAssetMenu(fileName = "DefaultCardSO", menuName = "CardSO/Default", order = 0)]
public class DefaultCardSO : ScriptableObject
{
    [Header("Default Card Data")]
    public int CardID; //ī�� ���̵�
    public string _Name; //ī���̸�
    public string Description; //ī�弳��
    public int Value; //ī�� ������(���ݷ�,���� ��ġ ���)
    public Sprite CardSprite; //ī�� �̹��� 


   [Header("Buff Card Turn Data")]
    public bool isBuff; //�ش� ī�忡 ����ȿ���� �ִ��� üũ
    public int[] BufTurn; //���� ȿ���� ���ӵǴ� ��
    public int[] StatChangeValue; //���� ������� �����Ǵ� ���� ����

    [Header("Card Cost Data")]
    public bool isCost; //�ش� ī�忡 �ڽ�Ʈȿ���� �ִ��� üũ
    public CharacterStatus[] StatusType; //���� �ش� Cost�� ����Ǵ� Ÿ��
    public int[] CostStatChangeValue; //���� �ش� ������ Cost�� �����Ǵ� ��ġ

}
