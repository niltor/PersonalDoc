###  控制器模板

可替换内容:
- 对象说明 `$_ObjectComment_$`
- 对象名称 `$_ObjectName_$`
- 对象变量 `$_ObjectVar_$`
```csharp
/// <summary>
/// 供应$_ObjectComment_$  接口
/// </summary>
[Produces("application/json")]
public class $_ObjectName_$ : BaseController
{
    readonly CissDbContext _context;
    public $_ObjectName_$(CissDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///  获取$_ObjectComment_$ 
    /// </summary>
    /// <remarks>支持分页和 分类条件</remarks>
    /// <param name="p">页数</param>
    /// <param name="number">每页数量</param>
    /// <param name="type">分类</param>
    /// <param name="status">状态</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<Tbl$_ObjectName_$>))]
    public JsonResult Get$_ObjectName_$(int p = 1, int number = 12, string type = null, int status = -1)
    {
        IQueryable<Tbl$_ObjectName_$> query = _context.$_ObjectName_$.Skip((p - 1) * number).Take(number).AsQueryable();
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

    /// <summary>
    /// 新增$_ObjectComment_$ 
    /// </summary>
    /// <param name="$_ObjectVar_$Form">操作记录</param>
    /// <remarks>json格式的ActionLog模型</remarks>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(200, Type = typeof(Tbl$_ObjectName_$))]
    public async Task<JsonResult> New$_ObjectName_$([FromBody] $_ObjectName_$Form $_ObjectVar_$Form)
    {
        if (!ModelState.IsValid)
        {
            return JsonFailed(ModelState);
        }
        var companSupply = new Tbl$_ObjectName_$
        {

        };
        _context.$_ObjectName_$.Add(companSupply);
        await _context.SaveChangesAsync();
        return JsonOk(companSupply);
    }

    /// <summary>
    /// 编辑$_ObjectComment_$ 
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="$_ObjectVar_$Form">表单数据</param>
    /// <returns></returns>
    [HttpPut]
    public IActionResult Edit$_ObjectName_$([FromRoute] int id, $_ObjectName_$Form $_ObjectVar_$Form)
    {
        if (!ModelState.IsValid)
        {
            return JsonFailed();
        }

        var certificate = _context.$_ObjectName_$.SingleOrDefault(m => m.id == id);

        if (certificate?.id != null)
        {
            //certificate.Status = certificateReviewForm.Status;
            //certificate.ReviewMsg = certificateReviewForm.ReviewMsg;

            int re = _context.SaveChanges();
            return JsonOk(re);
        }
        else
        {
            return JsonFailed("Not exist");
        }

    }
}

public class $_ObjectName_$Form
{
}
```