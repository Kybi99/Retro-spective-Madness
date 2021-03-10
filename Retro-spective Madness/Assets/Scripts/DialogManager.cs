using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public NPC npc;
    bool isTalking = false;
    static public bool canTalk = true;
    float distance;
    float curResponseTracker = 0;
    public Animator enemyAnim;

    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;
    
    public Gun gun;
    public PlayerMovement playerMovement;
    public AudioSource gunFireSource;
    public Camera sideCamera;
    public GameObject crosshair;

    void Start()
    {
        sideCamera.gameObject.SetActive(false);
        dialogueUI.SetActive(false);
        GameManager.levelState = GameManager.LevelState.failed;
    }
    private void Update()
    { 
        if (isTalking == true)
        {
            playerMovement.enabled = false;
            gun.enabled = false;
            playerMovement.animator.SetFloat("Speed", 0);
        }
        else 
        {
            playerMovement.enabled = true;
            gun.enabled = true;
        }

    }

    void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 3f && canTalk == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                curResponseTracker++;
                if (curResponseTracker >= npc.playerDialogue.Length - 1)
                {
                    curResponseTracker = npc.playerDialogue.Length - 1;
                }
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                curResponseTracker--;
                if (curResponseTracker < 0)
                {
                    curResponseTracker = 0;
                }
            } 
            if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
            }

            if (curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
                {
                    npcDialogueBox.text = npc.dialogue[1];
                    Invoke("EndDialogue", 1);
                    enemyAnim.Play("Aim");
                    Invoke("BlackScreen", 1);
                    GameManager.levelState = GameManager.LevelState.failed;
                    canTalk = false;
                }
            }
            else if (curResponseTracker == 1 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[1];
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
                {
                    npcDialogueBox.text = npc.dialogue[2];
                    Invoke("EndDialogue", 1);
                    canTalk = false;
                    GameManager.levelState = GameManager.LevelState.failed;
                }
            }
            else if (curResponseTracker == 2 && npc.playerDialogue.Length >= 2)
            {
                playerResponse.text = npc.playerDialogue[2];
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
                {
                    npcDialogueBox.text = npc.dialogue[3];
                    Invoke("EndDialogue", 1);
                    canTalk = false;
                    GameManager.levelState = GameManager.LevelState.solved;
                }
            }
        }
    }

    void StartConversation() 
    {
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }

    void BlackScreen()
    {
        gunFireSource.Play();
        sideCamera.gameObject.SetActive(true);
        crosshair.gameObject.SetActive(false);
        Camera.main.gameObject.SetActive(false);
        Invoke("Restart", 1);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        canTalk = true;
    }
}
