### 部分更新
**模型int类型可为空 :int?**


```csharp
// 可添加根据默认主键进行更新 

public void Update(object entity, object newObject)
{
    Attach(entity);
    foreach (PropertyInfo properity in newObject.GetType().GetProperties())
    {
        if (Entry(entity).Property(properity.Name).Metadata.IsPrimaryKey()) continue;
        object value = properity.GetValue(newObject);
        if (value == null) continue;

        entity.GetType().GetProperty(properity.Name).SetValue(entity, value);
        Entry(entity).Property(properity.Name).IsModified = true;
    }
}
```