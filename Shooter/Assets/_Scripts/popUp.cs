using UnityEngine;
using System.Collections;


public class popUp : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject canv;
    public GameObject portalParticle;
    public GameObject spaceParticle;
    public bool isPaused;

    static private Vector3 trigPos;
    static private GameObject canvClone;
    static private GameObject panelClone;

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
            canvClone = Instantiate(canv, canv.gameObject.transform.position, Quaternion.identity) as GameObject;
            panelClone = Instantiate(pausePanel, canv.gameObject.transform.position, Quaternion.identity) as GameObject;
            //Time.timeScale = 0.0f;
            panelClone.transform.SetParent(canvClone.transform, false);
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
        Destroy(canvClone);
        Destroy(panelClone);
        Debug.Log("DELETED");
        //Time.timeScale = 1f;
        isPaused = false;
        pausePanel.SetActive(false);
    }
}