using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string InteractText;

    private bool _inTrigger;

    private void Update()
    {
        if (_inTrigger && Input.GetKeyDown(KeyCode.E))
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

    }

}
