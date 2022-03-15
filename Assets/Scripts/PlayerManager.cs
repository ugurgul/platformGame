using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    public float health, bulletSpeed;

    bool dead = false;

    Transform muzzle;
    public Transform bullet, floatingText, bloodParticle;

    PlayerController playerController;

    public Slider slider;

    bool mouseIsNotOverUI;

    private void Awake() {
        playerController = Object.FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        if(Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            ShootBullet();
        }
    }

    public void GetDamage(float damage)
    {

        Instantiate(floatingText, new Vector3(transform.position.x,transform.position.y+2), Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();


        if((health-damage) >= 0)
        {
            health -= damage;

        }
        else
        {
            health = 0;
       
        }
        slider.value = health;

        AmIDead();
    }

    void AmIDead()
    {
        if(health <= 0)
        {
            Instantiate(bloodParticle,transform.position,Quaternion.identity);
            DataManager.Instance.LoseProcess();
            dead = true;
            Destroy(gameObject);
        }

    }

    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet,muzzle.position,Quaternion.identity);

        if (playerController.facingRight)
        {
            tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.right * bulletSpeed);
            DataManager.Instance.ShotBullet++;
        }
        else{
            tempBullet.GetComponent<Rigidbody2D>().AddForce((muzzle.right*-1) * bulletSpeed);
            DataManager.Instance.ShotBullet++;
        }
    }
}
