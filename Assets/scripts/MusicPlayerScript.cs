using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayerScript : MonoBehaviour
{
    public float delay;

    private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();
        // _audioSource.loop = true;
        PlayMusic();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneWithDelay(delay, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadSceneWithDelay(float delay, int sceneNumber)
    {
        yield return new WaitForSeconds(this.delay);
        SceneManager.LoadScene(sceneNumber);
    }
    
    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }
 
    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
