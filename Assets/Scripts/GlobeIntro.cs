using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;     
using UnityEngine.SceneManagement;

public class GlobeIntro : MonoBehaviour
{
    public StaticVar staticVar;
    public Text myText;

    private void Start()
    {
        SetText();   
    }
    public void SetText()
    {
        MemberObject selected = staticVar.GetSelected();
        if (selected != null)
        {
            myText.text = "Spin the globe to find out where " + selected.name + " is from!";
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Unloading Scene");
        SceneManager.LoadScene("bulletin");
    }
}
