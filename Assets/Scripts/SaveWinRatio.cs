using System;
using Lowscope.Saving;
using UnityEngine;

namespace Lowscope.Saving.Components
{
    public class SaveWinRatio : MonoBehaviour, ISaveable
    {
        private int playerOneWins;
        private int playerTwoWins;

        [Serializable]
        public struct SaveData
        {
            public int pOneWins;
            public int pTwoWins;
        }

        private void Start()
        {
            string checkForSave = SaveMaster.GetString("scene");
            UIManager.playerOneWins = 0;
            UIManager.playerTwoWins = 0;

            if (string.IsNullOrEmpty(checkForSave))
            {
                return;
            }
            else
            {
                {
                    SaveMaster.SyncLoad();
                }
            }
        }

        public string OnSave()
        {
            playerOneWins = UIManager.playerOneWins;
            playerTwoWins = UIManager.playerTwoWins;
            return JsonUtility.ToJson(new SaveData
            {
                pOneWins = playerOneWins,
                pTwoWins = playerTwoWins
            });
        }

        public void OnLoad(string data)
        {
            var pOneWin = JsonUtility.FromJson<SaveData>(data).pOneWins;
            var pTwoWin = JsonUtility.FromJson<SaveData>(data).pTwoWins;

            UIManager.playerOneWins = pOneWin;
            UIManager.playerTwoWins = pTwoWin;
        }

        public bool OnSaveCondition()
        {
            return playerOneWins != UIManager.playerOneWins ||
                   playerTwoWins != UIManager.playerTwoWins;
        }
    }
    
}

