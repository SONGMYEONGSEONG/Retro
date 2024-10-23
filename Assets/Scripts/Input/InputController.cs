using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    //static은 테스트 목적, 나중에 바꿔야함 
    public static event Action OnEventCardClick;

    private void Start()
    {
        Debug.Log("기모띠");
    }

    public void OnSelect(InputValue value)
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());//화면 좌표계에 있기에 월드 좌표로 변환
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            Debug.Log(hit.transform.name);

            hit.transform.GetComponent<CardController>().UseCard();

            //OnEventCardClick?.Invoke();
        }

        //3D 오브젝트 클릭 코드
        /*
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name);
            OnEventCardClick?.Invoke();
        }
         */
    }
    
    /*Debug*/
    private void Update()
    {
        
    }
    /*Debug*/
}
