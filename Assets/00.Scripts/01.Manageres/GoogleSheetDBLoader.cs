using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

//복사해온 URL : https://docs.google.com/spreadsheets/d/1YE5sOykUMfuXP3jJ7jecMvzIeN58NSqLIX-BoCzYxs0/edit?usp=sharing

//1.복사해 온 주소에서 끝에 있는 "edit?usp=sharing" 삭제한다.
//2.삭제 한 주소에 당므을 추가한다 "export?format=tsv&range=A2:E";
//2-1. 설명 : 모드와 포맷 그리고 시트의 범위를 뜻함, =A2:E 를 엑셀 연산식에 적용시 범위를 알수 있음 

//사용할 URL : https://docs.google.com/spreadsheets/d/1YE5sOykUMfuXP3jJ7jecMvzIeN58NSqLIX-BoCzYxs0/export?format=tsv&range=A2:E


public class GoogleSheetDBLoader : MonoBehaviour 
{
    private string sheetData; // URL에서 불러온 데이터를 저장하는 변수
    private readonly string googleSheetURL = "https://docs.google.com/spreadsheets/d/1YE5sOykUMfuXP3jJ7jecMvzIeN58NSqLIX-BoCzYxs0/export?format=tsv&range=A2:E";

    public string SheetData { get => sheetData; set => sheetData = value; }

    IEnumerator Start()
    {
        //UnityWebRequest 인스턴스 리소스 해제를 위한 using
        using(UnityWebRequest www = UnityWebRequest.Get(googleSheetURL))
        {
            yield return www.SendWebRequest();

            if(www.isDone)
            {
                sheetData = www.downloadHandler.text;
            }
        }

        DisplayText();
    }

    public void DisplayText()
    {
        //Split 함수로 데이터 처리하기
        string[] rows = sheetData.Split('\n'); //행 데이터 (카드의 데이터 모음)

        string str = "";
        for (int j = 0; j < rows.Length; j++)
        {
            string[] columns = rows[j].Split('\t'); // 열 데이터 (카드의 데이터 중 하나)

            //첫번째 행의 카드 데이터를 출력한다.
            for (int i = 0; i < columns.Length; i++)
            {
                str += columns[i] + " ";
            }

            str += "\n";
        }

        Debug.Log(str);
    }
}
