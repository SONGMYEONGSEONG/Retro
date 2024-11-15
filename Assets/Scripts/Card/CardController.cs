using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;


public abstract class CardController : MonoBehaviour , ICard
{
    public TextMeshPro Name;
    public TextMeshPro Desc;
    public TextMeshPro Value;

    [SerializeField] private DefaultCardSO cardSO;
    public DefaultCardSO CardSO { get => cardSO; set => cardSO = value; }

    [SerializeField] protected SpriteRenderer renderer;

    protected virtual void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
        

    //카드가 이동할시 동작하는 로직입니다.
    public void MoveCard(Vector2 end)
    {
        transform.DOMove(end,0.2f).SetEase(Ease.OutCubic);
    }

    private void OnEnable()
    {
        InputController.OnEventCardClick += ClickUseCard;
    }
    private void OnDisable()
    {
        InputController.OnEventCardClick -= ClickUseCard;
    }

    public abstract  void DrawUseCard();
    public abstract  void ClickUseCard();
    public abstract void CardDataPrint();
}
