using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] int _money;

    public void IcreaseMoney()
    {
        _money++;
    }
}
