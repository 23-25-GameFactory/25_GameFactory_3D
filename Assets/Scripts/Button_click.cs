using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 전환을 위해 필요

public class Button_click : MonoBehaviour
{
    // 특정 씬 이름을 전달받아 이동하는 함수
    public void SceneLoader(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}