using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private int _sceneIndex = 0;
        public InputField nameInput = null;


        public void SwitchScene()
        {
            PlayerData.playerName = nameInput.text;
            SceneManager.LoadScene(_sceneIndex);
        }

    }
}
