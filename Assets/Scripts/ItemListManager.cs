using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Scene
{
     /// <summary>
     /// ItemList制御クラス
     /// </summary>
     public class ItemListManager : MonoBehaviour
     {
          /// <summary>
          /// ItemList内コンテンツオブジェクト
          /// </summary>
          [SerializeField]
          private GameObject _itemListContent = null;

          /// <summary>
          /// ItemNoede
          /// </summary>
          [SerializeField]
          private GameObject _itemNode = null;

          /// <summary>
          /// ItemNode内オブジェクト
          /// </summary>
          private Image _itemImage = null;
          private Text _itemName = null;

          /// <summary>
          /// Contents内オブジェクト
          /// </summary>
          private Text _itemDetail = null;
          private Text _itemCnt = null;

          /// <summary>
          /// アイテムマスタStruct
          /// </summary>
          private struct ItemListMaster
          {
               public int itemId;     // ItemId
               public string name;    // 名前
               public string detail;  // 詳細
               public int headCap;    // 所持可能数
               public int buy;        // 買値
               public int sell;       // 売値
               public int category;   // カテゴリ
               public int skillType;  // スキルタイプ
               public int skillId;    // スキルID
          }

          /// <summary>
          /// ユーザー所持アイテムデータ
          /// </summary>
          private struct UserItemData
          {
               public int itemId; // アイテムId
               public int cnt;    // 所持数
               public bool isNew; // newフラグ
          }

          /// <summary>
          /// アイテムマスタリスト
          /// </summary>
          private List<ItemListMaster> _itemListMst = new List<ItemListMaster>();

          /// <summary>
          /// ユーザ所持アイテムデータリスト
          /// </summary>
          private List<UserItemData> _userItemDataLst = new List<UserItemData>();

          /// <summary>
          /// デバッグデータロード処理
          /// TODO:後で削除
          /// </summary>
          private void DebugDataLoad()
          {
               // ItemMasterデータロード
               _itemListMst.Clear();
               for (int itemMstCnt = 0; itemMstCnt < 50; itemMstCnt++)
               {
                    ItemListMaster itemMstData = new ItemListMaster();
                    itemMstData.itemId = itemMstCnt;
                    itemMstData.name = "テストアイテム" + itemMstCnt;
                    itemMstData.detail = "テストを行うアイテム" + itemMstCnt;
                    itemMstData.headCap = itemMstCnt * 10;
                    itemMstData.buy = itemMstCnt * 11;
                    itemMstData.sell = itemMstCnt * 12;
                    itemMstData.category = itemMstCnt / 10;
                    itemMstData.skillType = itemMstCnt / 5;
                    itemMstData.skillId = itemMstCnt / 6;

                    _itemListMst.Add(itemMstData);
               }

               // UserItemDataロード
               _userItemDataLst.Clear();
               for (int itemCnt = 0; itemCnt < 50; itemCnt++)
               {
                    if (itemCnt % 3 != 0)
                    {
                         UserItemData userItemData = new UserItemData();
                         userItemData.itemId = itemCnt;
                         userItemData.cnt = itemCnt * 5;
                         userItemData.isNew = (itemCnt % 2 == 0);

                         _userItemDataLst.Add(userItemData);
                    }
               }
          }

          /// <summary>
          /// 初期化処理
          /// </summary>
          void Start()
          {
               // TODO:テストデータのロード
               DebugDataLoad();
          }
     }
}
