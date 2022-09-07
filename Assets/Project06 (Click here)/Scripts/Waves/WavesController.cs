using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WavesController : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private WaveSpawner _enemySpawner;

    [SerializeField] private GameObject _nextWavePanel;

    [SerializeField] private LevelEndController _lec;
     
    private int _currentWave = 0;
    public void ShowNextWavePanel()
    {
        _nextWavePanel.SetActive(true);
    }

    public void StartNextWave()
    {
        _nextWavePanel.SetActive(false);

        if (_currentWave + 1 <= _waves.Count)
        {
            _enemySpawner.StartWave(_waves[_currentWave]);

            _currentWave++;
        }

        else
        {
            _lec.ShowEndPanel();
        }
    }
}
