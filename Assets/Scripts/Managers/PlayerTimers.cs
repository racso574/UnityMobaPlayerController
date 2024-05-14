using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimers : MonoBehaviour
{
    [Header("PlayerTimers")]
    static public PlayerTimers Instance;
    public float[] abilityCD;
    public float[] abilityTimers;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Inicializa abilityTimers con la misma longitud que abilityCD
        abilityTimers = new float[abilityCD.Length];

        // Llena abilityTimers con los valores de abilityCD
        for (int i = 0; i < abilityCD.Length; i++)
        {
            abilityTimers[i] = abilityCD[i];
        }
    }

    private void Update()
    {
        for (int i = 0; i < abilityTimers.Length; i++)
        {
            abilityTimers[i] += Time.deltaTime;
        }
    }
}

