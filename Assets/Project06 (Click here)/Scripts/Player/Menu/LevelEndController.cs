using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndController : MonoBehaviour
{
    [SerializeField] private GameObject _wonPanel;

    [SerializeField] private Health _playerHealth;
    [SerializeField] private BulletDeleter _deleter;

    [SerializeField] private List<GameObject> _stars;

    [SerializeField] private int _maxPastBullets = 25;

    private const int _firstElement = 0;
    private const int _defultStarsCount = 1;

    public void ShowEndPanel()
    {
        _wonPanel.SetActive(true);

        int starIndex = _defultStarsCount;

        _stars[_firstElement].SetActive(true);

        if (_deleter.GetBulletPastCount() < _maxPastBullets)
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
