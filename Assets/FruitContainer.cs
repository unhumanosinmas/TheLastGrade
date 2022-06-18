using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitContainer : MonoBehaviour
{
  public void AllFruitCollected (){
        if (transform.childCount==1) {
            Debug.Log("Las has recolectado todas, ¡Ganaste!");
        }
    }

}
