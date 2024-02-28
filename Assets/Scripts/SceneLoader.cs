using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private int _sceneIndex = 0;

        public void SwitchScene()
        {
            SceneManager.LoadScene(_sceneIndex);
        }

    }
}
