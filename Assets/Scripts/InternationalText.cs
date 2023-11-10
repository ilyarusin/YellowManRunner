using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InternationalText : MonoBehaviour
{
    [SerializeField] string _en;
    [SerializeField] string _ru;

    private void Start()
    {
        if (Language.Instance.currentLanguage == "en")
        {
            GetComponent<TextMeshProUGUI>().text = _en;
        }
        else if (Language.Instance.currentLanguage == "ru")
        {
            GetComponent<TextMeshProUGUI>().text = _ru;
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = _en;
        }
    }
}
