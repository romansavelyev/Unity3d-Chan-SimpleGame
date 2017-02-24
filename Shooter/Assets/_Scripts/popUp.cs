using UnityEngine;
using System.Collections;


public class popUp : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject portalParticle;
    public GameObject spaceParticle;
    public bool isPaused;

    static private Vector3 trigPos;

    void Start()
    {
        pausePanel.SetActive(false);
        portalParticle.SetActive(false);
        spaceParticle.SetActive(false);
        trigPos = Vector3.zero;

        isPaused = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPaused = true;
            trigPos = transform.position;
            pausePanel.SetActive(isPaused);
        }
    }


    public void Portal()
    {
        portalParticle.SetActive(true);
        GameObject clone = Instantiate(portalParticle, trigPos, Quaternion.identity) as GameObject;
    }

    public void Space()
    {
        spaceParticle.SetActive(true);
        GameObject clone = Instantiate(spaceParticle, transform.position, Quaternion.identity) as GameObject;
    }

    public void ExitMenu()
    {
        pausePanel.SetActive(false);
    }
}