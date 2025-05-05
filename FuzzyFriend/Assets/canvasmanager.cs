using Unity.VisualScripting;
using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.UI;
using System.Collections;
=======
>>>>>>> Stashed changes

public class canvasmanager : MonoBehaviour
{
    public GameObject openingPage;
    public GameObject namingPage;
    public GameObject Show_CustomizeP;
    public GameObject showTutorialP;
    public GameObject Home;

<<<<<<< Updated upstream
    public float fade = 0.5f;

    GameObject currentPage;

    void Start()
    {
        currentPage = openingPage;
        SetPageInstant(openingPage);
        Debug.Log("we are in opening page ");
    }

    void SetPageInstant(GameObject page)
    {
        openingPage.SetActive(false);
=======

    public Input playername;
    public Input playerPet;


    void Start()
    {
        //ShowOpeningP(); // Or whichever should be the starting screen

        openingPage.SetActive(true);
>>>>>>> Stashed changes
        namingPage.SetActive(false);
        Show_CustomizeP.SetActive(false);
        showTutorialP.SetActive(false);
        Home.SetActive(false);
<<<<<<< Updated upstream

        page.SetActive(true);
        SetCanvasGroupAlpha(page, 1f);
    }

    public void ShowNamingP() => StartCoroutine(TransitionTo(namingPage));
    public void ShowCustomize() => StartCoroutine(TransitionTo(Show_CustomizeP));
    public void showTutorial() => StartCoroutine(TransitionTo(showTutorialP));
    public void ShowHP() => StartCoroutine(TransitionTo(Home));

    IEnumerator TransitionTo(GameObject nextPage)
    {
        if (currentPage == nextPage) yield break;

        CanvasGroup currentGroup = currentPage.GetComponent<CanvasGroup>();
        CanvasGroup nextG = nextPage.GetComponent<CanvasGroup>();

        nextPage.SetActive(true);
        nextG.alpha = 0f;

        float t = 0f;
        while (t < fade)
        {
            t += Time.deltaTime;
            float norm = t / fade;
            currentGroup.alpha = 1f - norm;
            nextG.alpha = norm;
            yield return null;
        }

        currentGroup.alpha = 0f;
        currentPage.SetActive(false);
        nextG.alpha = 1f;

        currentPage = nextPage;
    }

    void SetCanvasGroupAlpha(GameObject obj, float alpha)
    {
        var cg = obj.GetComponent<CanvasGroup>();
        if (cg != null)
        {
            cg.alpha = alpha;
        }
    }

=======
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


>>>>>>> Stashed changes

}
