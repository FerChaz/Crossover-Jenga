using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackState : MonoBehaviour
{
    public bool IsSelected = false;

    public void ActivatePhysicsOnPieces()
    {
        PiecePhysics[] piecesPhysicsArray = GetComponentsInChildren<PiecePhysics>();

        foreach (PiecePhysics piecePhysics in piecesPhysicsArray)
        {
            piecePhysics.Activate();
        }
    }
}
