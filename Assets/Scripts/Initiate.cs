using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;

public class Initiate : MonoBehaviour
{
    // Use the index for future indicating json object in an array
    public int reload_num = 0;
    public bool reload = false;
    public static int jsonIndex = 0;
    public static int jsonLen;
    public static bool downloaded = false;
    private readonly string url = "http://mappy.dali.dartmouth.edu/members.json";
    public static List<MemberObject> member_infos = new List<MemberObject>();
    public static MemberObject selected_member;
    public StaticVar staticVar;
    public UpdateInfo updateInfo;

    void Start()
    {  
        if (!downloaded){
            Download();
            staticVar.BuildSeriesData(member_infos);
        }
    }

    void Download()
    {
        Debug.Log("Downloading member information.\n");
        WebClient webClient = new WebClient();
        string json_string = webClient.DownloadString(url);
        Debug.Log("Download complete.\n");
        Debug.Log(json_string);
        List<string> parsed = ParseJsonObject(json_string);

        for (int i = 0; i < parsed.Count; i++)
        {
            Debug.Log(parsed[i]);
            MemberObject member_i = JsonUtility.FromJson<MemberObject>(parsed[i]);
            member_infos.Add(member_i);
        }
        Debug.Log(member_infos);
        Debug.Log(member_infos.Count);
        downloaded = true;
    }

    private List<string> ParseJsonObject(string json_string)
    {
        List<string> json_object_array = new List<string>();
        int start_index = 0;

        for (int i = 0; i < json_string.Length; i++)
        {
            if (json_string[i] == '{')
            {
                start_index = i;
            }
            if (json_string[i] == '}')
            {
                json_object_array.Add(json_string.Substring(start_index, i - start_index + 1));
            }
        }
        jsonLen = json_object_array.Count;
        return json_object_array;
    }

    public int IcrementIndex(){
        jsonIndex = (jsonIndex + 1) % jsonLen;
        return jsonIndex;
    }

    public int ResetIndex(){
        jsonIndex = (jsonIndex - 5) % jsonLen;
        return jsonIndex;
    }

    public int DecrementIndex(){
        jsonIndex = (jsonIndex - 10) % jsonLen;
        if (jsonIndex < 0) jsonIndex = jsonLen + jsonIndex - 1;
        return jsonIndex;
    }

    public int GetIndex(){
        return jsonIndex;
    }

    public MemberObject GetMember(int member_index){
        return member_infos[member_index];
    }

    public bool IsDownloaded(){
        return downloaded;
    }

    public void SelectMember(MemberObject member){
        selected_member = member;
        updateInfo.SetText();
        staticVar.SelectMember(member);
    }
    public MemberObject GetSelectedMember(){
        return selected_member;
    }
}


public class MemberObject
{
    public string name;
    public string iconUrl;
    public string url;
    public string message;
    public string[] lat_long;
    public string[] terms_on;
    public string[] project;
}
