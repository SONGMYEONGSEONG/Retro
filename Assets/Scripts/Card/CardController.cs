using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CardController : MonoBehaviour
{
    [SerializeField] protected DefaultCardSO cardSO;

    [SerializeField] private float moveSpeed = 2.0f;
        
    protected virtual void Awake()
    {
        //InputController.OnEventCardClick += UseCard;
    }

    private void OnEnable()
    {
        InputController.OnEventCardClick += UseCard;
    }

    //카드가 클릭 되었을때 효과가 사용되는 메서드입니다.
    public virtual void UseCard()
    {
        Debug.Log($"{cardSO.Name} 카드 클릭! , 추상클래스로 접근됨");


    }

    //카드가 이동할시 동작하는 로직입니다.
    public void MoveCard( Vector2 end)
    {
        StartCoroutine(CardMove(transform.position, end, moveSpeed));
    }

    private void Update()
    {
       
    }
    private void OnDisable()
    {
        InputController.OnEventCardClick -= UseCard;
    }

    IEnumerator CardMove(Vector2 start, Vector2 end, float Speed)
    {
        float elspedTime = 0f;
        while (Vector2.Distance(transform.position, end) > 0.1f)
        {
            elspedTime += Time.deltaTime;
            transform.position = Vector2.Lerp(start, end, Speed * elspedTime);

            yield return null;
        }
        
    }
}
