using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
    // public void playGame()
    // {
    //     SceneManager.LoadScene("Test Hakan");
    // }

    public void LoadScene(Object scene) 
    {
        SceneManager.LoadScene(scene.name);
    }
}
