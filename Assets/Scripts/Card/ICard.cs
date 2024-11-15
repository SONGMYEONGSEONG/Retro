using System;
using UnityEngine;

public interface ICard
{
    //카드를 뽑았을때 동작하는 로직들을 담당하는 메서드입니다.
    public void DrawUseCard();
    //카드를 클릭했을때 동작하는 로직들을 담당하는 메서드입니다. 
    public void ClickUseCard();

    public void CardDataPrint();

}
