using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public int level = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            LoadNextLevel();
        }
    }

    public void LoadNextLevel(){
        if(SceneManager.GetActiveScene().buildIndex == 0){
            level = 1;
        } else if(SceneManager.GetActiveScene().buildIndex == 1){
            level = 0;
        }
        StartCoroutine(LoadLevel(level));
    }

    IEnumerator LoadLevel(int levelIndex){
        // play animation
        transition.SetTrigger("Start");
        // wait
        yield return new WaitForSeconds(transitionTime);
        // load scene
        SceneManager.LoadScene(levelIndex);

    }
}
