using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAB2_2 : MonoBehaviour
{
    public float fadeDuration = 5f;
    private bool isFading = false;
    private Material objectMaterial;

    private void Start()
    {
        if(GetComponent<Renderer>() != null)
        {
            objectMaterial = GetComponent<Renderer>().material;
        }
        else
        {
            Debug.LogError("Không tỉm thấy Render trên đối tượng này");
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isFading && objectMaterial != null)
        {
            StartCoroutine(FadeOut());
        }
    }
    IEnumerator FadeOut()
    {
        isFading = true;
        Color color = objectMaterial.color;
        float startAlpha = color.a;

        for(float i = 0; i < fadeDuration; i += Time.deltaTime)
        {
            float normalizedTime = i / fadeDuration;
            color.a = Mathf.Lerp(startAlpha,0, normalizedTime);
            objectMaterial.color = color;
            yield return new WaitForEndOfFrame();
        }
        color.a = 0;
        objectMaterial.color = color;
        isFading = false;   
    }
}
