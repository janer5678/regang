using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayButtonPresser : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject BigButton;
    public GameObject SmallButton;
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        BigButton.SetActive(true);
        SmallButton.SetActive(false);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        BigButton.SetActive(false);
        SmallButton.SetActive(true);
    }
}
