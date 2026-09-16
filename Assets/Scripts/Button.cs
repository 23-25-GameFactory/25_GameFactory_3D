using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 이동용

public class Button : MonoBehaviour
{
    // 전환할 씬 이름을 에디터에서 설정할 수 있게 public 변수로
    public string sceneToLoad = "Start";
    private SceneFader sceneFader;

    private void Start()
    {
        sceneFader = FindObjectOfType<SceneFader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어가 시작 버튼 접근! 페이드 아웃 후 씬 전환!");
            sceneFader.FadeToScene(sceneToLoad);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("버튼 클릭! 페이드 아웃 후 씬 전환!");
        if (sceneFader != null)
        {
            sceneFader.FadeToScene(sceneToLoad);
        }
    }
}