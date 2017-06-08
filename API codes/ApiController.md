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

    //TODO: implement feature
    private readonly CissDbContext _context;

    private readonly IMapper _mapper;

    public $_ObjectName_$(CissDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// 根据关联id,获取$_ObjectComment_$ 
    /// </summary>
    /// <param name="id">关联id</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(JR<List<Tbl$_ObjectName_$>>))]
    public JsonResult Get$_ObjectName_$(int? id)
    {
        if (id == null || id < 1)
        {
            return JsonFailed("Params Error");
        }

        if (!_context.$_RelateObject_$.Any(m => m.Id == id))
        {
            return JsonFailed("Not Found");
        }
        List<Tbl$_ObjectName_$> re = _context.$_ObjectName_$.Where(m => m.$_RelateObject_$_id == id).ToList();
        return JsonOk(re);
    }

    /// <summary>
    /// 获取$_ObjectComment_$ 
    /// </summary>
    /// <remarks>支持分页和 分类条件</remarks>
    /// <param name="p">页数</param>
    /// <param name="number">每页数量</param>
    /// <param name="type">分类</param>
    /// <param name="status">状态</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<Tbl$_ObjectName_$>))]
    public JsonResult Get$_ObjectName_$List(int p = 1, int number = 12, string type = null, int status = -1)
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
            return JsonFailed();
        }
        var $_ObjectVar_$ = new Tbl$_ObjectName_$
        {

        };
	    var $_ObjectVar_$ = _mapper.Map<Tbl$_ObjectName_$>($_ObjectVar_$Form);

        _context.$_ObjectName_$.Add($_ObjectVar_$);
        await _context.SaveChangesAsync();
        return JsonOk($_ObjectVar_$);
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

        var $_ObjectVar_& = _context.$_ObjectName_$.SingleOrDefault(m => m.id == id);
	    var $_ObjectVar_$ = _mapper.Map<Tbl$_ObjectName_$>($_ObjectVar_$Form);

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

//TODO: define Model
public class $_ObjectName_$Form
{
}
```