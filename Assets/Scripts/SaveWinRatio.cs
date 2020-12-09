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
            StaticHolder.PONEWINS = 0;
            StaticHolder.PTWOWINS = 0;

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
            playerOneWins = StaticHolder.PONEWINS;
            playerTwoWins = StaticHolder.PTWOWINS;
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

            StaticHolder.PONEWINS = pOneWin;
            StaticHolder.PTWOWINS = pTwoWin;
        }

        public bool OnSaveCondition()
        {
            return playerOneWins != StaticHolder.PONEWINS ||
                   playerTwoWins != StaticHolder.PTWOWINS;
        }
    }
    
}

