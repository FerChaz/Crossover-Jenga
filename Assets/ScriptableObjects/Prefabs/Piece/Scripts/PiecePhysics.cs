using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePhysics : MonoBehaviour
{
    [SerializeField] private PieceData _pieceData;
    
    public void Activate()
    {
        if (_pieceData.JengaPieceData.Mastery == 0)
        {
            Destroy(gameObject);
            return;
        }
        GetComponent<Rigidbody>().useGravity = true;
    }
}
