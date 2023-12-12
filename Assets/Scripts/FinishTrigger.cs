using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] public AudioSource _danceMusic;
    public static FinishTrigger Instance;
    private bool isMusicOn;
    [SerializeField] PlayerMove _playerMove;

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
        transform.parent = null;
    }

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

    public void TurnOffMusic()
    {
        _danceMusic.Stop();
    }

}
