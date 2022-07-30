using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    private float positionX = (float)-2.218;
    private float positionY = (float)-0.949;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            collision.transform.position = (new Vector2(positionX, positionY));
        }
    }
}
 