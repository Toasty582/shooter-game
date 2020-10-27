using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneGM : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingSlider;

    public void LoadLevel(int sceneIndex) {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex) {
        loadingScreen = GameObject.Find("LoadingScreen");
        loadingSlider = GameObject.Find("LoadingBar").GetComponent<Slider>();

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        if (GameObject.Find("Player").GetComponent<Player>() != null) {
            GameObject.Find("Player").GetComponent<Player>().sceneIndex = sceneIndex;
            GameObject.Find("Player").GetComponent<Player>().SavePlayer();
        } else {
            Debug.LogError("Player not found");
        }
        

        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            loadingSlider.value = progress;
            yield return null;
        }
        if (GameObject.Find("Player").GetComponent<Player>() != null) {
            GameObject.Find("Player").GetComponent<Player>().LoadPlayer();
        } else {
            Debug.LogError("Player not found");
        }
    }
}
