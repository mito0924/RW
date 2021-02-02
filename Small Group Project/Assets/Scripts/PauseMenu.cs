using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;
    int flag = 0;
    private bool paused = false;

    //캔버스 가리기
    void Start()
    {
        PauseUI.SetActive(false);
    }
    //게임 정지
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && flag==0)
        {
            paused = !paused;
        }
        if (paused && flag==0)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused &&flag==0)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    //재생 메뉴
    public void Resume()
    {
        paused = false;
    }
    //재시작 메뉴
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    //메인메뉴 (메인메뉴는 level 0)
    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
    //나가기
    public void Quit()
    {
        Application.Quit();
    }
    //게임오버 메뉴 
    public void GameOver()
    {
        paused = true;
        flag = 1;
    }
}

