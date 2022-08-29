using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionController : MonoBehaviour
{

    [SerializeField] private int _currentLevel;

    private static int _maxLevels = 4;

    public void LoadNextLevel()
    {
        if (_currentLevel + 1 < _maxLevels)
        {
            _currentLevel++;
            Application.LoadLevel(_currentLevel);
        }
    }

    public void LoadLevelAtIndex(int index)
    {
        if (index < _maxLevels)
        {
            _currentLevel = index;
            Application.LoadLevel(index);
        }
    }
}
