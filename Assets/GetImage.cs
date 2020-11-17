using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class GetImage : MonoBehaviour
{
    public Texture2D getPicture;

    public Material faceMat;

    public MeshRenderer faceMesh;

    public Slider transparencySlider;

    public GetTouchPos GetTouchPos_script;
    
    
    public Vector2 currentOffset, oldOffset, startingOffset;
    public bool testingBool;
    
    [SerializeField]
    bool testGetTexture;

    
    private EventSystem _eventSystem;

    void Awake()
    {
        _eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }
    // Update is called once per frame

    void Update()
    {
        if (faceMesh != null)
        {
            faceMesh.material.color = new Color(faceMesh.material.color.r,faceMesh.material.color.g,faceMesh.material.color.b,transparencySlider.value);
        }
    }

    void LateUpdate()
    {

        if (faceMesh != null && EventSystem.current.currentSelectedGameObject != transparencySlider.gameObject && GetTouchPos_script.getnewTouchPos)
        {
            if (testingBool == false)
            {
                testingBool = true;
                startingOffset = GetTouchPos_script.textureOffset;
            }

            currentOffset = GetTouchPos_script.textureOffset;


            var finalOffset = (startingOffset - currentOffset) + oldOffset;

            if (finalOffset.x > 1 || finalOffset.x < -1)
            {
                finalOffset = new Vector2(Mathf.Repeat(finalOffset.x, 1.0f), finalOffset.y);
            }
            
            if (finalOffset.y > 1 || finalOffset.y < -1)
            {
                finalOffset = new Vector2(finalOffset.x, Mathf.Repeat(finalOffset.y, 1.0f));
            }

            faceMesh.material.mainTextureOffset = finalOffset;
        }

        if (GetTouchPos_script.getnewTouchPos == false)
        {
            testingBool = false;
            oldOffset = faceMesh.material.mainTextureOffset;
        }

        if (testGetTexture)
        {
            testGetTexture = false;
            SetFaceTexture();
        }
    }
    
    public void PickImage( int maxSize )
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery( ( path ) =>
        {
            Debug.Log( "Image path: " + path );
            if( path != null )
            {
                // Create Texture from selected image
                getPicture = NativeGallery.LoadImageAtPath( path, maxSize );
                if( getPicture == null )
                {
                    Debug.Log( "Couldn't load texture from " + path );
                    return;
                }

                // If a procedural texture is not destroyed manually, 
                // it will only be freed after a scene change
                //Destroy( getPicture, 5f );
                Debug.Log(getPicture.name);
                GetTouchPos_script.textureOffset = Vector2.zero;                
                SetFaceTexture();
            }
        }, "Select a PNG image", "image/png" );

        Debug.Log( "Permission result: " + permission );
    }
    
    public void SetFaceTexture()
    {
        faceMat.SetTexture("_MainTex", getPicture);
    }


}
