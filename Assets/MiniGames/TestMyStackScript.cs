using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestMyStackScript : MonoBehaviour
{
    public void TestMyStack()
    {
        StackState selectedObject = FindObjectsOfType<StackState>()
            .FirstOrDefault(obj => obj.IsSelected);
        
        selectedObject.ActivatePhysicsOnPieces();
    }
}
