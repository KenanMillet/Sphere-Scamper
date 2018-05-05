using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour {

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void SwitchPanels(GameObject currPanel, GameObject nextPanel)
    {
        currPanel.SetActive(false);
        nextPanel.SetActive(true);

    }

    public void Exit(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
