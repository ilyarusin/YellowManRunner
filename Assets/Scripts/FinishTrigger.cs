using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            FindObjectOfType<GameManager>().ShowFinishWindow();
            

        }
    }
}
