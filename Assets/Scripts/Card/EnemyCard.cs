
using TMPro;
using UnityEngine;

public class EnemyCard : CardController
{
    public TextMeshPro EnemyHealth;
    public TextMeshPro EnemyAttack;
    public TextMeshPro EnemyActionTurn;

    private EnemyCardSO enemyCardData;

    protected override void Awake()
    {
        base.Awake();
      
    }
    public override void Initialize(DefaultCardSO cardSO)
    {
        enemyCardData = cardSO as EnemyCardSO;
    }
    public override void DrawUseCard()
    {
        throw new System.NotImplementedException();
    }

    public override void ClickUseCard()
    {
        Debug.Log($"{enemyCardData._Name} 카드 클릭!");
    }

    public override void CardDataPrint()
    {
        EnemyHealth.text = enemyCardData.Health.ToString();
        EnemyAttack.text = enemyCardData.Attack.ToString();
        EnemyActionTurn.text = enemyCardData.ActionTurn.ToString();

        //카드 이미지 출력
        if (enemyCardData.CardSprite != null)
        {
            renderer.sprite = CardSO.CardSprite;
        }
    }
}
