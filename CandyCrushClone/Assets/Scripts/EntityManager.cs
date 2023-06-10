using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public Entity[,] entityGrid;

    public List<Entity> generatedEntityList;

    public List<Entity> entityPrefabList;

    public void SetWidthAndHeight(int width, int height)
    {
        entityGrid = new Entity[width, height];
    }

    public void AddEntity(Entity entity, int x, int y)
    {
        if (!generatedEntityList.Contains(entity))
        {
            generatedEntityList.Add(entity);
            entityGrid[x, y] = entity;
        }
    }

    public void RemoveCandy(Entity entity, int x, int y)
    {
        if (generatedEntityList.Contains(entity))
        {
            generatedEntityList.Remove(entity);
            entityGrid[x, y] = null;
        }
    }

    public Entity GetRightEntity(Entity firstEntity)
    {
        if (entityGrid.GetLength(0) > (int)firstEntity.transform.position.x + 1)
        {
            return entityGrid[(int)firstEntity.transform.position.x + 1,
                (int)firstEntity.transform.position.y];
        }
        else
        {
            return null;
        }
    }

    public Entity GetLeftEntity(Entity firstEntity)
    {
        if (entityGrid.GetLength(0) > (int)firstEntity.transform.position.x + 1)
        {
            return entityGrid[(int)firstEntity.transform.position.x + 1,
                (int)firstEntity.transform.position.y];
        }
        else
        {
            return null;
        }
    }

}
