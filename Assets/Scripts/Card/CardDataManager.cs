using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ӿ��� ���Ǵ� ��� ī�� ������(��ũ��Ÿ�������Ʈ)�� �����ϴ� Ŭ�����Դϴ�.
public class CardDataManager : Singleton<CardDataManager>
{
    //public Dictionary<string, DefaultCardSO> CardDatas = new Dictionary<string, DefaultCardSO>();
    //Key : cardID , Value : CardData
    public Dictionary<int, DefaultCardSO> CardDatas = new Dictionary<int, DefaultCardSO>();

    public void Awake()
    {
        DefaultCardSO[] attackCardDatas = Resources.LoadAll<DefaultCardSO>("ScriptableObject/AttacksCardSO");

        for (int i = 0; i < attackCardDatas.Length; i++)
        {
            CardDatas.Add(attackCardDatas[i].CardID, attackCardDatas[i]);
        }

        DefaultCardSO[] defenceCardDatas = Resources.LoadAll<DefaultCardSO>("ScriptableObject/DefencesCardSO");

        for (int i = 0; i < defenceCardDatas.Length; i++)
        {
            CardDatas.Add(defenceCardDatas[i].CardID, defenceCardDatas[i]);
        }
    }
}
