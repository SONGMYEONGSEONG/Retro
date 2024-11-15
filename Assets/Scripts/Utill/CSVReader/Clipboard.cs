using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//CSVReader 예제파일
public class Clipboard : MonoBehaviour
{
    private void Start()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");

        for (int i = 0; i < data_Dialog.Count; i++) 
        { 
            print(data_Dialog[i]["Content"].ToString()); 
        }
    }
}
