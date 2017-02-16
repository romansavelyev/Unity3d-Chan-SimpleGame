using UnityEngine;
using System.Collections;


public class popUp : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject portalParticle;
    public GameObject spaceParticle;
    public bool isPaused;

	void Start () {
        pausePanel.SetActive(false);
        portalParticle.SetActive(false);
        spaceParticle.SetActive(false);

	    isPaused = false;
	}

	void Update () {
        if (Input.GetKeyDown("p"))
        {
            isPaused = !isPaused;
            pausePanel.SetActive(isPaused);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPaused = true;
            pausePanel.SetActive(isPaused);
            Debug.Log("I'm triggered");
        }
    }

    public void Portal()
    {
        portalParticle.SetActive(true);
        pausePanel.SetActive(false);
    }

   public void Space()
    {
        spaceParticle.SetActive(true);
        pausePanel.SetActive(false);
    }

   public void ExitMenu()
    {
        pausePanel.SetActive(false);
    }
}
