using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTransitionScript : MonoBehaviour
{
    public GameObject pannel1;
    public GameObject pannel2;
    public GameObject pannel3;
    public GameObject pannel4;
    public GameObject Canvas;
    public GameObject MainMenu;
    public GameObject CanvasSlide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pannel1()
    {
        pannel1.SetActive(true);

    }

    public void Pannel2()
    {
        pannel1.SetActive(false);
        pannel2.SetActive(true);
    }

    public void Pannel3()
    {
        pannel2.SetActive(false);
        pannel3.SetActive(true);
    }

    public void Pannel4()
    {
        pannel3.SetActive(false);
        pannel4.SetActive(true);
    }

    public void Menu()
    {
        pannel4.SetActive(false);
        CanvasSlide.SetActive(false);
        MainMenu.SetActive(true);
        Canvas.SetActive(true);
    }
}
