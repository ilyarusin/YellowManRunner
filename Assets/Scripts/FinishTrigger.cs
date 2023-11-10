using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] AudioSource _danceMusic;

    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour playerBehaviour = other.attachedRigidbody.GetComponent<PlayerBehaviour>();

        if (playerBehaviour)
        {
            _danceMusic.Play();
            playerBehaviour.StartFinishBehaviour();
            

            if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                FindObjectOfType<GameManager>().ShowWinnerWindow();
            }
            else
            {
                FindObjectOfType<GameManager>().ShowFinishWindow();
            }
        }
    }
}
