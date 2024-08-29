using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    private List<GameObject> nodes = new List<GameObject>();


    private Board board;

    public Level[] levels;

    public int currentLevel;

    public Event eventLevelStart;
    public Event eventLevelNext;

    [Header("UI")]
    public Text levelNo;

    private void Start()
    {
        board = FindObjectOfType<Board>();      
        int level = PlayerPrefs.GetInt("levelSelect");
        Debug.Log("gamelevel--" + level+"--"+ PlayerPrefs.GetInt("levelSelect"));
        if (level >= levels.Length)
        {
            level = levels.Length - 1;
        }
        generateLevel(level);

        
    }

    private void generateLevel(int levelNumber)
    {
        currentLevel = levelNumber;

        levelNo.text = (currentLevel + 1).ToString();

        eventLevelStart.occurred();

        //Destroy any previous nodes before generating the level
        destroyNodes();

        //Reset board holder node type expectation for level completion check
        for (int i = 0; i < board.boardHolders.Length; i++)
        {
            board.boardHolders[i].expectedNodeType = NodeType.none;
        }

        //Start spawning nodes for the levels
        GameObject biConnectorLeftDownPrefab = Resources.Load("Prefabs/Nodes/Bi connector left down") as GameObject;
        if (biConnectorLeftDownPrefab)
        {
            for (int i = 0; i < levels[levelNumber].biConnectorLeftDown.Length; i++)
            {
                nodes.Add(spawnNode(biConnectorLeftDownPrefab,false));
               
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].biConnectorLeftDown[i]].expectedNodeType = NodeType.biConnectorLeftDown;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].biConnectorLeftDown[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }
        //Temp
        GameObject biConnectorRightDownPrefab = Resources.Load("Prefabs/Nodes/Bi connector right down") as GameObject;
      
        if (biConnectorRightDownPrefab)
        {
            for (int i = 0; i < levels[levelNumber].biConnectorRightDown.Length; i++)
            {
                nodes.Add(spawnNode(biConnectorRightDownPrefab,false));
                if (board)
                {
                    
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].biConnectorRightDown[i]].expectedNodeType = NodeType.biConnectorRightDown;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].biConnectorRightDown[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject biConnectorUpLeftPrefab = Resources.Load("Prefabs/Nodes/Bi connector up left") as GameObject;
        if (biConnectorUpLeftPrefab)
        {
            for (int i = 0; i < levels[levelNumber].biConnectorUpLeft.Length; i++)
            {
                nodes.Add(spawnNode(biConnectorUpLeftPrefab,false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].biConnectorUpLeft[i]].expectedNodeType = NodeType.biConnectorUpLeft;

                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].biConnectorUpLeft[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject biConnectorUpRightPrefab = Resources.Load("Prefabs/Nodes/Bi connector up right") as GameObject;
        if (biConnectorUpRightPrefab)
        {
            for (int i = 0; i < levels[levelNumber].biConnectorUpRight.Length; i++)
            {
                nodes.Add(spawnNode(biConnectorUpRightPrefab,false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].biConnectorUpRight[i]].expectedNodeType = NodeType.biConnectorUpRight;

                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].biConnectorUpRight[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject boltDownPrefab = Resources.Load("Prefabs/Nodes/Bolt Down") as GameObject;
        if (boltDownPrefab)
        {
            for (int i = 0; i < levels[levelNumber].boltDown.Length; i++)
            {
                nodes.Add(spawnNode(boltDownPrefab, false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].boltDown[i]].expectedNodeType = NodeType.boltDown;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].boltDown[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject boltLeftPrefab = Resources.Load("Prefabs/Nodes/Bolt Left") as GameObject;
        if (boltLeftPrefab)
        {
            for (int i = 0; i < levels[levelNumber].boltLeft.Length; i++)
            {
                nodes.Add(spawnNode(boltLeftPrefab, false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].boltLeft[i]].expectedNodeType = NodeType.boltLeft;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].boltLeft[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject boltRightPrefab = Resources.Load("Prefabs/Nodes/Bolt Right") as GameObject;
        if (boltRightPrefab)
        {
            for (int i = 0; i < levels[levelNumber].boltRight.Length; i++)
            {
                nodes.Add(spawnNode(boltRightPrefab, false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].boltRight[i]].expectedNodeType = NodeType.boltRight;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].boltRight[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject boltUpPrefab = Resources.Load("Prefabs/Nodes/Bolt Up") as GameObject;
        if (boltUpPrefab)
        {
            for (int i = 0; i < levels[levelNumber].boltUp.Length; i++)
            {
                nodes.Add(spawnNode(boltUpPrefab, false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].boltUp[i]].expectedNodeType = NodeType.boltUp;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].boltUp[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject bulbDownPrefab = Resources.Load("Prefabs/Nodes/Bulb Down") as GameObject;
        if (bulbDownPrefab)
        {
            for (int i = 0; i < levels[levelNumber].bulbDown.Length; i++)
            {
                nodes.Add(spawnNode(bulbDownPrefab, false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].bulbDown[i]].expectedNodeType = NodeType.bulbDown;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].bulbDown[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject bulbLeftPrefab = Resources.Load("Prefabs/Nodes/Bulb Left") as GameObject;
        if (bulbLeftPrefab)
        {
            for (int i = 0; i < levels[levelNumber].bulbLeft.Length; i++)
            {
                nodes.Add(spawnNode(bulbLeftPrefab, false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].bulbLeft[i]].expectedNodeType = NodeType.bulbLeft;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].bulbLeft[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject bulbRightPrefab = Resources.Load("Prefabs/Nodes/Bulb Right") as GameObject;
        if (bulbRightPrefab)
        {
            for (int i = 0; i < levels[levelNumber].bulbRight.Length; i++)
            {
                nodes.Add(spawnNode(bulbRightPrefab, false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].bulbRight[i]].expectedNodeType = NodeType.bulbRight;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].bulbRight[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject bulbUpPrefab = Resources.Load("Prefabs/Nodes/Bulb Up") as GameObject;
        if (bulbUpPrefab)
        {
            for (int i = 0; i < levels[levelNumber].bulbUp.Length; i++)
            {
                nodes.Add(spawnNode(bulbUpPrefab, false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].bulbUp[i]].expectedNodeType = NodeType.bulbUp;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].bulbUp[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject lineHorizontolPrefab = Resources.Load("Prefabs/Nodes/Line Horizontal") as GameObject;
        if (lineHorizontolPrefab)
        {
            for (int i = 0; i < levels[levelNumber].lineHorizontol.Length; i++)
            {
                nodes.Add(spawnNode(lineHorizontolPrefab,false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].lineHorizontol[i]].expectedNodeType = NodeType.lineHorizontol;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].lineHorizontol[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject lineVerticalPrefab = Resources.Load("Prefabs/Nodes/Line Vertical") as GameObject;
        if (lineVerticalPrefab)
        {
            for (int i = 0; i < levels[levelNumber].lineVertical.Length; i++)
            {
                nodes.Add(spawnNode(lineVerticalPrefab,false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].lineVertical[i]].expectedNodeType = NodeType.lineVertical;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].lineVertical[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject quadConnectorPrefab = Resources.Load("Prefabs/Nodes/Quad connector") as GameObject;
        if (quadConnectorPrefab)
        {
            for (int i = 0; i < levels[levelNumber].quadConnector.Length; i++)
            {
                nodes.Add(spawnNode(quadConnectorPrefab,false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].quadConnector[i]].expectedNodeType = NodeType.quadConnector;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].quadConnector[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject triConnectorRightLeftDownPrefab = Resources.Load("Prefabs/Nodes/Tri connector right left down") as GameObject;
        if (triConnectorRightLeftDownPrefab)
        {
            for (int i = 0; i < levels[levelNumber].triConnectorRightLeftDown.Length; i++)
            {
                nodes.Add(spawnNode(triConnectorRightLeftDownPrefab,false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].triConnectorRightLeftDown[i]].expectedNodeType = NodeType.triConnectorRightLeftDown;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].triConnectorRightLeftDown[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject triConnectorUpLeftDownPrefab = Resources.Load("Prefabs/Nodes/Tri connector up left down") as GameObject;
        if (triConnectorUpLeftDownPrefab)
        {
            for (int i = 0; i < levels[levelNumber].triConnectorUpLeftDown.Length; i++)
            {
                nodes.Add(spawnNode(triConnectorUpLeftDownPrefab,false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].triConnectorUpLeftDown[i]].expectedNodeType = NodeType.triConnectorUpLeftDown;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].triConnectorUpLeftDown[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject triConnectorUpRightDownPrefab = Resources.Load("Prefabs/Nodes/Tri connector up right down") as GameObject;
        if (triConnectorUpRightDownPrefab)
        {
            for (int i = 0; i < levels[levelNumber].triConnectorUpRightDown.Length; i++)
            {
                nodes.Add(spawnNode(triConnectorUpRightDownPrefab,false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].triConnectorUpRightDown[i]].expectedNodeType = NodeType.triConnectorUpRightDown;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].triConnectorUpRightDown[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }

        GameObject triConnectorUpRightLeftPrefab = Resources.Load("Prefabs/Nodes/Tri connector up right left") as GameObject;
        if (triConnectorUpRightLeftPrefab)
        {
            for (int i = 0; i < levels[levelNumber].triConnectorUpRightLeft.Length; i++)
            {
                nodes.Add(spawnNode(triConnectorUpRightLeftPrefab,false));
                if (board)
                {
                    //Inform the board holder about the type of node to expect for level completion check
                    board.boardHolders[levels[levelNumber].triConnectorUpRightLeft[i]].expectedNodeType = NodeType.triConnectorUpRightLeft;
                    //Fix the spawned node position on board
                    board.boardHolders[levels[levelNumber].triConnectorUpRightLeft[i]].hold(nodes[nodes.Count - 1].GetComponent<Node>());
                }
            }
        }
    }

    private GameObject spawnNode(GameObject node, bool assignToDeck = true)
    {
        //Spawn the node
        GameObject nodeGO = Instantiate(node, Vector3.zero, Quaternion.identity) as GameObject;       
        return nodeGO;
    }

    private void destroyNodes()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            Destroy(nodes[i]);
        }
    }

    public void eventLevelCompleted()
    {
        PlayerPrefs.SetInt("levelsUnlocked",currentLevel+1);
        Invoke("playNextLevel", 1);
    }

    private void playNextLevel()
    {
        eventLevelNext.occurred();
    }

    public void eventNextLevel()
    {
        if (currentLevel < PlayerPrefs.GetInt("levelsUnlocked", 0) && currentLevel < levels.Length - 1)
        {
            generateLevel(currentLevel + 1);
        }
        else
        {
            generateLevel(currentLevel);
        }
    }


    public void eventPreviousLevel()
    {
        if (currentLevel > 0)
        {
            generateLevel(currentLevel - 1);
        }
    }
}