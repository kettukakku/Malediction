using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;
     
    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
            LoadNextLevel();
    }

   public void NewStart()
   {
      StartCoroutine(LoadLevel(1)); 
   }
   
   public void LoadNextLevel()
   {
       if (SceneManager.GetActiveScene().buildIndex == 0)
       {
           StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
       }
       Debug.Log("There's no more levels to load!");
   }

   IEnumerator LoadLevel(int levelIndex)
   {
       transition.SetTrigger("Crossfade");

       yield return new WaitForSeconds(transitionTime);

       SceneManager.LoadScene(levelIndex);
   }


}
