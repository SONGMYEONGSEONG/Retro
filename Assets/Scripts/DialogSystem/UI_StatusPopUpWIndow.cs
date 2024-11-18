using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatusPopUpWIndow : UIBase
{
    private CharacterController characterController;//해당 캐릭터의 스텟을 읽어오기위해 참조함

    public TextMeshProUGUI AtkText;
    public TextMeshProUGUI DefText;
    public TextMeshProUGUI BufText;

    private void Awake()
    {
        characterController = GetComponentInParent<CharacterController>();

        if (characterController == null)
        {
            Debug.Log($"{characterController.name}이 Null입니다.");
        }
    }

    private void OnEnable()
    {
        AtkText.text = characterController.CharacterData.Attack.ToString();
        DefText.text = characterController.CharacterData.Defence.ToString();
    }
}
