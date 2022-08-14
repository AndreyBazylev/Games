using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private TMP_Text _moneyCountText;

    private void Update()
    {
        _moneyCountText.text = _money.ToString() + "$";
    }

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
