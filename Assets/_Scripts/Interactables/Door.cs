using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] AudioClip InteractSound;
    protected override void Interact()
    {
        AudioSystem.Instance.PlaySound(InteractSound);
        if(GameManager.Instance.CurrentLevel<=5)
            GameManager.Instance.ChangeState(GameState.Starting);
        if (GameManager.Instance.CurrentLevel > 5)
            GameManager.Instance.ChangeState(GameState.Ending);
    }
}
