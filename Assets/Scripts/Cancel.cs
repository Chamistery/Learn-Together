using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancel : MonoBehaviour
{
    public static bool toDel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Word")
        {
         //   Debug.Log(00);
            toDel = true;
        }
    }
}
