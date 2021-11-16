using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 0.5f;
    [SerializeField] ParticleSystem crashParticles;


    

    
    void OnTriggerEnter(Collider other)
    {
      
      StartCrashSequence();
    }
    void StartCrashSequence()
    {
      crashParticles.Play();
      GetComponent<BoxCollider>().enabled = false;
      GetComponent<PlayerController>().enabled = false;
      GameObject.Find("Body").SetActive(false);
      Invoke("ReloadLevel", levelLoadDelay);
    }


    void ReloadLevel()
    {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        



    }
}
