using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임에서 사용되는 모든 카드 데이터(스크립타블오브젝트)를 보관하는 클래스입니다.
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
