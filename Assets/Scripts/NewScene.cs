using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour {
    public bool startDownload = false;
    public Initiate init;
    public DataVisualizer dataVisualizer;
    private readonly string pic_url = "http://mappy.dali.dartmouth.edu/";
    private MemberObject member;
    Renderer my_renderer;
    private float last_clicked = 0;

private void Update()
    {
        if ((init.reload && ++init.reload_num <= 5) || (!startDownload && init.IsDownloaded())){

            member = init.GetMember(init.GetIndex());
            init.IcrementIndex();
            StartCoroutine(GetPic());
            startDownload = true;

            if (init.reload && init.reload_num == 5){
                init.reload = false;
            }
        }
    }


    IEnumerator GetPic(){
        Debug.Log("Downloading " + member.name + "'s picture");
        Debug.Log("Url is " + pic_url + member.iconUrl);
        UnityWebRequest img_request = UnityWebRequestTexture.GetTexture(pic_url + member.iconUrl);

        yield return img_request.SendWebRequest();

        if (img_request.error != null){
            Debug.Log("Something went wrong.\n");
        }
        my_renderer = GetComponent<Renderer>();
        my_renderer.material.SetTexture("_MainTex", ((DownloadHandlerTexture)img_request.downloadHandler).texture);

        Debug.Log("Image Setting Complete");
    }

    private void OnMouseDown()
    {   
        if (Time.time - last_clicked < .25){
            init.ResetIndex();
            SceneManager.LoadScene("Scenes/population");
        } else {
            init.SelectMember(member);
        }
        last_clicked = Time.time;
    }
}
