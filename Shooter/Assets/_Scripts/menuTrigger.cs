using UnityEngine;
using System.Collections;

public class menuTrigger : MonoBehaviour {

    public GameObject panel;

	void Start () {
       // panel.SetActive(false);
	}
	

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            Debug.Log("hello");
            panel.SetActive(true);
        }
    }
}
