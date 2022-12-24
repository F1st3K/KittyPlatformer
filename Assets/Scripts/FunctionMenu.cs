using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionMenu : MonoBehaviour
{
    private int _indexCurrentLevel;

    public void SelectLevel(int buildName)
    {
        _indexCurrentLevel = buildName;
    }

    public void LoadCurrentLevel()
    {
        if (_indexCurrentLevel <= 0 ||
            _indexCurrentLevel > SceneManager.sceneCount)
            return;
        SceneManager.LoadScene(_indexCurrentLevel);
        
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}