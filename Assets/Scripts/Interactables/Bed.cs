using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactable
{
    protected override void Interact()
    {
        Player.Instance.Hide(true);
    }
}
