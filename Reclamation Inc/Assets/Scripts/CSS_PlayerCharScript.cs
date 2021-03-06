﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_PlayerCharScript : MonoBehaviour
{
    [Header("Component Pointers")]
    [SerializeField] Rigidbody2D m_RigBody;
    [SerializeField] Transform m_WeaponPos;
    [SerializeField] LineRenderer m_BulletTrail;
    [SerializeField] LayerMask m_EnemyLayerMask;

    [Space]
    [Header("Character Stats")]
    [SerializeField] float healthPoints = 20.0f;

    [Space]
    [Header("Character Movement Settings")]
    [SerializeField] float movementSpeed = 3.0f;
    [SerializeField] float bodyRotateSpeed = 0.2f;

    [Space]
    [Header("Gun Settings")]
    [SerializeField] float fireRate = 0.1f;
    [SerializeField] float gunTriggerTime = 0.2f;
    [SerializeField] float gunDamge = 2.0f;

    private float moveHori;
    private float moveVerti;
    private float forwardRotCor = 90.0f; // Rotation Correction for Up forward (2D)
    private float characterAngle;
    private Vector3 characterDirection;

    private bool bIsGunFiring = false;

    void Start()
    {
        m_RigBody = GetComponent<Rigidbody2D>();
        m_WeaponPos = gameObject.transform.GetChild(0);
        m_BulletTrail = m_WeaponPos.GetComponent<LineRenderer>();
    }

    void Update()
    {
        FireGun();
        FireBullet();
    }

    private void FixedUpdate()
    {
        LookAtMouse();
        CharacterMovementControl();
    }

    void LookAtMouse()
    {
        // Debug
        Debug.DrawRay(transform.position, transform.up * 3, Color.red);
        Debug.DrawRay(m_WeaponPos.position, m_WeaponPos.up * 3, Color.red);

        if(!PlayerManager.Instance.isTaticalMode){

            characterDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            characterAngle = (Mathf.Atan2(characterDirection.y, characterDirection.x) * Mathf.Rad2Deg) - forwardRotCor;
            Quaternion tempRotedAngle = Quaternion.AngleAxis(characterAngle, Vector3.forward);
            //transform.rotation = Quaternion.AngleAxis(fCharacterAngle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, tempRotedAngle, bodyRotateSpeed);
        }
        else{
            // AI mode on

        }
    }

    void CharacterMovementControl()
    {
        if(!PlayerManager.Instance.isTaticalMode){
            
            moveHori = Input.GetAxisRaw("Horizontal");
            moveVerti = Input.GetAxisRaw("Vertical");

            m_RigBody.velocity = new Vector2(moveHori * movementSpeed, moveVerti * movementSpeed);
        }
        // else do nothing and become a mindless turret
    }

    void FireGun()
    {
        // test at home on pc for keyboard and mouse input
        bIsGunFiring = Input.GetMouseButton(0);
        //Debug.Log(bIsGunFiring);
        /*
        // Check Player state
        if (Input.GetMouseButtonDown(0))
        {
            bIsGunFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            bIsGunFiring = false;
        }
        */
    }

    // Prototype with instantiated bullet object
    // Physiccal bullets (save for later base on weapon designs) 
    //void FireBullet()
    //{
    //    if (bIsGunFiring)
    //    {
    //        if (gunTriggerTime > 0.0f)
    //        {
    //            gunTriggerTime -= Time.deltaTime;
    //        }

    //        if (gunTriggerTime < 0.0f)
    //        {

    //            //Spawn Bullet
    //            GameObject tempBullet = Instantiate(m_BulletPrefabPointer, transform.GetChild(0).transform.position, transform.rotation);
    //            tempBullet.GetComponent<Projectile_Bullet>().SetBulletStats(1.0f, 1);

    //            // Trigger Reset
    //            gunTriggerTime = fireRate;
    //        }
    //    }
    //}

    // Raycasting bullets 
    void FireBullet()
    {
        if (bIsGunFiring)
        {
            if (gunTriggerTime > 0.0f)
            {
                gunTriggerTime -= Time.deltaTime;
            }

            if (gunTriggerTime < 0.0f)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(m_WeaponPos.position, m_WeaponPos.up, m_EnemyLayerMask);

                if (hitInfo.rigidbody)
                {
                    Enemy_ParentClass enemy = hitInfo.transform.GetComponent<Enemy_ParentClass>();
                    if(enemy != null)
                    {
                        enemy.TakeDamage(gunDamge);
                    }

                    m_BulletTrail.SetPosition(0, m_WeaponPos.position);
                    m_BulletTrail.SetPosition(1, hitInfo.point);
                }
                else
                {
                    m_BulletTrail.SetPosition(0, m_WeaponPos.position);
                    m_BulletTrail.SetPosition(1, m_WeaponPos.position + m_WeaponPos.up * 3);
                }

                //m_BulletTrail.enabled = true;

                // Trigger Reset
                gunTriggerTime = fireRate;
            }
        }
    }

    public void TakeDamage(float _dmg){

        healthPoints -= _dmg;
        CheckHealth();
    }

    void CheckHealth(){
        if(healthPoints >= 0.0f){
            // Call Defeat screen in game manager
            GameManager.Instance.LoseGame();
        }
    }
}
