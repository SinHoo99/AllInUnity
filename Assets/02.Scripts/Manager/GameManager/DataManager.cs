using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

#region DataClass

public class ItemData
{
    public ItemID ID;
    public string Name;
    public ItemType Type;
    public Sprite Image;
    public string Description;
    public PoolObject Prefab;
    public bool CanStack;
    public int MaxStackAmount;
}

public class ConsumableItemData : ItemData
{
    public float HealPercentage;
}

public class ItemInfoData
{
    public ItemID ID;
    public int Amount;
}

public class DropItemInfoData : ItemInfoData
{
    public float Probability;
}

public class EntityData
{
    public float HP;
    public float EXP;
    public List<DropItemInfoData> DropItems;
}

public class EnemyData : EntityData
{
    public EntityID ID;
    public string Name;
    public float ATK;
    public float AttackRange;
    public float PlayerChasingRange;
    public float Speed;
}

public class InteractableObjectData : EntityData
{
    public EntityID ID;
    public InteractableObjectType Type;
    public int LimitLV;
}

public class PickaxeData
{
    public PickaxeID ID;
    public string Name;
    public float ATK;
    public Sprite Image;
    public Grade Grade;
    public string Description;
    public List<ItemInfoData> Resources;
    public bool CanPickaxeAura;
    public bool CanPenetrationPickaxeAura;
    public int PickaxeAuraAmount;
    public float PickaxeAuraSize;
    public float PickaxeAuraSpeed;
    public float PickaxeAuraRange;
    public Sprite PickaxeAuraImage;
}
#endregion

public class DataManager : MonoBehaviour
{
    public List<Color> GradeColor;
    public List<Color> HPColor;

    public void Initializer()
    {
      //  ContainPickaxeData();
    }

    #region ¿¹½Ã

    /*public Dictionary<PickaxeID, PickaxeData> PickaxeDatas = new Dictionary<PickaxeID, PickaxeData>();

    public void ContainPickaxeData()
    {
        List<Dictionary<string, string>> pickaxeDataList = CSVReader.Read(ResourcesPath.PickaxeCSV);

        foreach (var datas in pickaxeDataList)
        {
            PickaxeData pickaxeData = new PickaxeData();
            pickaxeData.ID = (PickaxeID)int.Parse(datas[Data.ID]);
            pickaxeData.Name = datas[Data.Name];
            pickaxeData.ATK = float.Parse(datas[Data.ATK]);
            pickaxeData.Image = Resources.Load<SpriteAtlas>(ResourcesPath.CSVSprites).GetSprite(datas[Data.Image]);
            pickaxeData.Grade = (Grade)int.Parse(datas[Data.Grade]);
            pickaxeData.Description = datas[Data.Description];
            pickaxeData.CanPickaxeAura = (int.Parse(datas[Data.CanPickaxeAura]) == 1);
            pickaxeData.CanPenetrationPickaxeAura = (int.Parse(datas[Data.CanPenetrationPickaxeAura]) == 1);
            pickaxeData.PickaxeAuraAmount = int.Parse(datas[Data.PickaxeAuraAmount]);
            pickaxeData.PickaxeAuraSize = float.Parse(datas[Data.PickaxeAuraSize]);
            pickaxeData.PickaxeAuraSpeed = float.Parse(datas[Data.PickaxeAuraSpeed]);
            pickaxeData.PickaxeAuraRange = float.Parse(datas[Data.PickaxeAuraRange]);
            pickaxeData.PickaxeAuraImage = Resources.Load<SpriteAtlas>(ResourcesPath.CSVSprites).GetSprite(datas[Data.PickaxeAuraImage]);
            PickaxeDatas.Add(pickaxeData.ID, pickaxeData);
        }
    }*/

    #endregion
    public List<ItemInfoData> SplitItemDatas(string data)
    {
        if (data == "") return null;

        List<ItemInfoData> itemDatalist = new List<ItemInfoData>();

        string[] Items = data.Split('|');
        foreach (string Item in Items)
        {
            string[] itemInfo = Item.Split(':');
            ItemInfoData itemData = new ItemInfoData();
            itemData.ID = (ItemID)int.Parse(itemInfo[0]);
            itemData.Amount = int.Parse(itemInfo[1]);
            itemDatalist.Add(itemData);
        }

        return itemDatalist;
    }

}
