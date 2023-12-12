using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    [SerializeField] GameObject _startMenu;
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] GameObject _finishWindow;
    [SerializeField] CoinManager _coinManager;
    [SerializeField] GameObject _winnerWindow;

    private void Start()
    {
        _levelText.text = "Уровень " + SceneManager.GetActiveScene().buildIndex.ToString();
#if !UNITY_EDITOR && UNITY_WEBGL
        // _levelText.text = SceneManager.GetActiveScene().name;
        ShowAdv();
#endif
    }
    public void Play()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        Progress.Instance.Save();
#endif
        _startMenu.SetActive(false);
        FindObjectOfType<PlayerBehaviour>().Play();

    }

    public void ShowFinishWindow()
    {
        _finishWindow.SetActive(true);
    }

    public void ShowWinnerWindow()
    {
        _winnerWindow.SetActive(true);
    }

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next < SceneManager.sceneCountInBuildSettings)
        {
#if !UNITY_EDITOR && UNITY_WEBGL
            _coinManager.SaveToProgress();
            Progress.Instance.PlayerInfo.Level = SceneManager.GetActiveScene().buildIndex;
            Progress.Instance.Save();
#endif
            SceneManager.LoadScene(next);

        }
    }
}
