using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Approve : MonoBehaviour
{
    public static bool toUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Word")
        {
            //   Debug.Log(00);
            toUp = true;
        }
    }
}
