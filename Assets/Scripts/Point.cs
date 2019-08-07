using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>())
        {
            PointsController.Instance.AddPoints(1);
            DestroyPoint();
        }
    }

    private void DestroyPoint()
    {
        //add to pool & stuff
        Destroy(gameObject);
    }
}
