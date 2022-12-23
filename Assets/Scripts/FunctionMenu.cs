using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionMenu : MonoBehaviour
{
    private int _indexCurrentLevel;

    public void SelectLevel(int buildIndex)
    {
        _indexCurrentLevel = buildIndex;
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(_indexCurrentLevel);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}