using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Enums;

//20240913 : ExcelImporter  -> CsvReader로 변경하여 상용할 예정 


public class DialogeManager : Singleton<DialogeManager>
{
    private readonly string FileName = "FileName";
    private readonly string Pos = "Pos";
    private readonly string OffPos = "OffPos";
    private readonly string Name = "Name";
    private readonly string Select = "Select";
    private readonly string TalkData = "TalkData";
    private readonly string TalkSpeed = "TalkSpeed";
    private readonly string BgmName = "BgmName";
    private readonly string SfxName = "SfxName";

    List<Dictionary<string, object>> data_Dialog;

    [SerializeField] private Image leftTalker; //왼쪽 캐릭터 일러스트
    [SerializeField] private Image rightTalker; //오른쪽 캐릭터 일러스트
    [SerializeField] private Image indicator; //대화시 나타나는 방향표지 UI
    [SerializeField] private TextMeshProUGUI nameText; //말하는 사람의이름
    [SerializeField] TextMeshProUGUI talkTextBox; //채팅 박스

    [SerializeField] DialogSelectWindow selectWindow; //대화시 선택지관련 컴포넌트

    int index = 0; //현재 CSV의 저장된 문자열 순서(인덱스)
    bool isPrinting = false; //현재 문장이 출력중인지 체크하는 변수
    bool isLineSkip = false; //입력값이 있으면 해당 문장을 다 출력해주는 기능

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        data_Dialog = CSVReader.Read("CSVs/Stage2"); //CSVReader의 Read 메서드로 해당 엑셀csv 데이터를 읽어온다.

        //캐릭터 왼쪽,오른쪽 이미지 출력 X
        leftTalker.gameObject.SetActive(false);
        rightTalker.gameObject.SetActive(false);

        //선택지가 주어질때 동작하는 이벤트 함수 설정
        SelectButton.SelectButtonHandler += SetTalkDataIndex;
    }

    private void Update()
    {
        //출력중이 아니고 대화창 출력문장이 더 남아있을때
        if (!isPrinting && index < data_Dialog.Count)
        {

            if ((bool)data_Dialog[index][Select])
            {
                SelectsPrint();
            }
            else //일반 대사
            {
                StartCoroutine(TalkPrint(data_Dialog[index]));
            }

            BgmPlay((string)data_Dialog[index][BgmName]);
            SfxPlayOneShot((string)data_Dialog[index][SfxName]);

            index++;
        }

        if (!isLineSkip && Input.GetMouseButtonDown(0))
        {
            isLineSkip = true;
        }
    }

    public void SetTalkDataIndex(int value)
    {
        index += value;
        Debug.Log(index + " " + value + " " + index + value);

        if (selectWindow.gameObject.activeSelf)
        {
            selectWindow.gameObject.SetActive(false);
        }
    }

    private void SelectsPrint()
    {
        if (!selectWindow.gameObject.activeSelf)
        {
            selectWindow.gameObject.SetActive(true);
        }

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
                    leftTalker.sprite = Resources.Load<Sprite>("Sprite/" + fileName);
                    break;

                case CharacterPos.RIGHT:
                    rightTalker.gameObject.SetActive(true);
                    rightTalker.sprite = Resources.Load<Sprite>("Sprite/" + fileName);
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

        ONCharacterImg(talkData[FileName].ToString(), (CharacterPos)talkData[Pos]);
        OFFCharacterImg((CharacterPos)talkData[OffPos]);

        NameTalkDataClear();

        nameText.text = talkData[Name].ToString();
        string buf = "";
        foreach (char ch in talkData[TalkData].ToString())
        {
            buf += ch;
            yield return new WaitForSeconds((float)talkData[TalkSpeed]);
            talkTextBox.text = buf;

            if (isLineSkip)
            {
                talkTextBox.text = talkData[TalkData].ToString();  // 전체 텍스트를 한 번에 출력
                break;
            }
        }

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        isPrinting = false;
        isLineSkip = false;

    }
}
