using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money;

    public void IcreaseMoney(int count)
    {
        _money += count;
    }

    public void DecreaseMoney(int count)
    {
        _money -= count;
    }

    public int GetMoney()
    {
        return _money;
    }
}
