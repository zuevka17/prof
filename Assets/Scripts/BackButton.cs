using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] GameObject backButton;
    private Animator anim;

    void Start()
    {
        anim = backButton.GetComponent<Animator>(); 
    }

    public void backButtonAnimation()
    {

    }

}
