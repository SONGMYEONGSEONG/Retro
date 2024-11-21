using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardCreateManager : Singleton<CardCreateManager>
{
    private CardController[] cardControllerPrefeb;
    protected override void Awake()
    {
        base.Awake();
        cardControllerPrefeb = Resources.LoadAll<CardController>("Prefebs/Card");
    }

    public CardController CreateCard(int cardID)
    {
        if (CardDataManager.Instance.CardDatas.ContainsKey(cardID))
        {

            DefaultCardSO cardData = CardDataManager.Instance.CardDatas[cardID];

            int cardType = (cardID / 1000) - 1; //매직넘버 + 데이터 처리방식 잇앗함 

            CardController card = Instantiate(cardControllerPrefeb[cardType], GameManager.Instance.Player.CurrentDeck.transform);
            card.Initialize(cardData);

            ////들어온 카드SO에따라 데이터 표기 및 적용을 다르게 진행 
            //if (card.CardSO is EnemyCardSO enemyCard)
            //{
            //    card.OnEnanleEnemyCard();

            //}
            //else
            //{
            //    card.OnEnableDefaultCard();
            //}

            card.CardDataPrint();
            card.gameObject.SetActive(false);

            return card;
        }

        return null;
    }
}
