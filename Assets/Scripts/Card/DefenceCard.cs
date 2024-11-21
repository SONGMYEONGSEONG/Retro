
using UnityEngine;

public class DefenceCard : CardController
{
    private DefenceCardSO defenceCardData;

    protected override void Awake()
    {
        base.Awake();
       
    }
    public override void Initialize(DefaultCardSO cardSO)
    {
        defenceCardData = cardSO as DefenceCardSO;
    }
    public override void CardDataPrint()
    {
        //카드 오브젝트에 표기
        Name.text = defenceCardData._Name;
        Desc.text = defenceCardData.Description;

        Value.text = defenceCardData.Defence.ToString();

        //카드 이미지 출력
        if (defenceCardData.CardSprite != null)
        {
            renderer.sprite = CardSO.CardSprite;
        }
    }

    public override void DrawUseCard()
    {

    }

    public override void ClickUseCard()
    {
        Debug.Log($"{defenceCardData._Name} 카드 클릭! ");
    }

}
