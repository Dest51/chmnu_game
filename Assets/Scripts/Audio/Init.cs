using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    private void Awake()
    {
        AudioController.Init();
        SceneManager.LoadScene(1);
    }

}
