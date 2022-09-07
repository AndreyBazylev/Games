using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeleter : MonoBehaviour
{
    private int _bulletPast;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            _bulletPast++;
            Destroy(collision.gameObject);
        }
    }

    public int GetBulletPastCount()
    {
        return _bulletPast;
    }
}
