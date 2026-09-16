/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public int itemCount;
    public GameManagerLogic manager;
    bool isJump;
    Rigidbody rigid;
    AudioSource audio;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && !isJump){
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item") {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if (other.tag == "Point") {
            if (itemCount == manager.totalItemCount) {
                // Game Clear!
                if (manager.stage ==2)
                {
                    SceneManager.LoadScene("Example1_0");
                } else
                {
                    SceneManager.LoadScene("Example1_" +(manager.stage + 1).ToString());
                }
            } else
            {
                // Restart

                SceneManager.LoadScene("Example1_" + manager.stage.ToString());
            }
        }
    }
}
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower = 8f;
    public int itemCount;
    public GameManagerLogic manager;
    public float moveSpeed = 5f;  // 공 움직이는 속도
    public float fallY = -10f;   //바닥위치

    bool isJump;
    Rigidbody rigid;
    AudioSource audioSource;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 점프 로직 유지
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

        // ↓ 떨어졌는지 체크
        if (transform.position.y < fallY)
        {
            string current = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(current);  // 현재 스테이지 처음부터
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, 0f, v).normalized;

        Vector3 target = dir * moveSpeed;
        rigid.velocity = new Vector3(target.x, rigid.velocity.y, target.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemCount++;
            if (audioSource) audioSource.Play();
            other.gameObject.SetActive(false);
            if (manager) manager.GetItem(itemCount);
        }
        else if (other.CompareTag("Point"))
        {
            string current = SceneManager.GetActiveScene().name;      // "Ex1_0"
            int idx = int.Parse(current.Split('_')[1]);               // 0,1,2

            if (itemCount == manager.totalItemCount)
            {
                // ✅ 다음 스테이지로
                //string next = (idx < 3) ? $"Ex1_{idx + 1}" : "Ex1_0";
                string next = $"Ex1_{idx + 1}";
                SceneManager.LoadScene(next);
            }
            else
            {
                // ✅ 현재 스테이지 처음부터 재시작
                SceneManager.LoadScene(current);
            }
        }
    }
}
    
