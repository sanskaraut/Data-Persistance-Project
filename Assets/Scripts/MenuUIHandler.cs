using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestPlayerInfoText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadBestPlayerData1();
        Debug.Log(GameManager.Instance.bestPlayerName);
        if (GameManager.Instance.bestPlayerName != null)
        {
            bestPlayerInfoText.SetText(GameManager.Instance.bestPlayerName + " : " + GameManager.Instance.bestPlayerScore);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
