using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Enums;
using Constains;
using System.Text;
//20240913 : ExcelImporter  -> CsvReader로 변경하여 상용할 예정 


public class DialogeManager : Singleton<DialogeManager>
{
   
    List<Dictionary<string, object>> data_Dialog;

    [SerializeField] private Image leftTalker; //왼쪽 캐릭터 일러스트
    [SerializeField] private Image rightTalker; //오른쪽 캐릭터 일러스트
    [SerializeField] private Image indicator; //대화시 나타나는 방향표지 UI
    [SerializeField] private TextMeshProUGUI nameText; //말하는 사람의이름
    [SerializeField] TextMeshProUGUI talkTextBox; //채팅 박스

    [SerializeField] UI_DialogSelectWindow selectWindow; //대화시 선택지관련 컴포넌트

    int index = 0; //현재 CSV의 저장된 문자열 순서(인덱스)
    bool isPrinting = false; //현재 문장이 출력중인지 체크하는 변수
    bool isLineSkip = false; //입력값이 있으면 해당 문장을 다 출력해주는 기능

    public int CallStageDialogNum = 0;

    private StringBuilder strBuilder = new StringBuilder();

    private WaitUntil dialogPrintSkip = new WaitUntil(() => Input.GetMouseButtonDown(0));


    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        strBuilder.Clear();
        strBuilder.Append(DialogeSystemType.DialogeFilePath);
        strBuilder.Append(CallStageDialogNum.ToString());

        //CSVReader의 Read 메서드로 해당 엑셀csv 데이터를 읽어온다.
        data_Dialog = CSVReader.Read(strBuilder.ToString());

        //캐릭터 왼쪽,오른쪽 이미지 출력 X
        leftTalker.gameObject.SetActive(false);
        rightTalker.gameObject.SetActive(false);

        //선택지가 주어질때 동작하는 이벤트 함수 설정
        UI_SelectButton.SelectButtonHandler += SetTalkDataIndex;
    }

    private void Update()
    {
        //출력중이 아니고 대화창 출력문장이 더 남아있을때
        if (!isPrinting && index < data_Dialog.Count)
        {
            //선택지 인경우 선택지 문장을 출력 
            if ((bool)data_Dialog[index][DialogeSystemType.Select])
            {
                SelectsPrint();
            }
            else //일반 대사
            {
                StartCoroutine(TalkPrint(data_Dialog[index]));
            }

            BgmPlay((string)data_Dialog[index][DialogeSystemType.BgmName]);
            SfxPlayOneShot((string)data_Dialog[index][DialogeSystemType.SfxName]);

            index++;
        }

        //문장스킵 상태가 아니고 마우스 입력이 들어왔을때 해당 문장을 스킵하는 기능(빨리 읽기)
        if (!isLineSkip && Input.GetMouseButtonDown(0))
        {
            isLineSkip = true;
        }
    }

    public void SetTalkDataIndex(int value)
    {
        //현재 인덱스를 인자값 위치로 이동 
        index += value;

        //선택지에따라 해당 대화 브런치(가지)로 이동하는 것을 로그로 확인하기 위한 코드 
        Debug.Log(index + " " + value + " " + index + value);

        //선택지 오브젝트가 켜져있으면 비활성화
        if (selectWindow.gameObject.activeSelf)
        {
            selectWindow.gameObject.SetActive(false);
        }
    }

    private void SelectsPrint()
    {
        //선택지 활성화
        if (!selectWindow.gameObject.activeSelf)
        {
            selectWindow.gameObject.SetActive(true);
        }

        //선택지의 문장 출력 
        selectWindow.PrintSelectData(data_Dialog[index]);
    }


    private void BgmPlay(string bgmName = "")
    {
        if (bgmName != "")
        {
            AudioManager.Instance.StopBgm();
            AudioManager.Instance.PlayBgm(bgmName);
        }
    }

    private void SfxPlayOneShot(string sfxName = "")
    {
        if (sfxName != "")
        {
            AudioManager.Instance.PlaySfx(sfxName);
        }
    }

    private void ONCharacterImg(string fileName, CharacterPos pos)
    {
        if (fileName != "0")
        {
            switch (pos)
            {
                case CharacterPos.LEFT:
                    leftTalker.gameObject.SetActive(true);
                    leftTalker.sprite = Resources.Load<Sprite>(DialogeSystemType.CharacterSpritePath + fileName);
                    break;

                case CharacterPos.RIGHT:
                    rightTalker.gameObject.SetActive(true);
                    rightTalker.sprite = Resources.Load<Sprite>(DialogeSystemType.CharacterSpritePath + fileName);
                    break;
            }
        }
    }

    private void OFFCharacterImg(CharacterPos offPos)
    {
        switch (offPos)
        {
            case CharacterPos.LEFT:
                leftTalker.gameObject.SetActive(false);
                break;

            case CharacterPos.RIGHT:
                rightTalker.gameObject.SetActive(false);
                break;
            case CharacterPos.All:
                leftTalker.gameObject.SetActive(false);
                rightTalker.gameObject.SetActive(false);
                break;
        }
    }

    private void NameTalkDataClear()
    {
        nameText.text = "";
        talkTextBox.text = "";
    }

    IEnumerator TalkPrint(Dictionary<string, object> talkData)
    {
        isPrinting = true;

        ONCharacterImg(talkData[DialogeSystemType.FileName].ToString(), (CharacterPos)talkData[DialogeSystemType.Pos]);
        OFFCharacterImg((CharacterPos)talkData[DialogeSystemType.OffPos]);

        NameTalkDataClear();

        nameText.text = talkData[DialogeSystemType.Name].ToString();

        string buf = "";
        foreach (char ch in talkData[DialogeSystemType.TalkData].ToString())
        {
            buf += ch;
            yield return new WaitForSeconds((float)talkData[DialogeSystemType.TalkSpeed]);
            talkTextBox.text = buf;

            if (isLineSkip)
            {
                talkTextBox.text = talkData[DialogeSystemType.TalkData].ToString(); // 전체 텍스트를 한 번에 출력
                break;
            }
        }

        yield return dialogPrintSkip;

        isPrinting = false;
        isLineSkip = false;

    }
}
