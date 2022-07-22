using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyScript : MonoBehaviour
{
    [SerializeField] private Wallet _playerWallet;
    [SerializeField] private GameObject _inStoreObject;
    [SerializeField] private GameObject _objectSpawnPoint;
    [SerializeField] private int _price;
    [SerializeField] private GameObject _sellObject;

    public void Buy()
    {
        if (_playerWallet.GetMoney() >= _price)
        {
            _playerWallet.DecreaseMoney(_price);
            Instantiate(_sellObject, _objectSpawnPoint.transform.position, _objectSpawnPoint.transform.rotation);
            Destroy(_inStoreObject);
        }
    }
}
