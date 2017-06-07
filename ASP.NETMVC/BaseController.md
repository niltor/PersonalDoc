### 获取错误信息


```csharp
protected JsonResult JsonFailed(string msg = null)
{
    if (string.IsNullOrEmpty(msg))
    {
        var states = ModelState.Values;
        foreach (var state in states)
        {
            foreach (var error in state.Errors)
            {
                if (string.IsNullOrEmpty(error.ErrorMessage)) continue;
                msg = error.ErrorMessage;
                goto result;
            }
        }
    }
    result: return Json(new { Data = "", ErrorCode = 1, Msg = msg, DateTime = DateTime.Now });
}
```