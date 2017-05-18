```csharp
/// <summary>
/// 成功返回数据
/// </summary>
/// <param name="data"></param>
/// <returns></returns>
protected JsonResult JsonOk(object data)
{
    return Json(new { Data = data, ErrorCode = 0, Msg = "success", DateTime = DateTime.Now });
}
/// <summary>
/// 带分页的返回 
/// </summary>
/// <param name="data"></param>
/// <param name="p"></param>
/// <param name="total"></param>
/// <returns></returns>
protected JsonResult JsonOk(object data, int p, int total)
{
    return Json(new { Data = data, ErrorCode = 0, Msg = "success", DateTime = DateTime.Now, Page = p, Total = total });
}

protected JsonResult JsonFailed(string msg = null)
{

    if (String.IsNullOrEmpty(msg))
    {
        msg = ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
    }

    return Json(new { Data = "", ErrorCode = 1, Msg = msg, DateTime = DateTime.Now });
}

protected JsonResult JsonFailed(object data, string msg = null)
{
    if (String.IsNullOrEmpty(msg))
    {
        msg = ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
    }
    return Json(new { Data = data, ErrorCode = 1, Msg = msg, DateTime = DateTime.Now });
}


```