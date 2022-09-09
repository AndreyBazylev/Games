using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;

    private int _currrentWeapon = 0;

    public void AddNewWeapon(Weapon weapon)
    {
        _weapons.Add(weapon);
    }

    public void ChangeNextWeapon()
    {
        if (_currrentWeapon + 1 < _weapons.Count)
        {
            _weapons[_currrentWeapon].gameObject.SetActive(false);
            _currrentWeapon++;
            _weapons[_currrentWeapon].gameObject.SetActive(true);
        }

        else
        {
            _weapons[_currrentWeapon].gameObject.SetActive(false);
            _currrentWeapon = 0;
            _weapons[_currrentWeapon].gameObject.SetActive(true);
        }
    }
    public void ChangePreviousWeapon()
    {
        if (_currrentWeapon - 1 >= 0)
        {
            _weapons[_currrentWeapon].gameObject.SetActive(false);
            _currrentWeapon--;
            _weapons[_currrentWeapon].gameObject.SetActive(true);
        }

        else
        {
            _weapons[_currrentWeapon].gameObject.SetActive(false);
            _currrentWeapon = _weapons.Count - 1;
            _weapons[_currrentWeapon].gameObject.SetActive(true);
        }
    }
}
