using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class InApp : MonoBehaviour
{
    public bool HasCrown;
    public static InApp Instance;

    [DllImport("__Internal")]
    private static extern void BuyCrown();

    [DllImport("__Internal")]
    private static extern void CheckCrown();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BuyCrownWithButton()
    {
        BuyCrown();
    }

    public void SetCrownToTrue()
    {
        HasCrown = true;
    }
}
