using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCarInScene : MonoBehaviour
{
    public static ManageCarInScene Instance { get; set; }
    public List<GameObject> Car = new List<GameObject>();
    public List<GameObject> Path = new List<GameObject>();

    void Start()
    {
        Car.AddRange(GameObject.FindGameObjectsWithTag("Car"));
        Path.AddRange(GameObject.FindGameObjectsWithTag("Path"));
    }
    private void Update()
    {
       
        if (Instance == null)
        {
            Instance = this;
        }
       
        for (int i = Car.Count - 1; i >= 0; i--)
        {
            if (Car[i] == null)
            {
                Car.RemoveAt(i);
            }
        }
       
        if(Car.Count >= 4)
        {
            return;
           
        }
        
        Instantiate(TrafficSystem.Instance.IaCars[Random.Range(1, TrafficSystem.Instance.IaCars.Length)], new Vector3(Random.Range(0, 4), 0, Random.Range(0, 4)), Quaternion.identity);
        Car.AddRange(GameObject.FindGameObjectsWithTag("Car"));
        foreach (var item in Car)
        {
            item.GetComponent<TrafficCar>().atualWay = Path[Random.Range(0, 2)]; //GameObject.FindGameObjectWithTag("Path");
            item.GetComponent<TrafficCar>().path = Path[Random.Range(0, 2)];// GameObject.FindGameObjectWithTag("Path");
        }





    }
   


}/////////////////
