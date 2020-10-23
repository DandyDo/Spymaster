using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string sceneName;

    public void SwitchSceneOnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
