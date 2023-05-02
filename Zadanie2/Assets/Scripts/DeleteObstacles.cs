using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObstacles : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameObject parentObject = collision.gameObject.transform.parent.gameObject;
            Destroy(parentObject);
        }
    }

}
