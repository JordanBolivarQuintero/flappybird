using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField] RuntimeAnimatorController[] skinsControllers;
    [SerializeField] Animator animatorComp;

    [SerializeField] SpriteRenderer BackGroundRenderer;
    [SerializeField] FlappyBird.PipeSpawner pipeSpawner;
    [SerializeField] Sprite[] backGroundSprite;
    [SerializeField] GameObject[] pipesPrefab;

    void Start()
    {
        int dayOrNight = Random.Range(0, 2);

        BackGroundRenderer.sprite = backGroundSprite[dayOrNight];

        ObjectPooling.Instance.currentPool = dayOrNight;

        animatorComp.runtimeAnimatorController = skinsControllers[Random.Range(0, skinsControllers.Length)];
    }
}
