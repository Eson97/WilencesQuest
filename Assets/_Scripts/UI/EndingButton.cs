using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        var managers = GameObject.FindWithTag("Managers");
        var backtrace = GameObject.FindWithTag("Backtrace");

        if(managers != null)
            Destroy(managers);
        if(backtrace != null)
            Destroy(backtrace);

        SceneManager.LoadScene(0);
    }
}
