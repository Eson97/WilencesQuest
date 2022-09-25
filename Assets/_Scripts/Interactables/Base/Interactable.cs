using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected GameObject DialogObject;
    protected GameObject Player;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerActions>(out var component))
        {
            Player = collision.gameObject;
            component.InteractDelegate += Interact;
            DialogObject?.SetActive(true);
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerActions>(out var component))
        {
            Player = null;
            component.InteractDelegate -= Interact;
            DialogObject?.SetActive(false);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.TryGetComponent<PlayerActions>(out var component))
    //    {
    //        component.InteractDelegate += Interact;
    //        DialogObject?.SetActive(true);
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.TryGetComponent<PlayerActions>(out var component))
    //    {
    //        component.InteractDelegate -= Interact;
    //        DialogObject?.SetActive(false);
    //    }
    //}

    protected virtual void Interact()
    {
        throw new System.NotImplementedException($"Function {System.Reflection.MethodBase.GetCurrentMethod().Name} not implemented on {this.GetType().Name}");
    }
}
