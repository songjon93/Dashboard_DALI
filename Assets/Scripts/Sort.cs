using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sort : MonoBehaviour {
    public Dropdown my_dropdown;
    public Initiate init;

	// Use this for initialization
	void Start () {
        my_dropdown.onValueChanged.AddListener( delegate {
            HandleSort(my_dropdown);
        });
	}
	
    void HandleSort(Dropdown change){
        init.Sort(change.value);
    }
}
