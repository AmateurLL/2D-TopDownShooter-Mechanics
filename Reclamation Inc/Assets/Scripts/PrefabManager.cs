using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public static PrefabManager Instance;

    [Header("Ammo")]
    [SerializeField] public GameObject m_BulletRef;

    [Space]
    [Header("Mobs")]
    [SerializeField] public GameObject m_ZombieRef;

    void Awake(){
        if (Instance == null)
            Instance = this;
    }

}
