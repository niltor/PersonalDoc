###  分页获取
**模型类名**

```csharp
/// <summary>
///  获取资质
/// </summary>
/// <remarks>支持分页和 分类条件</remarks>
/// <param name="p">页数</param>
/// <param name="number">每页数量</param>
/// <param name="type">分类</param>
/// <param name="status">状态</param>
/// <returns></returns>
[HttpGet]
[ProducesResponseType(200, Type = typeof(List<ActionLog>))]
public JsonResult GetActionLogs(int p = 1, int number = 12, string type = null,int status = -1)
{
    IQueryable<ActionLog> query = _context.ActionLogs.Skip((p - 1) * number).Take(number).AsQueryable();
        if (!String.IsNullOrEmpty(type))
        {
            //query = query.Where(m => m.ActionType == type);
        }
        if (status > -1)
        {
            //query = query.Where(m => m.Status == status);
        }


    return JsonOk(query.ToList(), p, query.Count());
}
```

