// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by the Game Data Editor.
//
//      Changes to this file will be lost if the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;

using GameDataEditor;

namespace GameDataEditor
{
    public class GDEWeaponItemData : IGDEData
    {
        private static string KnockbackKey = "Knockback";
		private int _Knockback;
        public int Knockback
        {
            get { return _Knockback; }
            set {
                if (_Knockback != value)
                {
                    _Knockback = value;
                    GDEDataManager.SetInt(_key+"_"+KnockbackKey, _Knockback);
                }
            }
        }

        private static string AttackRangeKey = "AttackRange";
		private int _AttackRange;
        public int AttackRange
        {
            get { return _AttackRange; }
            set {
                if (_AttackRange != value)
                {
                    _AttackRange = value;
                    GDEDataManager.SetInt(_key+"_"+AttackRangeKey, _AttackRange);
                }
            }
        }

        private static string CostOfUseKey = "CostOfUse";
		private int _CostOfUse;
        public int CostOfUse
        {
            get { return _CostOfUse; }
            set {
                if (_CostOfUse != value)
                {
                    _CostOfUse = value;
                    GDEDataManager.SetInt(_key+"_"+CostOfUseKey, _CostOfUse);
                }
            }
        }

        private static string numberOfUsesKey = "numberOfUses";
		private int _numberOfUses;
        public int numberOfUses
        {
            get { return _numberOfUses; }
            set {
                if (_numberOfUses != value)
                {
                    _numberOfUses = value;
                    GDEDataManager.SetInt(_key+"_"+numberOfUsesKey, _numberOfUses);
                }
            }
        }

        private static string itemTypeKey = "itemType";
		private string _itemType;
        public string itemType
        {
            get { return _itemType; }
            set {
                if (_itemType != value)
                {
                    _itemType = value;
                    GDEDataManager.SetString(_key+"_"+itemTypeKey, _itemType);
                }
            }
        }

        private static string ItemModelKey = "ItemModel";
		private GameObject _ItemModel;
        public GameObject ItemModel
        {
            get { return _ItemModel; }
            set {
                if (_ItemModel != value)
                {
                    _ItemModel = value;
                    GDEDataManager.SetGameObject(_key+"_"+ItemModelKey, _ItemModel);
                }
            }
        }

        public GDEWeaponItemData()
		{
			_key = string.Empty;
		}

		public GDEWeaponItemData(string key)
		{
			_key = key;
		}
		
        public override void LoadFromDict(string dataKey, Dictionary<string, object> dict)
        {
            _key = dataKey;

			if (dict == null)
				LoadFromSavedData(dataKey);
			else
			{
                dict.TryGetInt(KnockbackKey, out _Knockback);
                dict.TryGetInt(AttackRangeKey, out _AttackRange);
                dict.TryGetInt(CostOfUseKey, out _CostOfUse);
                dict.TryGetInt(numberOfUsesKey, out _numberOfUses);
                dict.TryGetString(itemTypeKey, out _itemType);
                dict.TryGetGameObject(ItemModelKey, out _ItemModel);
                LoadFromSavedData(dataKey);
			}
		}

        public override void LoadFromSavedData(string dataKey)
		{
			_key = dataKey;
			
            _Knockback = GDEDataManager.GetInt(_key+"_"+KnockbackKey, _Knockback);
            _AttackRange = GDEDataManager.GetInt(_key+"_"+AttackRangeKey, _AttackRange);
            _CostOfUse = GDEDataManager.GetInt(_key+"_"+CostOfUseKey, _CostOfUse);
            _numberOfUses = GDEDataManager.GetInt(_key+"_"+numberOfUsesKey, _numberOfUses);
            _itemType = GDEDataManager.GetString(_key+"_"+itemTypeKey, _itemType);
            _ItemModel = GDEDataManager.GetGameObject(_key+"_"+ItemModelKey, _ItemModel);
         }

        public void Reset_Knockback()
        {
            GDEDataManager.ResetToDefault(_key, KnockbackKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetInt(KnockbackKey, out _Knockback);
        }

        public void Reset_AttackRange()
        {
            GDEDataManager.ResetToDefault(_key, AttackRangeKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetInt(AttackRangeKey, out _AttackRange);
        }

        public void Reset_CostOfUse()
        {
            GDEDataManager.ResetToDefault(_key, CostOfUseKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetInt(CostOfUseKey, out _CostOfUse);
        }

        public void Reset_numberOfUses()
        {
            GDEDataManager.ResetToDefault(_key, numberOfUsesKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetInt(numberOfUsesKey, out _numberOfUses);
        }

        public void Reset_itemType()
        {
            GDEDataManager.ResetToDefault(_key, itemTypeKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetString(itemTypeKey, out _itemType);
        }

        public void Reset_ItemModel()
        {
            GDEDataManager.ResetToDefault(_key, ItemModelKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetGameObject(ItemModelKey, out _ItemModel);
        }

        public void ResetAll()
        {
            GDEDataManager.ResetToDefault(_key, KnockbackKey);
            GDEDataManager.ResetToDefault(_key, AttackRangeKey);
            GDEDataManager.ResetToDefault(_key, ItemModelKey);
            GDEDataManager.ResetToDefault(_key, CostOfUseKey);
            GDEDataManager.ResetToDefault(_key, itemTypeKey);
            GDEDataManager.ResetToDefault(_key, numberOfUsesKey);


            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            LoadFromDict(_key, dict);
        }
    }
}
