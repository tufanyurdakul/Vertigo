using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class CreateHexagon : MonoBehaviour
{
    public GameObject BackGround,EndGame;
    public Tilemap tileMap;
    public Tile[] tile;
    public int Vertical, Horizantal, ScoreBomb, NextScoreBomb;
    public List<string> namesOfHexes;
    private Dictionary<Vector3Int, string> choosenTiles;
    private Vector3 pos;
    private Vector3Int tilePos, tilePosSecond, tilePosThird;
    private bool rotating = false;
    public Score ScoreObject;
    private List<TextModel> Texts;
    private GameObject textOfBomb;
    private bool FinishGame = false;
    enum Hexes
    {
        blue = 0,
        yellow = 1,
        green = 2,
        red = 3,
        purple = 4
    }
    private void OnMouseDown()
    {
        if (!FinishGame)
        {
            Vector3 posControl = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int posControlInt = tileMap.WorldToCell(new Vector3(posControl.x, posControl.y, 0));
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (choosenTiles.ContainsKey(posControlInt) && posControlInt == tilePos && rotating)
            {
                //If you click choosen tile and it doesn't rotate
            }
            else
            {
                #region choosenTilesAccordingToClick
                foreach (var item in choosenTiles)
                {
                    for (int i = 0; i < namesOfHexes.Count; i++)
                    {
                        if (namesOfHexes[i] == item.Value)
                        {
                            tileMap.SetTile(item.Key, tile[i]);
                        }
                    }
                }
                choosenTiles = new Dictionary<Vector3Int, string>();
                tilePosSecond = Vector3Int.zero;
                tilePosThird = Vector3Int.zero;
                tilePos = tileMap.WorldToCell(new Vector3(pos.x, pos.y, 0));
                Vector3 clickedPos = tileMap.CellToWorld(tilePos);
                if (tilePos.y < Horizantal - 1)
                {

                }
                float distanceX = Mathf.Abs(pos.x - clickedPos.x);
                float distanceY = Mathf.Abs(pos.y - clickedPos.y);
                float valueOfY = pos.y - clickedPos.y;
                float valueOfX = pos.x - clickedPos.x;
                if (distanceX > distanceY)
                {
                    if (valueOfX < 0)
                    {

                        tilePosSecond = new Vector3Int(tilePos.x - 1, tilePos.y, 0);
                        if (valueOfY < 0)
                        {
                            if (tilePos.y % 2 == 1)
                            {
                                tilePosThird = new Vector3Int(tilePos.x, tilePos.y - 1, 0);
                            }
                            else
                            {
                                tilePosThird = new Vector3Int(tilePosSecond.x, tilePos.y - 1, 0);
                            }
                        }
                        else
                        {
                            if (tilePos.y % 2 == 1)
                            {
                                tilePosThird = new Vector3Int(tilePos.x, tilePos.y + 1, 0);
                            }
                            else
                            {
                                tilePosThird = new Vector3Int(tilePosSecond.x, tilePos.y + 1, 0);
                            }
                        }
                    }
                    else
                    {
                        tilePosSecond = new Vector3Int(tilePos.x + 1, tilePos.y, 0);

                        if (valueOfY < 0)
                        {
                            if (tilePos.y % 2 == 0)
                            {
                                tilePosThird = new Vector3Int(tilePos.x, tilePos.y - 1, 0);
                            }
                            else
                            {
                                tilePosThird = new Vector3Int(tilePosSecond.x, tilePosSecond.y - 1, 0);
                            }
                        }
                        else
                        {
                            if (tilePos.y % 2 == 1)
                            {
                                tilePosThird = new Vector3Int(tilePosSecond.x, tilePosSecond.y + 1, 0);
                            }
                            else
                            {
                                tilePosThird = new Vector3Int(tilePos.x, tilePos.y + 1, 0);
                            }
                        }
                    }
                }
                else
                {
                    if (valueOfY < 0)
                    {
                        if (tilePos.y % 2 == 0)
                        {
                            tilePosSecond = new Vector3Int(tilePos.x, tilePos.y - 1, 0);

                        }
                        else
                        {
                            tilePosSecond = new Vector3Int(tilePos.x + 1, tilePos.y - 1, 0);

                        }
                        if (valueOfX < 0)
                        {
                            if (tilePos.y % 2 == 0)
                            {
                                tilePosThird = new Vector3Int(tilePos.x - 1, tilePos.y - 1, 0);
                            }
                            else
                            {
                                tilePosThird = new Vector3Int(tilePos.x, tilePosSecond.y, 0);
                            }
                        }
                        else
                        {
                            if (tilePos.y % 2 == 1)
                            {
                                tilePosThird = new Vector3Int(tilePos.x + 1, tilePos.y, 0);
                            }
                            else
                            {
                                tilePosThird = new Vector3Int(tilePos.x + 1, tilePosSecond.y + 1, 0);
                            }
                        }
                    }
                    else
                    {
                        if (tilePos.y % 2 == 0)
                        {
                            tilePosSecond = new Vector3Int(tilePos.x, tilePos.y + 1, 0);

                        }
                        else
                        {
                            tilePosSecond = new Vector3Int(tilePos.x + 1, tilePos.y + 1, 0);

                        }
                        if (valueOfX < 0)
                        {
                            if (tilePos.y % 2 == 0)
                            {
                                tilePosThird = new Vector3Int(tilePos.x - 1, tilePos.y + 1, 0);
                            }
                            else
                            {
                                tilePosThird = new Vector3Int(tilePos.x, tilePosSecond.y, 0);
                            }
                        }
                        else
                        {
                            if (tilePos.y % 2 == 1)
                            {
                                tilePosThird = new Vector3Int(tilePos.x + 1, tilePos.y, 0);
                            }
                            else
                            {
                                tilePosThird = new Vector3Int(tilePos.x + 1, tilePosSecond.y - 1, 0);
                            }
                        }
                    }

                }
                if (tileMap.GetTile(tilePos) != null && tileMap.GetTile(tilePosSecond) != null && tileMap.GetTile(tilePosThird) != null)
                {
                    TileBase tb = tileMap.GetTile(tilePos);
                    TileBase tb2 = tileMap.GetTile(tilePosSecond);
                    TileBase tb3 = tileMap.GetTile(tilePosThird);
                    choosenTiles.Add(tilePos, tb.name);
                    choosenTiles.Add(tilePosSecond, tb2.name);
                    choosenTiles.Add(tilePosThird, tb3.name);
                    tileMap.SetTile(tilePos, tile[5]);
                    tileMap.SetTile(tilePosSecond, tile[5]);
                    tileMap.SetTile(tilePosThird, tile[5]);
                }
            }
            #endregion
        }
    }
    private void OnMouseDrag()
    {
        if (!FinishGame)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tilePosition = tileMap.WorldToCell(new Vector3(position.x, position.y, 0));
            int rotate = 0;
            if (choosenTiles.Count > 0)
            {
                bool isDrag = false;
                foreach (var item in choosenTiles)
                {
                    if (item.Key == tilePosition)
                    {
                        isDrag = true;
                        break;
                    }
                }
                if (isDrag)
                {
                    //rotating
                    #region rotatingDecision
                    Vector3 positionDrag = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    float xDistance = Mathf.Abs(positionDrag.x - pos.x);
                    float yDistance = Mathf.Abs(positionDrag.y - pos.y);
                    if (xDistance > yDistance && xDistance > 0.1f)
                    {
                        if (tileMap.CellToWorld(tilePosition).y < positionDrag.y)
                        {
                            if (positionDrag.x - pos.x > 0)
                            {
                                rotate = -1;
                            }
                            else
                            {
                                rotate = +1;
                            }
                        }
                        else
                        {
                            if (positionDrag.x - pos.x > 0)
                            {
                                rotate = +1;
                            }
                            else
                            {
                                rotate = -1;
                            }
                        }

                    }
                    else if (yDistance > xDistance && yDistance > 0.1f)
                    {
                        if (tileMap.CellToWorld(tilePosition).x < positionDrag.x)
                        {
                            if (positionDrag.y - pos.y > 0)
                            {
                                rotate = 1;
                            }
                            else
                            {
                                rotate = -1;
                            }
                        }
                        else
                        {
                            if (positionDrag.y - pos.y > 0)
                            {
                                rotate = -1;
                            }
                            else
                            {
                                rotate = 1;
                            }
                        }
                    }
                    #endregion
                }
                #region rotating
                if (rotate != 0 && !rotating)
                {
                    //rotate hexes
                    string firstName = string.Empty, secondName = string.Empty, thirdName = string.Empty;
                    rotating = true;
                    if (rotate == -1)
                    {
                        for (int i = 0; i < namesOfHexes.Count; i++)
                        {
                            if (namesOfHexes[i] == choosenTiles[this.tilePos])
                            {
                                tileMap.SetTile(tilePosSecond, tile[i]);
                                secondName = namesOfHexes[i];

                            }
                            if (namesOfHexes[i] == choosenTiles[tilePosSecond])
                            {
                                tileMap.SetTile(tilePosThird, tile[i]);
                                thirdName = namesOfHexes[i];

                            }
                            if (namesOfHexes[i] == choosenTiles[tilePosThird])
                            {
                                tileMap.SetTile(this.tilePos, tile[i]);
                                firstName = namesOfHexes[i];
                            }
                        }
                        //control hex destroy
                        Catch(tilePosSecond.x, tilePosSecond.y, secondName);
                        Catch(tilePosThird.x, tilePosThird.y, thirdName);
                        Catch(tilePos.x, tilePos.y, firstName);
                    }
                    else
                    {
                        //rotate hexes
                        for (int i = 0; i < namesOfHexes.Count; i++)
                        {
                            if (namesOfHexes[i] == choosenTiles[this.tilePos])
                            {
                                tileMap.SetTile(tilePosThird, tile[i]);
                                thirdName = namesOfHexes[i];
                            }
                            if (namesOfHexes[i] == choosenTiles[tilePosSecond])
                            {
                                tileMap.SetTile(this.tilePos, tile[i]);
                                firstName = namesOfHexes[i];
                            }
                            if (namesOfHexes[i] == choosenTiles[tilePosThird])
                            {
                                tileMap.SetTile(tilePosSecond, tile[i]);
                                secondName = namesOfHexes[i];
                            }
                        }
                        //control hex destroy
                        Catch(tilePosThird.x, tilePosThird.y, thirdName);
                        Catch(tilePos.x, tilePos.y, firstName);
                        Catch(tilePosSecond.x, tilePosSecond.y, secondName);
                    }
                    // not play when rotate
                    rotating = false;
                }
                #endregion
            }
        }
    }
    void Start()
    {
        textOfBomb = Resources.Load("Prefab/BombText") as GameObject;
        Texts = new List<TextModel>();
        choosenTiles = new Dictionary<Vector3Int, string>();
        float sizing = ((float)Vertical * tileMap.transform.localScale.x * (BackGround.transform.localScale.y / 0.3f)) / (tileMap.cellBounds.size.x);
        int plusCoordinate = (int)((float)tileMap.cellBounds.position.x * sizing);
        tileMap.transform.localScale = new Vector3(tileMap.transform.localScale.x / sizing, tileMap.transform.localScale.y / sizing, tileMap.transform.localScale.z);
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        collider.size = new Vector2(collider.size.x * sizing, collider.size.y * sizing);

        for (int i = 0; i < Vertical; i++)
        {
            for (int j = 0; j < Horizantal; j++)
            {
                Vector3Int vec = new Vector3Int(i + plusCoordinate, j, 0);
                int random = Random.Range(0, 5);
                if (i > 0 && j < Horizantal - 1)
                {
                    if ((tileMap.GetTile(new Vector3Int(i + plusCoordinate - 1, j, 0)).name == namesOfHexes[random]) && (tileMap.GetTile(new Vector3Int(i + plusCoordinate - 1, j + 1, 0)).name == namesOfHexes[random]))
                    {
                        j--;
                        continue;
                    }
                    if (j > 0 && (tileMap.GetTile(new Vector3Int(i + plusCoordinate - 1, j, 0)).name == namesOfHexes[random]) && (tileMap.GetTile(new Vector3Int(i + plusCoordinate, j - 1, 0)).name == namesOfHexes[random]))
                    {
                        j--;
                        continue;
                    }
                    if (j > 0 && (tileMap.GetTile(new Vector3Int(i + plusCoordinate - 1, j - 1, 0)).name == namesOfHexes[random]) && (tileMap.GetTile(new Vector3Int(i + plusCoordinate, j - 1, 0)).name == namesOfHexes[random]))
                    {
                        j--;
                        continue;
                    }
                    if (j > 0 && (tileMap.GetTile(new Vector3Int(i + plusCoordinate - 1, j - 1, 0)).name == namesOfHexes[random]) && (tileMap.GetTile(new Vector3Int(i + plusCoordinate - 1, j, 0)).name == namesOfHexes[random]))
                    {
                        j--;
                        continue;
                    }
                    else
                    {
                        tileMap.SetTile(vec, tile[random]);
                        TileBase tb = tileMap.GetTile(new Vector3Int(i + plusCoordinate, j, 0));
                        tb.name = "" + namesOfHexes[random];
                    }
                }
                else
                {
                    if (j == Horizantal - 1 && i > 0)
                    {
                        if ((tileMap.GetTile(new Vector3Int(i + plusCoordinate - 1, j, 0)).name == namesOfHexes[random]) && (tileMap.GetTile(new Vector3Int(i + plusCoordinate - 1, j - 1, 0)).name == namesOfHexes[random]))
                        {
                            j--;
                        }
                        if ((tileMap.GetTile(new Vector3Int(i + plusCoordinate - 1, j, 0)).name == namesOfHexes[random]) && (tileMap.GetTile(new Vector3Int(i + plusCoordinate, j - 1, 0)).name == namesOfHexes[random]))
                        {
                            j--;
                        }
                        if ((tileMap.GetTile(new Vector3Int(i + plusCoordinate - 1, j - 1, 0)).name == namesOfHexes[random]) && (tileMap.GetTile(new Vector3Int(i + plusCoordinate, j - 1, 0)).name == namesOfHexes[random]))
                        {
                            j--;
                        }
                        else
                        {
                            tileMap.SetTile(vec, tile[random]);
                            TileBase tb = tileMap.GetTile(new Vector3Int(i + plusCoordinate, j, 0));
                            tb.name = "" + namesOfHexes[random];
                        }
                    }
                    else
                    {
                        tileMap.SetTile(vec, tile[random]);
                        TileBase tb = tileMap.GetTile(new Vector3Int(i + plusCoordinate, j, 0));
                        tb.name = "" + namesOfHexes[random];
                    }
                }
            }
        }
    }
    //Destroying And Create New Tiles
    private void Catch(int xPos, int yPos, string name)
    {
        int countOfPoint = 1;
        Vector3Int one = Vector3Int.zero, two = Vector3Int.zero, three = Vector3Int.zero;
        bool inThis = false;
        #region destroyRules
        if (yPos % 2 == 0)
        {
            if (tileMap.GetTile(new Vector3Int(xPos - 1, yPos, 0)) != null && tileMap.GetTile(new Vector3Int(xPos - 1, yPos + 1, 0)) != null )
            {
                if ((tileMap.GetTile(new Vector3Int(xPos - 1, yPos, 0)).name == name) && (tileMap.GetTile(new Vector3Int(xPos - 1, yPos + 1, 0)).name == name))
                {
                    one = new Vector3Int(xPos - 1, yPos, 0);
                    two = new Vector3Int(xPos - 1, yPos + 1, 0);
                    three = new Vector3Int(xPos, yPos, 0);
                    inThis = true;
                    countOfPoint = ControlDestroy(one, two, three) > 1 ? ControlDestroy(one, two, three) : countOfPoint;
                }
            }
            if (tileMap.GetTile(new Vector3Int(xPos, yPos + 1, 0)) != null && tileMap.GetTile(new Vector3Int(xPos - 1, yPos + 1, 0)) != null )
            {
                if ((tileMap.GetTile(new Vector3Int(xPos, yPos + 1, 0)).name == name) && (tileMap.GetTile(new Vector3Int(xPos - 1, yPos + 1, 0)).name == name))
                {
                    one = new Vector3Int(xPos, yPos + 1, 0);
                    two = new Vector3Int(xPos - 1, yPos + 1, 0);
                    three = new Vector3Int(xPos, yPos, 0);
                    countOfPoint = ControlDestroy(one, two, three) > 1 ? ControlDestroy(one, two, three) : countOfPoint;
                    inThis = true;
                }
            }
            if (tileMap.GetTile(new Vector3Int(xPos + 1, yPos, 0)) != null && tileMap.GetTile(new Vector3Int(xPos, yPos + 1, 0)) != null )
            {
                if ((tileMap.GetTile(new Vector3Int(xPos + 1, yPos, 0)).name == name) && (tileMap.GetTile(new Vector3Int(xPos, yPos + 1, 0)).name == name))
                {
                    one = new Vector3Int(xPos + 1, yPos, 0);
                    two = new Vector3Int(xPos, yPos + 1, 0);
                    three = new Vector3Int(xPos, yPos, 0);
                    countOfPoint = ControlDestroy(one, two, three) > 1 ? ControlDestroy(one, two, three) : countOfPoint;
                }
            }
            if (tileMap.GetTile(new Vector3Int(xPos - 1, yPos - 1, 0)) != null && tileMap.GetTile(new Vector3Int(xPos - 1, yPos, 0)) != null )
            {
                if ((tileMap.GetTile(new Vector3Int(xPos - 1, yPos - 1, 0)).name == name) && (tileMap.GetTile(new Vector3Int(xPos - 1, yPos, 0)).name == name))
                {
                    one = new Vector3Int(xPos - 1, yPos - 1, 0);
                    two = new Vector3Int(xPos - 1, yPos, 0);
                    three = new Vector3Int(xPos, yPos, 0);
                    countOfPoint = ControlDestroy(one, two, three) > 1 ? ControlDestroy(one, two, three) : countOfPoint;
                    inThis = true;
                }
            }
            if (tileMap.GetTile(new Vector3Int(xPos - 1, yPos - 1, 0)) != null && tileMap.GetTile(new Vector3Int(xPos, yPos - 1, 0)) != null  )
            {
                if ((tileMap.GetTile(new Vector3Int(xPos - 1, yPos - 1, 0)).name == name) && (tileMap.GetTile(new Vector3Int(xPos, yPos - 1, 0)).name == name))
                {
                    one = new Vector3Int(xPos - 1, yPos - 1, 0);
                    two = new Vector3Int(xPos, yPos - 1, 0);
                    three = new Vector3Int(xPos, yPos, 0);
                    countOfPoint = ControlDestroy(one, two, three) > 1 ? ControlDestroy(one, two, three) : countOfPoint;
                    inThis = true;
                }
            }
            if (tileMap.GetTile(new Vector3Int(xPos + 1, yPos, 0)) != null && tileMap.GetTile(new Vector3Int(xPos, yPos - 1, 0)) != null  )
            {
                if ((tileMap.GetTile(new Vector3Int(xPos + 1, yPos, 0)).name == name) && (tileMap.GetTile(new Vector3Int(xPos, yPos - 1, 0)).name == name))
                {
                    one = new Vector3Int(xPos + 1, yPos, 0);
                    two = new Vector3Int(xPos, yPos - 1, 0);
                    three = new Vector3Int(xPos, yPos, 0);
                    countOfPoint = ControlDestroy(one, two, three) > 1 ? ControlDestroy(one, two, three) : countOfPoint;
                    inThis = true;
                }
            }
        }
        else
        {
            if (tileMap.GetTile(new Vector3Int(xPos - 1, yPos, 0)) != null && tileMap.GetTile(new Vector3Int(xPos, yPos + 1, 0)) != null )
            {
                if ((tileMap.GetTile(new Vector3Int(xPos - 1, yPos, 0)).name == name) && (tileMap.GetTile(new Vector3Int(xPos, yPos + 1, 0)).name == name))
                {
                    one = new Vector3Int(xPos - 1, yPos, 0);
                    two = new Vector3Int(xPos, yPos + 1, 0);
                    three = new Vector3Int(xPos, yPos, 0);
                    countOfPoint = ControlDestroy(one, two, three) > 1 ? ControlDestroy(one, two, three) : countOfPoint;
                    inThis = true;

                }
            }
            if (tileMap.GetTile(new Vector3Int(xPos + 1, yPos + 1, 0)) != null && tileMap.GetTile(new Vector3Int(xPos, yPos + 1, 0)) != null )
            {
                if ((tileMap.GetTile(new Vector3Int(xPos + 1, yPos + 1, 0)).name == name) && (tileMap.GetTile(new Vector3Int(xPos, yPos + 1, 0)).name == name))
                {
                    one = new Vector3Int(xPos + 1, yPos + 1, 0);
                    two = new Vector3Int(xPos, yPos + 1, 0);
                    three = new Vector3Int(xPos, yPos, 0);
                    countOfPoint = ControlDestroy(one, two, three) > 1 ? ControlDestroy(one, two, three) : countOfPoint;
                    inThis = true;
                }
            }
            if (tileMap.GetTile(new Vector3Int(xPos + 1, yPos, 0)) != null && tileMap.GetTile(new Vector3Int(xPos + 1, yPos + 1, 0)) != null )
            {
                if ((tileMap.GetTile(new Vector3Int(xPos + 1, yPos, 0)).name == name) && (tileMap.GetTile(new Vector3Int(xPos + 1, yPos + 1, 0)).name == name))
                {
                    one = new Vector3Int(xPos + 1, yPos, 0);
                    two = new Vector3Int(xPos + 1, yPos + 1, 0);
                    three = new Vector3Int(xPos, yPos, 0);
                    countOfPoint = ControlDestroy(one, two, three) > 1 ? ControlDestroy(one, two, three) : countOfPoint;
                    inThis = true;
                }
            }
            if (tileMap.GetTile(new Vector3Int(xPos - 1, yPos, 0)) != null && tileMap.GetTile(new Vector3Int(xPos, yPos - 1, 0)) != null )
            {
                if ((tileMap.GetTile(new Vector3Int(xPos - 1, yPos, 0)).name == name) && (tileMap.GetTile(new Vector3Int(xPos, yPos - 1, 0)).name == name))
                {
                    one = new Vector3Int(xPos - 1, yPos, 0);
                    two = new Vector3Int(xPos, yPos - 1, 0);
                    three = new Vector3Int(xPos, yPos, 0);
                    countOfPoint = ControlDestroy(one, two, three) > 1 ? ControlDestroy(one, two, three) : countOfPoint;
                    inThis = true;
                }
            }
            if (tileMap.GetTile(new Vector3Int(xPos, yPos - 1, 0)) != null && tileMap.GetTile(new Vector3Int(xPos + 1, yPos - 1, 0)) != null )
            {
                if ((tileMap.GetTile(new Vector3Int(xPos, yPos - 1, 0)).name == name) && (tileMap.GetTile(new Vector3Int(xPos + 1, yPos - 1, 0)).name == name))
                {
                    one = new Vector3Int(xPos, yPos - 1, 0);
                    two = new Vector3Int(xPos + 1, yPos - 1, 0);
                    three = new Vector3Int(xPos, yPos, 0);
                    countOfPoint = ControlDestroy(one, two, three) > 1 ? ControlDestroy(one, two, three) : countOfPoint;
                    inThis = true;
                }
            }
            if (tileMap.GetTile(new Vector3Int(xPos + 1, yPos, 0)) != null && tileMap.GetTile(new Vector3Int(xPos + 1, yPos - 1, 0)) != null)
            {
                if ((tileMap.GetTile(new Vector3Int(xPos + 1, yPos, 0)).name == name) && (tileMap.GetTile(new Vector3Int(xPos + 1, yPos - 1, 0)).name == name))
                {
                    one = new Vector3Int(xPos + 1, yPos, 0);
                    two = new Vector3Int(xPos + 1, yPos - 1, 0);
                    three = new Vector3Int(xPos, yPos, 0);
                    countOfPoint = ControlDestroy(one, two, three) > 1 ? ControlDestroy(one, two, three) : countOfPoint;
                    inThis = true;
                }
            }
            if (tileMap.GetTile(new Vector3Int(xPos + 1, yPos, 0)) != null && tileMap.GetTile(new Vector3Int(xPos , yPos + 1, 0)) != null)
            {
                if ((tileMap.GetTile(new Vector3Int(xPos + 1, yPos, 0)).name == name) && (tileMap.GetTile(new Vector3Int(xPos, yPos + 1, 0)).name == name))
                {
                    one = new Vector3Int(xPos + 1, yPos, 0);
                    two = new Vector3Int(xPos, yPos + 1, 0);
                    three = new Vector3Int(xPos, yPos, 0);
                    countOfPoint = ControlDestroy(one, two, three) > 1 ? ControlDestroy(one, two, three) : countOfPoint;
                    inThis = true;
                }
            }
        }
        #endregion
        // if there are thriple than destroy.
        if (inThis)
        {
            // control all item in x for decreasing 2 or 1
            Debug.Log("One Piece");
            bool controlXCount = false;
            int[] positions = { two.x, three.x };
            foreach (var item in positions)
            {
                if (one.x == item)
                {
                    controlXCount = true;
                    break;
                }
            }
            Vector3Int choosen = Vector3Int.zero;
            Vector3Int another = Vector3Int.zero;
            choosen = controlXCount ? one : two;
            another = !controlXCount ? one : (one.x == three.x ? two : three);
            bool createBomb = false;
            //if coordinates are in bomb createBomb is true
            //create new hexes and if score is available create bomb with text
            for (int i = choosen.y; i < Horizantal - 2; i++)
            {
                tileMap.SetTile(new Vector3Int(choosen.x, i, 0), tileMap.GetTile(new Vector3Int(choosen.x, i + 2, 0)));
                if (Texts.Count > 0)
                {
                    foreach (var item in Texts)
                    {
                        if (item.Place.x == choosen.x && item.Place.y == i + 2)
                        {
                            item.Place = new Vector3Int(choosen.x, i, 0);
                            item.TextObject.transform.position = tileMap.CellToWorld(item.Place);
                        }
                    }
                }
            }
            for (int i = another.y; i < Horizantal - 1; i++)
            {
                tileMap.SetTile(new Vector3Int(another.x, i, 0), tileMap.GetTile(new Vector3Int(another.x, i + 1, 0)));
                if (Texts.Count > 0)
                {
                    foreach (var item in Texts)
                    {
                        if (item.Place.x == another.x && item.Place.y == i + 1)
                        {
                            item.Place = new Vector3Int(another.x, i, 0);
                            item.TextObject.transform.position = tileMap.CellToWorld(item.Place);
                        }
                    }
                }
            }
            if (ScoreObject.MyScore > ScoreBomb)
            {
                //bomb appear
                this.ScoreBomb += NextScoreBomb;
                createBomb = true;
            }
            for (int i = 3; i > 0; i--)
            {
                int myRandom = Random.Range(0, 5);
                tileMap.SetTile(new Vector3Int(choosen.x, Horizantal - i, 0), tile[myRandom]);
                TileBase tb = tileMap.GetTile(new Vector3Int(choosen.x, Horizantal - i, 0));
                tb.name = namesOfHexes[myRandom];
                if (i == 1)
                {
                    myRandom = Random.Range(0, 5);
                    tileMap.SetTile(new Vector3Int(another.x, Horizantal - i, 0), tile[myRandom]);
                    tb = tileMap.GetTile(new Vector3Int(another.x, Horizantal - i, 0));
                    tb.name = namesOfHexes[myRandom];
                }
            }
            if (createBomb)
            {
                Vector3Int bombWhich = Random.Range(0, 2) > 0 ? another : choosen;
                int maxValue = bombWhich == another ? 1 : 2;
                Vector3 bombTextTransform = tileMap.CellToWorld(new Vector3Int(bombWhich.x, Horizantal - Random.Range(1, maxValue), 0));
                GameObject TObject = Instantiate(textOfBomb, bombTextTransform, Quaternion.identity);
                TextModel tModel = new TextModel()
                {
                    Value = 5,
                    Place = tileMap.WorldToCell(bombTextTransform),
                    TextObject = TObject
                };
                Texts.Add(tModel);
            }
            ScoreObject.SetScore(15 * countOfPoint);
            choosenTiles = new Dictionary<Vector3Int, string>();
        }
    }
    private int ControlDestroy(Vector3Int one, Vector3Int two, Vector3Int three)
    {
        int countOfPoint = 1;
        if (Texts.Count > 0)
        {
            for (int i = 0; i < Texts.Count; i++)
            {
                Texts[i].Value -= 1;
                TextMeshPro tmp = Texts[i].TextObject.GetComponent<TextMeshPro>();
                tmp.SetText("" + Texts[i].Value);
                if (Texts[i].Value > 0)
                {
                    //Destroying Text in Bomb
                    int posX = tileMap.WorldToCell(Texts[i].TextObject.transform.position).x;
                    int posY = tileMap.WorldToCell(Texts[i].TextObject.transform.position).y;
                    if ((posX == one.x && posY == one.y) || (posX == two.x && posY == two.y) || (posX == three.x && posY == three.y))
                    {
                        countOfPoint += Texts[i].Value;
                        Destroy(Texts[i].TextObject);
                        Texts.RemoveAt(i);
                    }
                }
                else
                {
                    //Finish Game
                    FinishGame = true;
                    EndGame.SetActive(true);
                    StartCoroutine(ChangeScene());
                }
            }
        }
        return countOfPoint;
    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");
    }
}

// Bomb Information
public class TextModel
{
    public int Value { get; set; }
    public Vector3Int Place { get; set; }
    public GameObject TextObject { get; set; }
}