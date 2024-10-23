
using UnityEngine;

public class DefenceCardController : CardController
{

    private DefenceCardSO defenceCardSO;

    protected override void Awake()
    {
        base.Awake();
        defenceCardSO = cardSO as DefenceCardSO;
    }



    public override void UseCard()
    {
        Debug.Log($"{defenceCardSO.Name} 카드 클릭!");
    }
}
