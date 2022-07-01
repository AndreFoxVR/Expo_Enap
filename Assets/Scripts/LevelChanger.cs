using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public string levelToLoad;
    public string SceneName;


       void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            FadeToLevel(SceneName);
        }
    }

    public void FadeToLevel (string SceneName)
    {
        levelToLoad = SceneName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
