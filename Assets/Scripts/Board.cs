using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public Node[] nodes;

    public int width = 6;
    public int height = 6;

    public BoardHolder[] boardHolders;

    public Transform holder;

    public Event levelCompleted;

    public Text scoretext;

    private void Awake()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly).SetCapacity(500, 20);
        generateGrid();
    }

    private void generateGrid()
    {
        int boardHolderId = 0;
        boardHolders = new BoardHolder[width * height];
        GameObject boardHolderPrefab = Resources.Load("Prefabs/Board Holder") as GameObject;
        for (int row = height - 1; row >= 0 ; row--)
        {
            for (int column = 0; column < width; column++)
            {
                //Instantiate and center the board position
                GameObject boardHolder = Instantiate(boardHolderPrefab, holder) as GameObject;
                boardHolder.transform.position = new Vector2(column - width / 2, row - height / 2);
                //Grab the reference for later use
                boardHolders[boardHolderId] = boardHolder.GetComponent<BoardHolder>();
                boardHolders[boardHolderId].assignHolderID(boardHolderId);                
                boardHolderId += 1;
            }
        }
    }

    //This event is called when the node is dropped on board
    //When this happens, check for node placements on the board, and trigger level completion if the conditions meet
    public void eventNodeDropped()
    {
        bool levelCompleted = true;
        for (int i = 0; i < boardHolders.Length; i++)
        {
            Node childNode;
            NodeType childNodeType=NodeType.none;
            //Child node type of parent board holder
            if (boardHolders[i].node)
            {
                childNode = boardHolders[i].node;
         
                if (childNode != null)
                {
                    childNodeType = childNode.nodeType;
                    switch (childNodeType)
                    {
                        case NodeType.none:
                            break;
                        case NodeType.biConnectorLeftDown:
                        case NodeType.biConnectorRightDown:
                        case NodeType.biConnectorUpLeft:
                        case NodeType.biConnectorUpRight:
                        case NodeType.boltDown:
                        case NodeType.boltLeft:
                        case NodeType.boltRight:
                        case NodeType.boltUp:
                        case NodeType.bulbDown:
                        case NodeType.bulbLeft:
                        case NodeType.bulbRight:
                        case NodeType.bulbUp:
                        case NodeType.triConnectorRightLeftDown:
                        case NodeType.triConnectorUpLeftDown:
                        case NodeType.triConnectorUpRightDown:
                        case NodeType.triConnectorUpRightLeft:
                            if (childNode.transform.eulerAngles.z != 0)
                            {
                                levelCompleted = false;
                                break;
                            }
                            break;
                        case NodeType.quadConnector:
                            
                            break;
                        case NodeType.lineHorizontol:
                        case NodeType.lineVertical:
                            if (childNode.transform.eulerAngles.z == 90 || childNode.transform.eulerAngles.z == -90)
                            {
                                levelCompleted = false;
                                break;
                            }
                            break;
                        
                            
                        default:
                            break;
                    }
                   
                }
            }
           
        }
        if (levelCompleted)
        {
            //Fire up the level complete event
            this.levelCompleted.occurred();
        }
    }

    public void SaveData()
    {
        int mscore = PlayerPrefs.GetInt("score");
        mscore = mscore + 100;
        PlayerPrefs.SetInt("score",mscore);
        scoretext.text = "" + mscore;


        int val = PlayerPrefs.GetInt("unlocklevel");
        if (val < 5) {
            val++;
            PlayerPrefs.SetInt("unlocklevel",val);
        }
        else
        {
            PlayerPrefs.SetInt("unlocklevel", val);
        }
    }
}