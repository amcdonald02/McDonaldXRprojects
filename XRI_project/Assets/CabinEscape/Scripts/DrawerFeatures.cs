using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrawerFeatures : CoreFeatures
{
    [Header("DrawerConfiguration")]
    [SerializeField]
    private Transform drawerSlide;

    [SerializeField]
    private float maxDistance = 1.0f;

    [SerializeField]
    private FeatureDirection featureDirection = FeatureDirection.Forward;

    [SerializeField]
    private bool open = false;

    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private XRSimpleInteractable simpleInteractable;
    S