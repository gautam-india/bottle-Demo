using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class _loadManager : MonoBehaviour
{

    public Slider loadingSlider;



    IEnumerator gameStart(int sceneIndex)
    {
        yield return new WaitForSeconds(0.5f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        //loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progress;
            yield return null;
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(gameStart(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
