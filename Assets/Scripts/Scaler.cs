using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField]
    private GameObject A;
    [SerializeField]
    private GameObject B;
    [SerializeField]
    private GameObject labelA_obj;
    [SerializeField]
    private GameObject labelB_obj;
    [SerializeField]
    private GameObject numA_obj;
    [SerializeField]
    private GameObject numB_obj;

    private TextMesh labelA;
    private TextMesh labelB;
    private TextMesh numA;
    private TextMesh numB;
    private (int num, string label)[] stats;
    private int indexA;
    private int indexB;
    private bool changed;

    private void Start()
    {
        labelA = labelA_obj.GetComponent<TextMesh>();
        labelB = labelB_obj.GetComponent<TextMesh>();
        numA = numA_obj.GetComponent<TextMesh>();
        numB = numB_obj.GetComponent<TextMesh>();
        stats = new (int num, string label)[]
            {
                (58000, "US Soldier\nDeath Count"),
                (1210000, "Vietnam Soldier\nDeath Count"),
                (415000, "Vietnam Civilian\nDeath Count"),
                (130000, "Vietnam Veterans\nAgainst the War\nNYC Demonstration"),
                (278, "US Soldiers/Marines\nConvicted of Murder / Rape\n/ Other Violent Crime"),
                (504, "My Lai Massacre\nDeath Count"),
                (1500000, "Khmer Rouge's Cambodian\nGenocide Death Count"),
                (1500000, "Number of Refugees\n1975-1985"),
                (360000, "Number of Refugees\nFrom SE Asia to\nUnited States 1975-1985"),
                (2000000, "Total Number\nof US men\nwho Served in Vietnam"),
                (3000000, "Ho Chi Minh Trail\nAmount of Bombs\nDropped (Tons)"),
                (5000000, "Number of Bombs\nDropped on Vietnam\n(Tons) by the US"),
                (1000000, "Moritorium Demostration\nin November of 1969"),
                (206000, "Additional US Troops\nRequested but Refused\nfor Tet Offensive"),
                (543400, "Highest Concurrent\nCount of US Troops"),
                (2093, "Unacounted for American\nServicemen in the Vietnam War"),
                (224, "Official US Troop MIA\nCount for Vietnam"),
                (405349, "World War II US\nSoldier Death Count"),
                (766, "Americans Held In POW\nCamps in Vietnam"),
                (58000, "Vietnamese Losses During\nthe Tet Offensive"),
                (3895, "American Losses During\nthe Tet Offensive"),
                (100000, "Easter Offensive Vientamese\nCasualities (North Only)"),
                (52000, "Operation ROLLING THUNDER\nVietnamese Casualities (North Only)")
            };
        indexA = 0;
        indexB = 1;
        changed = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickRight))
        {
            indexA++;
            if (indexA >= stats.Length) { indexA = 0; }
            changed = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickLeft))
        {
            indexA--;
            if (indexA < 0) { indexA = stats.Length - 1; }
            changed = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight))
        {
            indexB++;
            if (indexB >= stats.Length) { indexB = 0; }
            changed = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft))
        {
            indexB--;
            if (indexB < 0) { indexB = stats.Length - 1; }
            changed = true;
        }
        if (changed) {
            Display(indexA, indexB);
            changed = false;
        }
    }

    public void Display(int x, int y)
    {
        Scale(stats[x].num, stats[y].num);
        labelA.text = stats[x].label;
        labelB.text = stats[y].label;
        numA.text = stats[x].num.ToString("n0");
        numB.text = stats[y].num.ToString("n0");
    }

    private void Scale(int a, int b)
    {
        if (a > b)
        {
            A.transform.localScale = Vector3.one * 100.0f;
            B.transform.localScale = Vector3.one * ((100.0f * b) / a);
        }
        else
        {
            B.transform.localScale = Vector3.one * 100.0f;
            A.transform.localScale = Vector3.one * ((100.0f * a) / b);
        }
    }
}
