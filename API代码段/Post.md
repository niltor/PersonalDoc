### 添加内容
**模型**

```csharp
/// <summary>
/// 添加记录
/// </summary>
/// <param name="logForm">操作记录</param>
/// <remarks>json格式的ActionLog模型</remarks>
/// <returns></returns>
[HttpPost]
[ProducesResponseType(200, Type = typeof(ActionLog))]
public async Task<JsonResult> PostActionLog([FromBody] LogForm logForm)
{
    if (!ModelState.IsValid)
    {
        return JsonFailed(ModelState);
    }
    var actionLog = new ActionLog
    {

    };

    _context.ActionLogs.Add(actionLog);
    await _context.SaveChangesAsync();
    return JsonOk(actionLog);
}
```