using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private Image _progressBar;

    public void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);
        do
        {
            _progressBar.fillAmount = scene.progress;
        } while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
        _loaderCanvas.SetActive(false);
    }

}
