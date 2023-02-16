using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerC : MonoBehaviour
{
    public static SceneManagerC Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void LoadScene_(int index)
    {
        SceneManager.LoadScene(index);
    }
}
