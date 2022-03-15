using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{


    private int shotBullet;
    public int totalShootBullet;
    private int enemyKilled;
    public int totalEnemyKilled;

    EasyFileSave myFile;

    public static DataManager Instance;

    private void Awake() {
        
        if (Instance == null)
        {
            Instance = this;
            StartProcess();

        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        
    }

    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = "SHOTBULLET :" + shotBullet.ToString();
        }
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "ENEMY KILLED :" + enemyKilled.ToString();
            WinProcess();
        }
    }


    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();

    }

    public void SaveData()
    {
        totalShootBullet += shotBullet;
        totalEnemyKilled += enemyKilled;

        myFile.Add("totalShotBullet",totalShootBullet);
        myFile.Add("totalEnemyKilled",totalEnemyKilled);

        myFile.Save();
    }

    public void LoadData()
    {
        if (myFile.Load())
        {
            totalShootBullet = myFile.GetInt("totalShotBullet");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
        }
    }

    public void WinProcess()
    {
        if (enemyKilled >= 5)
        {
            print ("YOU WON!!!");
        }
    }

    public void LoseProcess()
    {
        print("YOU LOST!!!");
    }





}
