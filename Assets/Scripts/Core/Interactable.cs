using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string InteractText;
    public AudioClip InteractSound;

    private bool _inTrigger;

    public UnityEvent OnInteract;

    private void Update()
    {
        if (_inTrigger && Input.GetKeyDown(KeyCode.E) && GameManager.Instance.CanPlayerMove)
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIController.Instance.ShowHint(InteractText);
            _inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIController.Instance.RemoveHint();
            _inTrigger = false;
        }
    }

    protected virtual void Interact()
    {
        OnInteract.Invoke();

        if (InteractSound != null)
        {
            GetComponent<AudioSource>().PlayOneShot(InteractSound);
        }
    }

}
