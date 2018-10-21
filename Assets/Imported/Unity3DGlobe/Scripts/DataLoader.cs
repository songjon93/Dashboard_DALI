using UnityEngine;
using System.Collections;

public class DataLoader : MonoBehaviour {
    public DataVisualizer Visualizer;
    public StaticVar staticVar;

    private void Start()
    {
        Debug.Log(staticVar.GetData().Data.Length);
        Visualizer.CreateMeshes(new SeriesData[] { staticVar.GetData() });
    }

    void Update () {

    }
}
[System.Serializable]
public class SeriesArray
{
    public SeriesData[] AllData;
}