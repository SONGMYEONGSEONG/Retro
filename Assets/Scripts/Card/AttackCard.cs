
using UnityEngine;

public class AttackCard : CardController
{
    private AttackCardSO attackCardData;

    protected override void Awake()
    {
        base.Awake();
        attackCardData = CardSO as AttackCardSO;
    }

    public override void CardDataPrint()
    {
        //카드 오브젝트에 표기
        Name.text = attackCardData._Name;
        Desc.text = attackCardData.Description;
        Value.text = attackCardData.Attack.ToString();

        //카드 이미지 출력
        if (CardSO.CardSprite != null)
        {
            renderer.sprite = CardSO.CardSprite;
        }
    }

    public override void DrawUseCard()
    {

    }

    public override void ClickUseCard()
    {
        Debug.Log($"{attackCardData._Name} 카드 클릭! ");
    }

}
