using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
    public GameObject player;
    Vector3 point;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("plane");
	}

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID || UNITY_IPHONE
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touDelta = Input.GetTouch(0).deltaPosition;
            Debug.Log(touDelta.x);
            player.transform.position.Set(player.transform.position.x + touDelta.x, player.transform.position.y, player.transform.position.z);
        }
#elif UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            point = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 v3 = point - Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Debug.Log("移动X间距比例"+v3.x);

        }
#endif
    }




}
