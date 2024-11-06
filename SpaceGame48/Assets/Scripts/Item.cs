using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{

    private int activeItemIndex = -1;
    private List<Color> items = new List<Color>();

    [SerializeField] private Canvas canvas;
    private Message messageScript;

    [SerializeField] private Image itemImageHolder;



    Vector4 green = new Vector4(0, 1f, 0, 1f);
    // Start is called before the first frame update
    void Start()
    {
        messageScript = canvas.GetComponent<Message>();
        Debug.Log(messageScript);
        green = new Vector4(0, 1f, 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        CycleItems();
        UseItem();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            PickUpItem(other.gameObject);
        }
    }
    void PickUpItem(GameObject item)
    {

        Color color = item.gameObject.GetComponent<Renderer>().material.color;

        Destroy(item);
        items.Add(color);

        activeItemIndex = items.Count - 1;

        itemImageHolder.color = items[activeItemIndex];
        itemImageHolder.enabled = true;
    }

    void CycleItems()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (items.Count > 0)
            {
                if (activeItemIndex < items.Count - 1)
                {
                    activeItemIndex++;
                }
                else
                {
                    activeItemIndex = 0;
                }
                itemImageHolder.color = items[activeItemIndex];
            }
            else
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }
    }
    void UseItem()
    {
        float cooldownTime = gameObject.GetComponent<Shooting>().CoolDownTime;
        float moveSpeed = gameObject.GetComponent<Movement>().MoveSpeed;
        float rotationSpeed = gameObject.GetComponent<Movement>().RotationSpeed;


        
        if (Input.GetKeyDown(KeyCode.E) && items.Count > 0 && activeItemIndex != -1)
        {

           // Vector4 activeColor = items[activeItemIndex];

            if (items[activeItemIndex] == Color.blue)
            {
                messageScript.StartMessage(" +  Move Speed");
                moveSpeed += 5;
            }
            else if (items[activeItemIndex] == Color.red)
            {
                messageScript.StartMessage(" + Fire Rate");
                cooldownTime -= 0.1f;
            }
            else if (items[activeItemIndex] == Color.green)
            {
                messageScript.StartMessage(" + Rotation Speed");
                rotationSpeed += 10;
            }
            items.RemoveAt(activeItemIndex);
            if (activeItemIndex > 0)
            {
                activeItemIndex--;
                itemImageHolder.color = items[activeItemIndex];
            }
            else if (items.Count == 0)
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }
    }
}
