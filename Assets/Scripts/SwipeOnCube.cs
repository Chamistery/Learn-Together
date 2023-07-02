using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeOnCube : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Physics.gravity = new Vector3(0, 10, 0);


        Swipe.SwipeEvent += OnSwipe;
    }
    private void Update()
    {
        if (Cancel.toDel)
        {
            Swipe.SwipeEvent -= OnSwipe;
        }
    }
    private void OnSwipe(Vector2 direction)
    {
        if (dropDown.clicked) 
        {
            Debug.Log(direction);
            Debug.Log("Method");
            Move(direction); 
        }
    }

    // Update is called once per frame
    private void Move(Vector2 direction)
    {
        if(rb != null)
        rb.AddForce(direction * 200);
    }
}
