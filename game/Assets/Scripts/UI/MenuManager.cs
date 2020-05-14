using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject quitPanel;
    [SerializeField] GameObject keyBingingsPanel;
    [SerializeField] GameObject stubbornButton;
    private bool settings = false;
    public bool fullscreen = true;

    Animator animator;

    private void Start()
    {
        animator = stubbornButton.GetComponent<Animator>();
    }
    private void Update()
    {
        CloseByKey();
        CheckFullScreen();
    }

    //open - close panels
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        settings = true;
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        settings = false;
    }
    public void OpenQuit()
    {
        quitPanel.SetActive(true);
    }
    public void CloseQuit()
    {
        animator.SetBool("Normal", true);
        quitPanel.SetActive(false);

    }
    public void OpenKeyBindings()
    {
        keyBingingsPanel.SetActive(true);
    }
    public void CloseKeyBindings()
    {
        keyBingingsPanel.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void CloseByKey()
    {
        if (settings && Input.GetKeyDown(KeyCode.Escape))
        {
            settingsPanel.SetActive(false);
        }
    }

    //resolution & fullscreen
    public void Low()
    {
        if (fullscreen == true)
        {
            Screen.SetResolution(480, 270, true);
        }
        else if (fullscreen == false)
        {
            Screen.SetResolution(480, 270, false);
        }

    }
    public void Medium()
    {
        if (fullscreen == true)
        {
            Screen.SetResolution(960, 540, true);
        }
        else if (fullscreen == false)
        {
            Screen.SetResolution(960, 540, false);
        }

    }
    public void High()
    {
        if (fullscreen == true)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (fullscreen == false)
        {
            Screen.SetResolution(1920, 1080, false);
        }

    }

    public void Fullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log(isFullscreen);
    }

    private void CheckFullScreen()
    {
        if (Screen.fullScreen == true)
        {
            fullscreen = true;

        }

        else if (Screen.fullScreen == false)
        {
            fullscreen = false;
        }

    }
}
