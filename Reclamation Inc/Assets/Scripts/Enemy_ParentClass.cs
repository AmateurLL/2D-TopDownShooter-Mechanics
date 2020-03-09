using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ParentClass : MonoBehaviour
{
    [Header("Component Pointers")]
    [SerializeField] Rigidbody2D m_RigBody;
    [SerializeField] public GameObject m_TargetedObj;

    // Character Stats
    [Space]
    [Header("Character Settings")]
    [SerializeField] float health = 10.0f;
    [SerializeField] float movementSpeed = 0.2f;
    [SerializeField] float detectRadius = 4.0f;

    /// Movement settings
    // Walking settings
    float moveHori;
    float moveVerti;

    // Rotation Settins
    float fRotateSpeed = 0.1f;
    float fForwardRotCor = 90.0f; // Rotation Correction for up Forward (2D)
    float fCharacterAngle;
    Vector3 CharacterDirection;

    // Start is called before the first frame update
    void Start()
    {
        m_RigBody = GetComponent<Rigidbody2D>();
        m_TargetedObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //DetectPlayer();
        LookAtTarget();
    }

    void DetectPlayer()
    {
        Vector2 temp2DPosition = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(temp2DPosition, detectRadius);

        // Search through objects in radius
        for (int i = 0; i < hitColliders.Length; i++)
        {
            // Checking Objects tags
            if(hitColliders[i].tag == "Player")
            {
                // Assigning target pointer
                m_TargetedObj = hitColliders[i].gameObject;
                Debug.Log("Found Player");
            }
            
        }
    }

    void LookAtTarget()
    {
        // Debug
        Debug.DrawRay(transform.position, transform.up * 1.5f, Color.red);

        if (m_TargetedObj != null)
        {
            // Seeking movement
            transform.position = Vector2.MoveTowards(transform.position, m_TargetedObj.transform.position, movementSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(float _dmg)
    {
        health -= _dmg;
        CheckHealth();
        Debug.Log("Enemy hit");
    }

    private void CheckHealth()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }

}
