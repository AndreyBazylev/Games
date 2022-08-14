using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparateController : MonoBehaviour
{
    [SerializeField] private Bomb _TNTPrefab;
    [SerializeField] private Apparate _apparate;

    public void CreateApparate()
    {
        _apparate.gameObject.SetActive(true);
        _apparate.SetBomb(_TNTPrefab);
    }
}
