using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Renderer goldenCrown;

    void Start()
    {
        if (InApp.Instance.HasCrown)
        {
            GetComponent<Renderer>().enabled = true;
        }
    }

}
