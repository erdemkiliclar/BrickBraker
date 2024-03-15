using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public  GameObject _victoryPanel;
    public GameObject goPanel;

    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }

}
