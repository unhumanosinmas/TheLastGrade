using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{

    private float positionX = (float)-2.218;
    private float positionY = (float)-0.949;
    private bool deadState = false;

    public void setDeadState(bool value) {
        deadState = value;
    }

    public bool getDeadState() { 
        return deadState;
    }

    public void OnCollisionEnter2D(Collision2D collision)
       
    {
        if (collision.transform.CompareTag("Player")) {
            Debug.Log("Player Damaged");
            setDeadState(true);
            collision.gameObject.GetComponent<PlayerDeadCounter>().deadCounter(getDeadState());
            collision.transform.position = (new Vector2(positionX, positionY));
            setDeadState(false);

        }
    }
}
