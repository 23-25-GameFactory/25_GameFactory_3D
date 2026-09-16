/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text stageCountText;
    public Text playerCountText;

    /*void Awake()
    {
        stageCountText.text = "/ " + totalItemCount;
    }*/
/*
void Awake()
{
        if (stageCountText != null)
            stageCountText.text = "/ " + totalItemCount;
        else
            Debug.LogError("[GameManagerLogic] stageCountText is NOT assigned in Inspector!");

        if (playerCountText != null)
            playerCountText.text = "0";
        else
            Debug.LogError("[GameManagerLogic] playerCountText is NOT assigned in Inspector!");
    }


    public void GetItem(int count)
    {
        playerCountText.text = count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(stage);
        }
    }

}

*/


using UnityEngine;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;       // 이 씬에서 먹어야 할 아이템 개수
    public int stage;                // 0,1,2 (UI 표시에만 사용)
    public Text stageCountText;      // "/ N"
    public Text playerCountText;     // "현재 개수"

    void Awake()
    {
        if (stageCountText != null) stageCountText.text = " " + totalItemCount;
        if (playerCountText != null) playerCountText.text = "0";
    }

    public void GetItem(int count)
    {
        if (playerCountText != null)
            playerCountText.text = count.ToString();
    }

    // ✅ 씬 로드는 여기서 하지 않습니다.
}
