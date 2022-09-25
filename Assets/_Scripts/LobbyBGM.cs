using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBGM : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    private void Start()
    {
        StartCoroutine(StartSound());
    }

    IEnumerator StartSound()
    {
        yield return new WaitForSeconds(.5f);

        var sanity = GameManager.Instance.CurrentSanityLevel;

        switch (sanity)
        {
            case -1:
                source.pitch = 0.25f;
                source.volume = 0.32f;
                break;
            case -2:
                source.pitch = 0.05f;
                source.volume = 1f;
                break;
            default:
                source.pitch = 1f;
                source.volume = 0.08f;
                break;
        }
        

        source.Play();
    }
}
