using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    [SerializeField] private GameObject _store;

    private bool _storeActive;

    public void SetStoreActive()
    {
        _store.SetActive(!_storeActive);
        _storeActive = !_storeActive;
    }
}
