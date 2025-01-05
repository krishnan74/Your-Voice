using System.Collections;
using UnityEngine;

public class StrikeOutAnimation : MonoBehaviour
{
    public GameObject strikeOutCube; // The cube GameObject to animate
    public float targetWidth = 5f;  // The desired width after animation
    public float duration = 2f;     // Duration of the animation

    void Start()
    {
        if (strikeOutCube != null)
        {
            StartCoroutine(AnimateWidth());
        }
        else
        {
            Debug.LogError("StrikeOutCube is not assigned!");
        }
    }

    IEnumerator AnimateWidth()
    {
        Vector3 initialScale = strikeOutCube.transform.localScale;
        Vector3 targetScale = new Vector3(targetWidth, initialScale.y, initialScale.z);

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            strikeOutCube.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final scale is set
        strikeOutCube.transform.localScale = targetScale;
    }
}
