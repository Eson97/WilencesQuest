using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChuckJokes : Interactable
{
    [SerializeField] GameObject JokeDialog;
    [SerializeField] TextMeshProUGUI JokeText;
    private bool isJokeShowing = false;
    private bool hasExit = true;
    private Animator _animator;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (isJokeShowing) this.DialogObject.SetActive(false);
        hasExit = false;
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        hasExit = true;
    }

    private void Awake() => _animator = GetComponent<Animator>();
    protected override void Interact()
    {
        Joke j = APIHelper.GetJoke();

        this.DialogObject.SetActive(false);
        isJokeShowing = true;

        JokeDialog?.SetActive(true);
        JokeText.text = j.value;
        
        StartCoroutine(ResetJokeDialog());
        _animator.SetBool("Interact", true);
    }

    private IEnumerator ResetJokeDialog()
    {
        yield return new WaitForSeconds(3f);
        JokeText.text = "";
        JokeDialog.SetActive(false);
        _animator.SetBool("Interact", false);
        isJokeShowing = false;

        if(!hasExit)this.DialogObject.SetActive(true);
    }
}
