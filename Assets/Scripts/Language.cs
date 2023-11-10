using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Language : MonoBehaviour
{
    public static Language Instance;

    [DllImport("__Internal")]
    private static extern string GetLang();

    public string currentLanguage;
    //[SerializeField] TextMeshProUGUI _languageText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            currentLanguage = GetLang();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
