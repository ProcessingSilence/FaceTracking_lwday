using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTouchPos : MonoBehaviour
{
    public Vector2 touchPos;

    //[SerializeField] private Camera camera;

    [SerializeField] private Material faceMat;

    private Vector2 screenRes;

    public Vector2 textureOffset;

    //public bool testOffset;
    // Start is called before the first frame update
    void Start()
    {
        faceMat.mainTextureOffset = Vector2.zero;
        screenRes = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        Debug.Log("Resolution: Width- " + screenRes.x + " Height- " + screenRes.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;
            textureOffset = new Vector2(touchPos.x / screenRes.x, -touchPos.y / screenRes.y);
            Debug.Log(textureOffset);   
            //faceMat.mainTextureOffset = textureOffset;
        }

        /*
        if (testOffset)
        {
            testOffset = false;
            faceMat.mainTextureOffset = touchPos;
        }
        */
    }
}
