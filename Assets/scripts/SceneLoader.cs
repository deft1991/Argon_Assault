using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneWithDelay(delay, 1));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator LoadSceneWithDelay(float delay, int sceneNumber)
    {
        yield return new WaitForSeconds(this.delay);
        SceneManager.LoadScene(sceneNumber);
    }
}