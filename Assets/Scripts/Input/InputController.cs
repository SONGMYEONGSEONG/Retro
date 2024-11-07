using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    //static은 테스트 목적, 나중에 바꿔야함 
    public static event Action OnEventCardClick;
    public LayerMask CardLayerMask;
    private void Start()
    {
        Debug.Log("기모띠");
        CardLayerMask = 1 << 8;
    }

    public void OnSelect(InputValue value)
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());//화면 좌표계에 있기에 월드 좌표로 변환
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, 0f, CardLayerMask);

        if (hit.collider != null)
        {
            Debug.Log(hit.transform.name);

            hit.transform.GetComponent<CardController>().UseCard();

            //OnEventCardClick?.Invoke();
        }
    }
    
    /*Debug*/
    private void Update()
    {
        
    }
    /*Debug*/
}
