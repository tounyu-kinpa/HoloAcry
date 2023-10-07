using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

// Elementのデータを格納するクラス
public class Element
{
    // Elementの名前を格納
    public string name;

    // Elementの種類を格納
    public string elementType;

    // ElementのlocalScaleを格納
    public Vector3 scale;

    // ElementのlocalPositionを格納
    public Vector3 position;

    // ElementのlocalEulerAnglesを格納
    public Vector3 rotate;

    // Elementのmeshの頂点座標を格納
    public Vector3[] meshVertices;

    // Elementの色の値を格納
    public Color color;
}

[System.Serializable]

// Workの中のすべてのElementと作品名を格納するクラス
public class Work
{
    // 作品の名前を格納
    public string work_name;

    // 作品内のすべてのElementを格納
    public List<Element> elements;
}

[System.Serializable]

// プロジェクト内のすべてのWorkを格納するクラス
public class Model
{
    // すべての作品を格納
    public List<Work> works;
}
