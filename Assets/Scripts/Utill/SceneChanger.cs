using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//씬 체인저 역할입니다.
public class SceneChanger : MonoBehaviour
{
    public Camera OriginCam;
    public Camera NewCam;

    private void Start()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
    }

    private void Update()
    {
        Rect camRect = OriginCam.rect;
        camRect.x += 0.01f;
        OriginCam.rect = camRect;

        if(camRect.x >= 1.0f)
        {
            SceneManager.UnloadSceneAsync("DialogScene");
        }
    }
}
