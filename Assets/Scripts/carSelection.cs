using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSelection : MonoBehaviour {
    //We create an empty list of gamObjects
    private GameObject[] carList;
    private int currentCar = 0;

    // Start is called before the first frame update
    void Start()

    {
        //Count the child gameObjects
        carList = new GameObject[transform.childCount];

        //Loop through the chld items and fill the list in correct slot
        for (int i = 0; i < transform.childCount; ++i) {
            carList[i] = transform.GetChild(i).gameObject;
        }

        //Deactivate all gameObjects in list
        foreach (GameObject gameObj in carList) {
            gameObj.SetActive(false);
        }

        //Set initial gameObject to actove
        if (carList[0]) {
            carList[0].SetActive(true);
        }

        
    }

    public void togglecars (string direction) {
        carList [currentCar].SetActive(false);

        if(direction == "Right") {
            currentCar++;
            if(currentCar > carList.Length -1) {
                currentCar=0;
            }
        }
        if(direction == "Left") {
            currentCar--;
            if(currentCar < 0) {
                currentCar = carList.Length -1;
            }
        }

        //set the current car to be active from the list
        carList [currentCar].SetActive(true);
        gameController.currentSelectedCar = carList [currentCar].name;
        GameObject cloudSystem = Instantiate(Resources.Load("cloud")) as GameObject;
        ParticleSystem cloudPuff = cloudSystem.GetComponent<ParticleSystem>();
        cloudPuff.Play();
        cloudPuff.transform.position = new Vector3(22f, -0.5f, -11.3f);
        Destroy (cloudSystem, 2f);

    }

}