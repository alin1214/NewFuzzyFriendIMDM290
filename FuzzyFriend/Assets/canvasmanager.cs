using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class canvasmanager : MonoBehaviour
{
    public GameObject openingPage;
    public GameObject namingPage;
    public GameObject Show_CustomizeP;
    public GameObject showTutorialP;
    public GameObject Home;

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
        namingPage.SetActive(false);
        Show_CustomizeP.SetActive(false);
        showTutorialP.SetActive(false);
        Home.SetActive(false);

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


}
