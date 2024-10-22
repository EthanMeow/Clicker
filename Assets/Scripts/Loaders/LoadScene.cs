using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene2 : MonoBehaviour
{

    public string SceneName2;
    public void LoadScenes()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene(SceneName2);
    }
}