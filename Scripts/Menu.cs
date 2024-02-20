using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public String sceneName;

    public void cargarScene(String sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void salir() {
        Application.Quit();
    }

}
