using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UI_SelectButton : UIBase
{
    public static event Action<int> SelectButtonHandler;

    [SerializeField] int value = 1; //선택지에 대한 가치
    private TextMeshProUGUI SelectString;
    
    public void Initalize(string selectString)
    {
        SelectString.text = selectString;
    }

    public void Select()
    {
        SelectButtonHandler?.Invoke(value);
    }


}
