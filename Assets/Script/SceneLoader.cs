using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName = "Guide";
    public void loadScene()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    public void loadScenereset()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Gameplay")
        {
            PlayerPrefs.SetFloat("Gameplay1", 0f);
            SceneManager.LoadSceneAsync(sceneName);
        }
        if (scene.name == "Gameplay2")
        {
            PlayerPrefs.SetFloat("Gameplay2", 0f);
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
    public void setloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetString("Loadscene", scene.name);
        SceneManager.LoadSceneAsync(sceneName);
    }
    public void getloadScene()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("Loadscene"));
    }
}
