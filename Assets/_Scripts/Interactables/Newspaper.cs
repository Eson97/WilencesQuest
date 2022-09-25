using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Newspaper : Interactable
{
    [SerializeField] AudioClip InteractSound;
    [SerializeField] Canvas _newspaperCanvas;
    [SerializeField] TextMeshProUGUI _newspaperText;
    private bool isOpen = false;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Instance.LastEventResult == LastEventState.Undef) return;
        base.OnTriggerEnter2D(collision);
    }
    
    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if(GameManager.Instance.LastEventResult == LastEventState.Undef) return;
        base.OnTriggerExit2D (collision);
    }

    protected override void Interact()
    {
        if (GameManager.Instance.LastEventResult == LastEventState.Undef) throw new LastEventResultUndefinedException();

        if (!isOpen)
        {
            AudioSystem.Instance.PlaySound(InteractSound);

            isOpen = true;

            this.Player.GetComponent<PlayerMovement>().enabled = false;

            var Header = GameManager.Instance.LastEventPlayed.EventName;
            var Text = GameManager.Instance.LastEventPlayed.EventDescription;
            var Result = (GameManager.Instance.LastEventResult == LastEventState.Win)
                ? GameManager.Instance.LastEventPlayed.GoodEndingEvent
                : GameManager.Instance.LastEventPlayed.BadEndingEvent;
            //Open Newspaper Canvas

            _newspaperText.text = $"Event: {Header}\n   {Text}. {Result}\n\nPress F to close";
            _newspaperCanvas.gameObject.SetActive(true);

            Debug.Log($"{Header}\n{Text}\n{Result}");

        }
        else
        {
            AudioSystem.Instance.PlaySound(InteractSound);
            
            isOpen = false;

            _newspaperText.text = "";
            _newspaperCanvas.gameObject.SetActive(false);

            this.Player.GetComponent<PlayerMovement>().enabled = true;

            //Close Newspaper canvas
        }

    }
}
