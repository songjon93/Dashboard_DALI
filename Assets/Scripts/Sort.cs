using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sort : MonoBehaviour {
    public Dropdown my_dropdown;
    public Initiate init;
    public static int drop_value = 0;

	// Use this for initialization
	void Start () {
        my_dropdown.value = drop_value;
        my_dropdown.onValueChanged.AddListener( delegate {
            HandleSort(my_dropdown);
        });
	}
	
    void HandleSort(Dropdown change){
        drop_value = change.value;
        init.Sort(change.value);
    }
}
