﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemorizePhotos : MonoBehaviour
{
    //public List<ImageInfo> imageList;

    public string[] path;

    public List<string> pathList;

    public string newPath;

    public bool beginArrayAdd;

    private int iteration = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beginArrayAdd)
        {
            beginArrayAdd = false;
            pathList.Add(newPath);
            iteration++;
            Debug.Log("Debugged path: " + pathList[iteration]);
            //AddToArray();
        }
    }

    /*
    void AddToArray()
    {
        string[] tempPath = path;
        path = new string[path.Length + 1];
        for (int i = 0; i < tempPath.Length+1; i++)
        {
            path[i] = tempPath[i];
        }
        path[path.Length] = newPath;

        foreach (var VARIABLE in path)
        {
            Debug.Log("path: " + VARIABLE);
        }
    }
    */
}

public class ImageInfo
{
    private Texture2D picture;
    private string path;
}