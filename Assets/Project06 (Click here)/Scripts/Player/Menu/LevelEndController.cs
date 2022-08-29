using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndController : MonoBehaviour
{
    [SerializeField] private GameObject _wonPanel;

    [SerializeField] private Health _playerHealth;
    [SerializeField] private BulletDeleter _deleter;

    [SerializeField] private List<GameObject> _stars;

    public void ShowEndPanel()
    {
        _wonPanel.SetActive(true);

        int starIndex = 1;

        _stars[0].SetActive(true);

        if (_deleter.GetBulletPastCount() < 25)
        {
            _stars[starIndex].SetActive(true);
            starIndex++;
        }

        if (_playerHealth.GetTakenDamage() == false)
        {
            _stars[starIndex].SetActive(true);
        }
    }
}
