using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataNeedSaved
{
    public List <BienDong> dsBienDong;
    public int money;
    public DataNeedSaved(LichSuBienDong bs){
        
        money = bs.getMoney();
        dsBienDong = bs.getListBienDong();
    }
    public List<BienDong> getLichSuBienDong(){
        return dsBienDong;
    }
    public int getMoney(){
        return money;
    }
}
