using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogoColeccionables : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    int index;

    private bool isPlayerInRange;
    public bool didDialogueStart;
    public string[] lines;
    public TextMeshProUGUI dialogueText;
    public float textSpeed = 0.01f;
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.R))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
                Destroy(gameObject);
            }
        }
    }
    public void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        index = 0;
        Time.timeScale = 0f;
        StartCoroutine(WriteLine());
    }
    IEnumerator WriteLine()
    {
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;

            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            gameObject.SetActive(false);
            dialoguePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}