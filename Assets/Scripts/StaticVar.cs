using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVar : MonoBehaviour {
    public static SeriesData data;
    public static List<MemberObject> member_list;
    public static MemberObject selected_member;

    public void BuildSeriesData(List<MemberObject> member_infos)
    {
        member_list = member_infos;
        data = new SeriesData();
        Debug.Log(data);
        data.Data = new float[member_infos.Count * 3];
        for (int i = 0; i < member_infos.Count; i++)
        {
            data.Data[3 * i] = float.Parse(member_infos[i].lat_long[0]);
            data.Data[3 * i + 1] = float.Parse(member_infos[i].lat_long[1]);
            data.Data[3 * i + 2] = float.Parse("0.001");
        }
        Debug.Log(data.Data.Length);
    }

    public void SelectMember(MemberObject member){
        selected_member = member;
    }

    public MemberObject GetSelected(){
        return selected_member;
    }

    public SeriesData GetData(){
        return data;
    }
}
