using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //Public variable for Menu to quick reference
    //Creating PROPERTY Values: Encapsulation variable
    //Get Accesor (READ)
    //Set Accesor (WRITE)

    [field: SerializeField]
    public Button ResumeButton {  get; set; }

    [field: SerializeField]
    public Button RestartButton { get; set; }

    [field: SerializeField]
    public TextMeshProUGUI SolvedText {  get; set; }

}
