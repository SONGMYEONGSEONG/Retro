using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour, IAttackToTargetAble, IDamageAble, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private DefaultCharacterSO characterData;
    public DefaultCharacterSO CharacterData { get => characterData; set => characterData = value; }
   
    private SpriteRenderer renderer;
    public UI_StatusPopUpWIndow characterStatusDisPlay;
    private void Awake()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        renderer.sprite = characterData.CharacterSprite;
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        characterStatusDisPlay.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        characterStatusDisPlay.gameObject.SetActive(false);
    } 

    public IDamageAble AttackToTarget()
    {
        //ToDoCode : 공격 대상을 찾는 로직 작성 
        return null ;
    }

    public void TakeDamage()
    {
    }

    public void TakeDebuff()
    {
    }
}
