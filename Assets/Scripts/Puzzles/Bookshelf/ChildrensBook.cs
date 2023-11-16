using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrensBook : PuzzleInteractable<BookshelfPuzzle>
{
    public int OrderNumber;

    protected override void Interact()
    {
        base.Interact();
        Puzzle.AddBook(OrderNumber);
    }
}
