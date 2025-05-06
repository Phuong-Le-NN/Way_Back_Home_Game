using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionUI : MonoBehaviour
{
    public GameObject optionPrefab;
    public Transform prevCharacter;
    public Transform selectedCharacter;

    public Text abilityText; 

    private void Start(){
        foreach (Character c in StartGameManager.instance.characters){
            GameObject option = Instantiate(optionPrefab, transform);
            Button button = option.GetComponent<Button>();

            button.onClick.AddListener(() =>{
                StartGameManager.instance.SetCharacter(c);
                
                // Store previous selection for scaling
                if (selectedCharacter != null){
                    prevCharacter = selectedCharacter;
                }
                selectedCharacter = option.transform;


                string abilityInfo = GetAbilityInfo(c.name);
                abilityText.text = abilityInfo;


                SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % 6);
            });

            // Set button UI
            Text text = option.GetComponentInChildren<Text>();
            text.text = c.name;

            Image image = option.GetComponentInChildren<Image>();
            image.sprite = c.icon;
            
            Text ability = option.GetComponentInChildren<Text>();
            ability.text = GetAbilityInfo(c.name);
        }
    }

    private void Update(){
        if (selectedCharacter != null){
            selectedCharacter.localScale = Vector3.Lerp(selectedCharacter.localScale, 
                new Vector3(1.2f, 1.2f, 1.2f), Time.deltaTime * 10);
        }
        if (prevCharacter != null){
            prevCharacter.localScale = Vector3.Lerp(prevCharacter.localScale, 
                new Vector3(1f, 1f, 1f), Time.deltaTime * 10);
        }
    }


    private string GetAbilityInfo(string name){
        if (name == "Corgi"){
            return "Speed: +++\nHealth: +++++";
        } else if (name == "Dalmatian"){
            return "Speed: +++++\nHealth: +++";
        } else {
            return "Speed: N/A\nHealth: N/A"; // default fallback
        }
    }
}