using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperHeroUpExperience : MonoBehaviour
{
    ExperienceComponent experienceComponent;

    void Awake()
    {
        experienceComponent = GetComponentInChildren<ExperienceComponent>();
    }

    void OnTargetKill()
    {
        experienceComponent.value += 25;
    }  
}
