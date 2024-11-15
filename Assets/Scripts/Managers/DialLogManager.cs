using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Enums;

//20240913 : ExcelImporter  -> CsvReader로 변경하여 상용할 예정 

public class DialogeManager : Singleton<DialogeManager>
{
    List<Dictionary<string, object>> data_Dialog;

    [SerializeField] private Image leftTalker; //왼쪽 캐릭터 일러스트
    [SerializeField] private Image rightTalker; //오른쪽 캐릭터 일러스트
    [SerializeField] private Image indicator; //대화시 나타나는 방향표지 UI
    [SerializeField] private TextMeshProUGUI nameText; //말하는 사람의이름
    [SerializeField] TextMeshProUGUI talkTextBox; //채팅 박스

    [SerializeField] DialogSelectWindow selectWindow; //대화시 선택지관련 컴포넌트

    int index = 0;
    bool isPrinting = false;
    bool isLineSkip = false;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        data_Dialog = CSVReader.Read("CSVs/DialogDB(Stage1)");

        leftTalker.gameObject.SetActive(false);
        rightTalker.gameObject.SetActive(false);

        SelectButton.SelectButtonHandler += SetTalkDataIndex;
    }

    private void Update()
    {
        if (!isPrinting && data_Dialog.Count >index)
        {
            if(data_Dialog[index]["select"].ToString() == "Y")
            {
                SelectsPrint();
            }
            else //일반 대사
            {
                StartCoroutine(TalkPrint(data_Dialog[index]));
            }

            BgmPlay(data_Dialog[index]["bgmName"].ToString());
            SfxPlayOneShot(data_Dialog[index]["sfxName"].ToString());

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
        Debug.Log(index + " " + value + " " + index+value);

        if (selectWindow.gameObject.activeSelf)
        {
            selectWindow.gameObject.SetActive(false);
        }
    }

    private void SelectsPrint()
    {
        if(!selectWindow.gameObject.activeSelf)
        {
            selectWindow.gameObject.SetActive(true);
        }

        selectWindow.PrintSelectData(data_Dialog[index]);
    }


    private void BgmPlay(string bgmName = "")
    {
        if(bgmName != "")
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

    private void ONCharacterImg(string fileName , CharacterPos pos)
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

        ONCharacterImg(talkData["fileName"].ToString(), (CharacterPos)talkData["pos"]);
        OFFCharacterImg((CharacterPos)talkData["offPos"]);

        NameTalkDataClear();

        nameText.text = talkData["name"].ToString();
        string buf = "";
        foreach (char ch in talkData["talkData"].ToString())
        {
            buf += ch;
            yield return new WaitForSeconds((float)talkData["talkSpeed"]);
            talkTextBox.text = buf;

            if (isLineSkip)
            {
                talkTextBox.text = talkData["talkData"].ToString();  // 전체 텍스트를 한 번에 출력
                break;
            }
        }

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        isPrinting = false;
        isLineSkip = false;

    }
}
