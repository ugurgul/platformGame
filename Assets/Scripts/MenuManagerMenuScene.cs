using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerMenuScene : MonoBehaviour
{
    public GameObject dataBoard;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void DataBoardShowButton()
    {
        DataManager.Instance.LoadData();
        dataBoard.transform.GetChild(1).GetComponent<Text>().text = "Total Bullet Shoot : " + DataManager.Instance.totalShootBullet.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text = "Total Enemy Killed : " + DataManager.Instance.totalEnemyKilled.ToString();
        dataBoard.SetActive(true);
    }
    public void DataBoardExitButton()
    {
        dataBoard.SetActive(false);
    }
}
