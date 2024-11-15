using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardCreateManager : Singleton<CardCreateManager>
{
    private CardController cardControllerPrefeb;
    protected override void Awake()
    {
        base.Awake();
        cardControllerPrefeb = Resources.Load<CardController>("Prefebs/Card/Card");

        if (cardControllerPrefeb == null)
        {
            Debug.LogError($"{cardControllerPrefeb.name}이 null 입니다. 경로를 확인해주세요");
        }
    }

    public CardController CreateCard(DefaultCardSO cardData)
    {
        CardController card = Instantiate(cardControllerPrefeb, GameManager.Instance.Player.CurrentDeck.transform);
        card.CardSO = cardData;

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
}
