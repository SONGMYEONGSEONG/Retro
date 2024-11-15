using UnityEngine;

[CreateAssetMenu(fileName = "ItemCardSO", menuName = "CardSO/Item", order = 3)]
public class ItemCardSO : DefaultCardSO
{
    [Header("Item Data")]
    //public Item item ; //Item 게임오브젝트가 담겨있을 예정 
    public int Test;
}
