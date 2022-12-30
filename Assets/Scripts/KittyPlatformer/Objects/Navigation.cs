using UnityEngine;
using UnityEngine.SceneManagement;

namespace KittyPlatformer.Objects
{
    public class Navigation : MonoBehaviour
    {
        [SerializeField] private Canvas pauseMenu;
        [SerializeField] private Canvas dieMenu;
        [SerializeField] private Canvas finishMenu;
        [SerializeField] private int buildIndexMenu;
        
        public static Navigation Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            if (buildIndexMenu > SceneManager.sceneCount ||
                buildIndexMenu < 0)
                buildIndexMenu = 0;
        }

        public void Finish() => finishMenu.enabled = true;
        
        public void Die() => dieMenu.enabled = true;

        public void Pause()
        {
            dieMenu.enabled = true;
            Time.timeScale = 0f;
        }
        
        public void Continue()
        {
            dieMenu.enabled = false;
            Time.timeScale = 1f;
        }

        public void Restart()
        {
            Continue();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Next()
        {
            Continue();
            if (SceneManager.GetActiveScene().buildIndex + 1 == buildIndexMenu)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            else if (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCount)
                Restart();
            else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        public void LoadMenu()
        {
            Continue();
            SceneManager.LoadScene(buildIndexMenu);
        }

    }
}