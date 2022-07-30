using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadCounter : MonoBehaviour
{
    public int  dead = 0;
    public void deadCounter(bool deadState) {
        if (deadState == true)
        {
            dead++;
            Debug.Log("you have died " + dead + " times");
        }
    }
}
