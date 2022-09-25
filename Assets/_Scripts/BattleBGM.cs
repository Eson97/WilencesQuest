using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBGM : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    private void Start()
    {
        StartCoroutine(StartSound());
    }

    IEnumerator StartSound()
    {
        yield return new WaitForSeconds(.5f);
        source.loop = true;
        source.Play();
    }
}
