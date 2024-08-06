using System;
using System.Collections.Generic;
using DCFApixels.DragonECS;
using GameOne.Ecs;
using Newtonsoft.Json;
using Name = GameOne.Ecs.Name;

namespace GameOne.Object
{
    public class Player:IEcsConverter<Player>
    {
        public string name;
        public int health;
        public List<Item> items;

        public Player()
        {
            name = null;
            health = 0;
            items = new List<Item>();
        }
        public static void CreatePlayer(EcsDefaultWorld world,Player player)
        {
            int e = world.NewEntity();
            world.GetPool<Name>().Add(e);
        }
    
        public Player GetDataFromEcs(entlong entityId)
        {
            entityId.Unpack(out int id, out EcsWorld world);
            name = world.GetPool<Name>().Read(id).name;
            health = world.GetPool<Health>().Read(id).healthValue;
            if (world.GetPool<ItemContainer>().Has(id))
            {
                var itemIds = world.GetPool<ItemContainer>().Read(id).itemIds;
                foreach (var itemLongId in itemIds)
                {
                    var itemId = itemLongId.ID;
                    Item item = new Item();
            
                    items.Add(item);
                }
            }
            return this;
        }
    }


    public class PlayerConverter : JsonConverter<Player>
    {
        public override void WriteJson(JsonWriter writer, Player value, JsonSerializer serializer)
        {
            writer.WriteValue(value.name);
            writer.WriteValue(value.health);
            writer.WriteValue(value.items.Count);
            ItemConverter itemConverter = new ItemConverter();
            for (int i = 0; i < value.items.Count; i++)
            {
                itemConverter.WriteJson(writer,value.items[i],serializer);
            }
        }

        public override Player ReadJson(JsonReader reader, Type objectType, Player existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            Player player = new Player();
            player.name = reader.ReadAsString();
            player.health = reader.ReadAsInt32() ?? 0;
            player.items = new List<Object.Item>(reader.ReadAsInt32()??0);
            ItemConverter itemConverter = new ItemConverter();
            for (int i = 0; i < player.items.Capacity; i++)
            {
                GameOne.Object.Item item = itemConverter.ReadJson(reader, typeof(GameOne.Object.Item),null, false,serializer);
                player.items.Add(item);
            }
            return player;
        }
    }
}