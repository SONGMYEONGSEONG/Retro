using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//ExcelImporter 사용하기
//https://github.com/mikito/unity-excel-importer

//20240913 ExcelImporter 사용안함
//CsvReader로 변경하여 상용할 예정 

public class DialogeSystem : MonoBehaviour
{
    //ExcelImporter 사용
    //[SerializeField] DialogDB dialogDB;

    List<Dictionary<string, object>> data_Dialog;

    [SerializeField] Image leftTalker; 
    [SerializeField] Image rightTalker;
    [SerializeField] Image indicator;
    [SerializeField] Text nameText; //말하는 사람의이름
    [SerializeField] Text talkText; //채팅 박스

    [SerializeField] DialogSelectWindow selectWindow;

    //ExcelImporter 사용
    //private TalkData talkDataBuf;
    //List<DialogDBEntity> curStageDialoge;

    List<TalkData> talkDataBuf = new List<TalkData> ();
    int index = 0;
    bool isPrinting = false;
    bool isLineSkip = false;

    private void Start()
    {
        //ExcelImporter 사용
        //talkDataBuf = new TalkData();

        //ExcelImporter 사용 변수
        //DialogLoad("Stage2");

        data_Dialog = CSVReader.Read("CSVs/DialogDB(Stage1)");

        leftTalker.gameObject.SetActive(false);
        rightTalker.gameObject.SetActive(false);

        SelectButton.SelectButtonHandler += SetTalkDataIndex;

        //for (int i = 0; i < data_Dialog.Count; i++)
        //{
        //    //print(data_Dialog[i]["fileName"].ToString());
        //    //print(data_Dialog[i]["pos"].ToString());
        //    //print(data_Dialog[i]["offPos"].ToString());
        //    //print(data_Dialog[i]["name"].ToString());
        //    //print(data_Dialog[i]["talkData"].ToString());
        //    //print(data_Dialog[i]["talkSpeed"].ToString());
        //    //print(data_Dialog[i]["bgmName"].ToString());
        //    //print(data_Dialog[i]["sfxName"].ToString());
        //}

    }

    public void DialogLoad(string StageName)
    {
        //ExcelImporter 사용 변수
        //object curStage = dialogDB.PrintField(StageName);
        //curStageDialoge = (List<DialogDBEntity>)curStage;
    }

    /*
    private void DialogToTalkData()
    {
        talkDataBuf.fileName = curStageDialoge[index].fileName;
        talkDataBuf.pos = (CharacterPos)curStageDialoge[index].pos;
        talkDataBuf.offPos = (CharacterPos)curStageDialoge[index].offPos;
        talkDataBuf.name = curStageDialoge[index].name;
        talkDataBuf.select = curStageDialoge[index].select;
        talkDataBuf.talkData = curStageDialoge[index].talkData;
        talkDataBuf.talkSpeed = curStageDialoge[index].talkSpeed;
        talkDataBuf.bgmName = curStageDialoge[index].bgmName;
        talkDataBuf.sfxName = curStageDialoge[index].sfxName;
    }
    */

    private void Update()
    {
        //ExcelImporter 사용 변수
        //if (!isPrinting && curStageDialoge.Count > index)
        if (!isPrinting && data_Dialog.Count >index)
        {
            //ExcelImporter 사용 변수
            //DialogToTalkData();

            //ExcelImporter 사용 변수
            //나중에 변경할것 
            //if (talkDataBuf.select == "Y") //선택지
            if(data_Dialog[index]["select"].ToString() == "Y")
            {
                SelectsPrint();
            }
            else //일반 대사
            {
                //ExcelImporter 사용 변수
                //StartCoroutine(TalkPrint(talkDataBuf));
                StartCoroutine(TalkPrint(data_Dialog[index]));
            }
            //ExcelImporter 사용 변수
            //BgmPlay(talkDataBuf.bgmName);
            //SfxPlayOneShot(talkDataBuf.sfxName);

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
        //SelectButton.SelectButtonHandler -= SetTalkDataIndex;

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

        //ExcelImporter 사용 변수
        //selectWindow.PrintSelectData(talkDataBuf);
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
        talkText.text = "";
    }

    //ExcelImporter 사용 변수
    //IEnumerator TalkPrint(TalkData talkData)
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
            talkText.text = buf;

            if (isLineSkip)
            {
                talkText.text = talkData["talkData"].ToString();  // 전체 텍스트를 한 번에 출력
                break;
            }
        }

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        isPrinting = false;
        isLineSkip = false;

        //ExcelImporter 사용 변수
        /*
           isPrinting = true;

        ONCharacterImg(talkData.fileName,talkData.pos);
        OFFCharacterImg(talkData.offPos);

        NameTalkDataClear();

        nameText.text = talkData.name;
        string buf = "";
        foreach (char ch in talkData.talkData)
        {
            buf += ch;
            yield return new WaitForSeconds(talkData.talkSpeed);
            talkText.text = buf;

            if (isLineSkip)
            {
                talkText.text = talkData.talkData;  // 전체 텍스트를 한 번에 출력
                break;
            }
        }

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        isPrinting = false;
        isLineSkip = false;
         */
    }
}
