using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public string inputName;
    public GameObject inputField;
    public Text bestScoreText;

    private void Start()
    {
        NameManager.Instance.LoadName();
        bestScoreText.text = $"Best Score: {NameManager.Instance.BestName}: {NameManager.Instance.BestScore}";
    }

    public void StoreName()
    {
        inputName = inputField.GetComponent<Text>().text;
        NameManager.Instance.PlayerName = inputName;
        NameManager.Instance.SaveName();
        Debug.Log("Entered name = " + inputName);
        Debug.Log("Stored name = " + NameManager.Instance.PlayerName);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        NameManager.Instance.SaveName();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
