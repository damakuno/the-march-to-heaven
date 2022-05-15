using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField]
    CanvasGroup creditsScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //
        SceneManager.sceneLoaded += GameManager.Instance.StartGame;
        SceneManager.LoadScene("Game");
    }

    public void ShowCredits()
    {
        creditsScreen.alpha = 0.0f;
        creditsScreen.gameObject.SetActive(true);
        creditsScreen.DOFade(1.0f, 1.0f);
    }

    public void CloseCredits()
    {
        creditsScreen.alpha = 1.0f;
        creditsScreen.DOFade(0.0f, 1.0f).OnComplete(() => creditsScreen.gameObject.SetActive(false));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
