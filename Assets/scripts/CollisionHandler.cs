using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay = 1F;
    public GameObject deathEffects;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    #region PRIVATE Methods

    private void OnTriggerEnter(Collider other)
    {
        SendMessage("OnPlayerDeath");
        deathEffects.SetActive(true);
        StartCoroutine(LoadSceneWithDelay(levelLoadDelay, SceneManager.GetActiveScene().buildIndex));
    }

    private IEnumerator LoadSceneWithDelay(float delay, int sceneNumber)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneNumber);
    }
    #endregion
}