using UnityEngine;
using UnityEngine.SceneManagement;

namespace KittyPlatformer.Controllers
{
    public class LoaderScene : MonoBehaviour
    {
        private int _indexCurrentLevel;

        public void SelectLevel(int buildIndex)
        {
            _indexCurrentLevel = buildIndex;
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
}