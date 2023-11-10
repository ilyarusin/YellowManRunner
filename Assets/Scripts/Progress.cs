using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int Coins;
    public int Width;
    public int Height;
    public int Level;
}
public class Progress : MonoBehaviour
{
    public PlayerInfo PlayerInfo;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    // [SerializeField] TextMeshProUGUI _playerInfoText;

    public static Progress Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadExtern();
    }

    private void Update()
    {
        //  нопка сброса прогресса дл€ тестов

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerInfo = new PlayerInfo();
            Save();
        }

    }
    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        //_playerInfoText.text = PlayerInfo.Coins + "\n" + PlayerInfo.Width + "\n" + PlayerInfo.Height + "\n" + PlayerInfo.Level;
    }
}
