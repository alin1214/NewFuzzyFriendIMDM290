using Unity.VisualScripting;
using UnityEngine;

public class canvasmanager : MonoBehaviour
{
    public GameObject openingPage;
    public GameObject namingPage;
    public GameObject Show_CustomizeP;
    public GameObject showTutorialP;
    public GameObject Home;


    public Input playername;
    public Input playerPet;


    void Start()
    {
        //ShowOpeningP(); // Or whichever should be the starting screen

        openingPage.SetActive(true);
        namingPage.SetActive(false);
        Show_CustomizeP.SetActive(false);
        showTutorialP.SetActive(false);
        Home.SetActive(false);
        Debug.Log("we are in opening page ");
    }

    //public void ShowOpeningP()
    //{
    //    openingPage.SetActive(true);
    //    namingPage.SetActive(false);
    //    Show_CustomizeP.SetActive(false);
    //    Debug.Log("we are in opening page ");
    //}

    public void ShowNamingP()
    {
        openingPage.SetActive(false);
        namingPage.SetActive(true);
        Show_CustomizeP.SetActive(false);
        showTutorialP.SetActive(false);
        Home.SetActive(false);
        Debug.Log("we are in naming page ");
    }



    public void showTutorial()
    {
        openingPage.SetActive(false);
        namingPage.SetActive(false);
        Show_CustomizeP.SetActive(false);
    showTutorialP.SetActive(true);
        Home.SetActive(false);
        Debug.Log("we are in tutorial ");
    }

    public void ShowCustomize()
    {
        openingPage.SetActive(false);
        namingPage.SetActive(false);
        showTutorialP.SetActive(false);
        Show_CustomizeP.SetActive(true);
        Home.SetActive(false);
        Debug.Log("we are in custom ");
    }

    public void ShowHP()
    {
        openingPage.SetActive(false);
        namingPage.SetActive(false);
        showTutorialP.SetActive(false);
        Show_CustomizeP.SetActive(false);
        Home.SetActive(true);

        Debug.Log("we are in home ");

    }



}
