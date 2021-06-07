using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField]
    private GameObject A;
    [SerializeField]
    private GameObject B;

    private (int num, string label)[] stats;

    private void Start()
    {
        stats = new (int num, string label)[]
            {
                (56000, "US Soldier Death Count"),
                (1210000, "Vietnam Soldier Death Count"),
                (415000, "Vietnam Civilian Death Count"),
                (130000, "Vietnam Veterans Against the War NYC Demonstration"),
                (278, "US Soldiers/Marines Convicted of Murder / Rape / Other Violent Crime"),
                (504, "My Lai Massacre Death Count"),
                (1500000, "Khmer Rouge's Cambodian Genocide Death Count"),
                (1500000, "Number of Refugees 1975-1985"),
                (2000000, "Total Number of US men who Served in Vietnam"),
                (3000000, "Ho Chi Minh Trail Amount of Bombs Dropped (Ton)"),
                (1000000, "Moritorium Demostration in November of 1969"),
                (206000, "Additional US Troops Requested but Refused for Tet Offensive"),
                (543400, "Highest Concurrent Count of US Troops")
            };
        Display(0, 1);
    }

    public void Display(int x, int y)
    {
        Scale(stats[x].num, stats[y].num);
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
