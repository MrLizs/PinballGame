using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
    public GameObject player;
    public GameObject MyBall;
    Vector3 point;
    float moveSpeed;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("plane");
        moveSpeed = 0.1f;
	}

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID || UNITY_IPHONE
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touDelta = Input.GetTouch(0).deltaPosition;
            Debug.Log(touDelta.x);
            this.playerMove(touDelta);
        }
#elif UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            point = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //Debug.Log(point.x);
            if (point.x > 0.5f)
            {
                this.playerUniformityMove(2);
            }
            else if (point.x < 0.5f)
            {
                this.playerUniformityMove(1);
            }
            MyBall.transform.position = new Vector3(player.transform.position.x, MyBall.transform.position.y);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Vector3 v3 = point - Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //Debug.Log("移动X间距比例" + v3.x);
        }
#endif
    }

    //惯性移动
    void playerMove(Vector2 movepoint)
    {
        Vector2 vec2 = new Vector2(movepoint.x + player.transform.position.x, movepoint.y) * Time.deltaTime;
        player.transform.position = vec2;
    }
    //均衡移动
    void playerUniformityMove(int control)
    {
        if (control == 1)
        {
            if (player.transform.position.x > -8.0f)
            {
                //Debug.Log("左移动"+player.transform.position.x);
                player.transform.position = new Vector3(player.transform.position.x - moveSpeed, player.transform.position.y, -1);
            }
        }
        else if (control == 2)
        {
            if (player.transform.position.x < 8.0f)
            {
                //Debug.Log("右移动"+player.transform.position.x);
                player.transform.position = new Vector3(player.transform.position.x + moveSpeed, player.transform.position.y, -1);
            }
        }
    }

}
