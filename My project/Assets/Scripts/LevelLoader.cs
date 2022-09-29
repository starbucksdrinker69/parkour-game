using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Level 3")
        {
            SceneManager.LoadScene("Level 1");
        }
        else
        {
            SceneManager.LoadScene(levelIndex);
        }
    }
}
