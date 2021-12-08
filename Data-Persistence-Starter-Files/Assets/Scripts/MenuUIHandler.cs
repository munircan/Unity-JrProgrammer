using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public Text bestScoreText;
    public int bestScore;
    public string bestPlayerName;


    // Start is called before the first frame update
    void Start()
    {
        

        bestPlayerName = MenuManager.Instance.bestPlayerName;
        bestScore = MenuManager.Instance.bestScore;

        if (bestScore != 0)
        {
            bestScoreText.text = "Best Score: " + bestScore;
        }
        MenuManager.Instance.LoadBestPlayed();
    }


    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        MenuManager.Instance.SaveBestPlayed();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}