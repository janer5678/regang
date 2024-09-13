using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;




public class buttononhover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject BigButton;
    public GameObject SmallButton; 

    public void OnPointerEnter(PointerEventData eventData)
    {
        BigButton.SetActive(true);
        SmallButton.SetActive(false);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        print("awooga");
        BigButton.SetActive(false);
        SmallButton.SetActive(true);
    }
}
