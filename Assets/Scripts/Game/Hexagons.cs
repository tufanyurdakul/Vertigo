using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagons : MonoBehaviour
{
    public int Id { get; private set; }
    public int HexId { get; private set; }
    public void SetModel(HexModel hex)
    {
        this.Id = hex.Id;
        this.HexId = hex.HexId;
    }
}
