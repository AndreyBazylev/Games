using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Image _itemImage;
    [SerializeField] private Sprite _itemImageSprite;

    [SerializeField] private Player _player;
    [SerializeField] private Wallet _playerWallet;
    [SerializeField] private GameObject _inStoreObject;
    [SerializeField] private GameObject _objectSpawnPoint;
    [SerializeField] private int _price;
    [SerializeField] private Weapon _sellObject;

    private void Start()
    {
        _priceText.text = _price.ToString() + "$";
        _itemImage.sprite = _itemImageSprite;
    }

    public void Buy()
    {
        if (_playerWallet.GetMoney() >= _price)
        {
            _playerWallet.DecreaseMoney(_price);
            Weapon newWeapon = Instantiate(_sellObject, _objectSpawnPoint.transform.position, _objectSpawnPoint.transform.rotation);
            newWeapon.SetWallet(_playerWallet);
            newWeapon.gameObject.SetActive(false);
            _player.AddNewWeapon(newWeapon);
            Destroy(_inStoreObject);
        }
    }
}
