using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour {

    // Declaring our variables
    public abstract void Move(float direction);
    public abstract void Jump();

}
