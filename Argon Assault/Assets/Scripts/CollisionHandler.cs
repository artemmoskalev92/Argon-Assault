using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] ParticleSystem crashParticles;


    

    
    void OnTriggerEnter(Collider other)
    {
      Debug.Log($"{this.name} ** Triggered by** {other.gameObject.name}");
      StartCrashSequence();
    }
    void StartCrashSequence()
    {
      crashParticles.Play();
      GetComponent<PlayerController>().enabled = false;
      Invoke("ReloadLevel", levelLoadDelay);
    }


    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }
}
