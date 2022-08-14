using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeleter : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            Debug.Log("Жора");
            Destroy(collision.gameObject);
        }
    }
}
