using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] string nextLevelName;

    Goal[] goals;

    // Start is called before the first frame update
    void Start()
    {
        goals = FindObjectsOfType<Goal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalIsReached())
        {
            GoToNextLevel();
        }
    }

    bool GoalIsReached()
    {
        for (int i = 0; i < goals.Length; i++)
        {
            if (goals[i].gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
