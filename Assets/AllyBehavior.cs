using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBehavior : MonoBehaviour
{    
    private float x = 0;
    private float y = 0;

    private void OnCollisionEnter2D(Collision2D col) 
    {   
        if (col.gameObject.name == "Bullet(Clone)")
        {   
            GameEventsBehavior.Current.GameOver();
        }
    }
}
