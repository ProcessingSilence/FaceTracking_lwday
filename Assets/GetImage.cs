using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GetImage : MonoBehaviour
{
    public Texture2D getPicture;

    public Material faceMat;

    public MeshRenderer faceMesh;

    [SerializeField]
    bool testGetTexture;

    // Update is called once per frame
    void Update()
    {
        if (faceMesh == null)
            faceMesh = GameObject.FindWithTag("FaceObject").GetComponent<MeshRenderer>();
        else if (faceMesh.material != faceMat)
        {
            faceMat.color = Color.white;
            faceMesh.material = faceMat;
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
