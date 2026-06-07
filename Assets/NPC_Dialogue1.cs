using UnityEngine;
using System.Collections;
using TMPro;

public class NPC_Dialogue1 : MonoBehaviour
{
    [Header("Content")]
    [TextArea(3, 5)] public string npcMessage;
    [TextArea(3, 5)] public string gagneExplanation;
    [TextArea(3, 5)] public string levelCompleteMessage;

    [Header("References")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI textDisplay;
    public GameObject barrierToRemove;
    public ParticleSystem successEffect;
    public GameObject spotlightEffect;
    public GameObject endScreenToEnable; // ΕΔΩ ΕΙΝΑΙ Η ΜΕΤΑΒΛΗΤΗ ΠΟΥ ΕΛΕΙΠΕ!

    private bool isPlayerNearby = false;
    private bool hasInteracted = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && !hasInteracted)
        {
            StartCoroutine(DialogueRoutine());
        }
    }

    private IEnumerator DialogueRoutine()
    {
        if (dialoguePanel == null || textDisplay == null)
        {
            Debug.LogError($"[ΣΦΑΛΜΑ] Στον NPC '{gameObject.name}' λείπει το Dialogue Panel ή το Text Display στον Inspector!", gameObject);
            yield break;
        }

        hasInteracted = true;

        // --- 1ο ΜΗΝΥΜΑ ---
        dialoguePanel.SetActive(true);
        textDisplay.text = npcMessage;

        if (successEffect != null)
        {
            successEffect.Play();
        }

        yield return new WaitForSeconds(5f);

        // --- 2ο ΜΗΝΥΜΑ & ΑΝΑΜΜΑ ΦΩΤΟΣ/ΕΦΕ ---
        if (spotlightEffect != null)
        {
            spotlightEffect.SetActive(true);
        }

        textDisplay.text = gagneExplanation;

        yield return new WaitForSeconds(5f);

        // --- 3ο ΜΗΝΥΜΑ ---
        textDisplay.text = levelCompleteMessage;

        yield return new WaitForSeconds(3f);

        // --- Καταστροφή Εμποδίου ---
        if (barrierToRemove != null)
        {
            barrierToRemove.SetActive(false);
        }

        if (spotlightEffect != null)
        {
            spotlightEffect.SetActive(false);
        }

        // --- ΕΜΦΑΝΙΣΗ ΜΕΝΟΥ ΤΕΛΟΥΣ & ΞΕΚΛΕΙΔΩΜΑ ΠΟΝΤΙΚΙΟΥ ---
        if (endScreenToEnable != null)
        {
            endScreenToEnable.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            dialoguePanel.SetActive(false);
            hasInteracted = false;
        }
    }
}