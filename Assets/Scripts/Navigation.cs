using UnityEngine;
using UnityEngine.SceneManagement;

class Navigation : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    
    public void Continue()
    {
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        Continue();
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Continue();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCount)
        {
            Continue();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}