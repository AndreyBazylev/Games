using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private LevelSelectionController _lsc;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        _lsc.LoadNextLevel();
    }
}
