﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoStreet : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("UwU");

            if (Input.GetKey(KeyCode.F))
            {
                Application.LoadLevel(0);
            }
        }
    }
}
