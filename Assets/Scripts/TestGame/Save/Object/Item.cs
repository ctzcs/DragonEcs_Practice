using System;
using Component;
using DCFApixels.DragonECS;
using Newtonsoft.Json;
using Object;

public class Item:IEcsConverter<Item>
{
    public string name;
    
    public Item GetDataFromEcs(entlong entityId)
    {
        entityId.Unpack(out int id,out EcsWorld world);
        name = world.GetPool<Name>().Get(id).name;
        return this;
    }
}

public class ItemConverter:JsonConverter<Item>
{
    public override void WriteJson(JsonWriter writer, Item value, JsonSerializer serializer)
    {
        writer.WriteValue(value.name);
    }

    public override Item ReadJson(JsonReader reader, Type objectType, Item existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        return new Item();
    }
}