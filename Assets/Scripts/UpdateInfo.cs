using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateInfo : MonoBehaviour {
    public Initiate init;
    public Text myText;
    public static string text;

    void Start()
    {
        myText.text = text;
    }

	// Update is called once per frame
    public void SetText(){
        MemberObject selected = init.GetSelectedMember();
        if (selected != null)
        {
            text = "Name: " + selected.name + "\n\n";
            text += "Message: " + selected.message + "\n\n";
            text += "Terms On: ";
            for (int i = 0; i < selected.terms_on.Length; i++){
                text += selected.terms_on[i];
            }
            text += "\n\nProjects: ";
            for (int i = 0; i < selected.project.Length; i++)
            {
                text += selected.project[i];
            }
            text += "\n\nLatitude, Longitude: " + selected.lat_long[0] + ", " + selected.lat_long[1] + "\n\n";
            text += "Double click the photo to change scene!";
            myText.text = text;

        }
    }
}
