using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ApparateController : MonoBehaviour
{
    [SerializeField] private Bomb _TNTPrefab;
    [SerializeField] private Apparate _apparate;
    [SerializeField] private Wallet _playerWallet;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private int _price;

    private void Start()
    {
        _priceText.text = _price.ToString() + "$";
    }

    public void CreateApparate()
    {
        if (_playerWallet.GetMoney() >= _price)
        {
            _playerWallet.DecreaseMoney(_price);
            _apparate.gameObject.SetActive(true);
            _apparate.SetBomb(_TNTPrefab);
        }   
    }
}
