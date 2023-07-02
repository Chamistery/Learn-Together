using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMoving : MonoBehaviour
{
    public GameObject follow;
    public void Delete()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(follow.transform.position);
    }
}
